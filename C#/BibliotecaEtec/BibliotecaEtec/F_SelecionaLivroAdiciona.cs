using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    public partial class F_SelecionaLivroAdiciona : Form
    {
        private F_AdicionaExemplares form;

        public F_SelecionaLivroAdiciona(F_AdicionaExemplares f)
        {
            InitializeComponent();

            this.form = f;

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
                string texto = string.Empty;

                if (tb_pesquisa.Text.Trim() != "Pesquisar livro...")
                {
                    texto = tb_pesquisa.Text.Trim();
                }

                dt = BCO.Dql("SELECT cod_livro, tombo, titulo, img_livro FROM livro WHERE titulo LIKE '%" + texto + "%' ORDER BY titulo LIMIT " + dgv_livro.Rows.Count + ", 10");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    byte[] img = (byte[])dt.Rows[i].ItemArray[3];
                    MemoryStream ms = new MemoryStream(img);

                    dgv_livro.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), System.Drawing.Image.FromStream(ms), dt.Rows[i].ItemArray[2].ToString());
                }
            }
            catch { }

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
                string codigo = dt.Rows[e.RowIndex].Cells[0].Value.ToString();
                string texto = dt.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (dt.Rows[e.RowIndex].Cells[1].Value.ToString().Length > 0)
                {
                    form.tb_livro.Tag = codigo;
                    form.tb_livro.Text = texto + " - Tombo: " + dt.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.tombo = null;
                    form.isbn = null;
                }
                else
                {
                    F_PegaTomboIsbn f = new F_PegaTomboIsbn(form, codigo, texto);
                    f.ShowDialog();
                }

                this.Close();
            }
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgv_livro.Rows.Clear();

                carregarMais();
            }
        }
    }
}
