using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Biblioteca01;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BibliotecaEtec
{
    public partial class F_SelecionarLivro : Form
    {
        private F_CadAlocacao form;

        public F_SelecionarLivro(F_CadAlocacao f)
        {
            InitializeComponent();

            this.form = f;
        }

        private void F_SelecionarLivro_Load(object sender, EventArgs e)
        {
            //Preenchendo combo box instituições

            cb_instituicao.DataSource = new BindingSource(UsuarioLogado.instituicoes, null);
            cb_instituicao.DisplayMember = "Value";
            cb_instituicao.ValueMember = "Key";

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        private void carregarMais()
        {
            DataTable dt = new DataTable();

            try
            {
                string id_instituicao = cb_instituicao.SelectedValue.ToString();
                string texto = string.Empty;

                if (tb_pesquisa.Text.Trim() != "Pesquisar livro...")
                {
                    texto = tb_pesquisa.Text.Trim();
                }

                dt = BCO.Dql("SELECT e.id_exemplares, l.titulo, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro WHERE titulo LIKE '%" + texto + "%' AND tombo IS NOT NULL AND e.id_instituicao = " + id_instituicao + " AND (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) > 0 ORDER BY l.titulo LIMIT " + dgv_livro.Rows.Count + ", 10");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    byte[] img = (byte[])dt.Rows[i].ItemArray[2];
                    MemoryStream ms = new MemoryStream(img);

                    dgv_livro.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), System.Drawing.Image.FromStream(ms), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[3].ToString());
                }
            }catch { }

            panel5.Height = (50 * dgv_livro.Rows.Count) + 50;
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar livro...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar livro...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void dgv_livro_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dt = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                string codigoLivro = dt.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (form.cod_livros.IndexOf(codigoLivro) == -1)
                {
                    form.cod_livros.Add(codigoLivro);
                    form.list_livros.Items.Add(dt.Rows[e.RowIndex].Cells[2].Value.ToString());

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este livro já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgv_livro.Rows.Clear();

                carregarMais();
            }
        }

        private void cb_instituicao_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_instituicao.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                dgv_livro.Rows.Clear();

                carregarMais();
            }
        }
    }
}
