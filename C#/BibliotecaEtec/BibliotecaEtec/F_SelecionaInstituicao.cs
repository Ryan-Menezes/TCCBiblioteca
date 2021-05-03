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
using MySql.Data;
using MySql.Data.MySqlClient;
using Biblioteca01;

namespace BibliotecaEtec
{
    public partial class F_SelecionaInstituicao : Form
    {
        F_CadProfessores formularioP = null;
        F_CadFuncionario formularioF = null;
        F_EditaProfessor formularioEdicaoP = null;
        F_EditaFuncionario formularioEdicaoF = null;

        public F_SelecionaInstituicao(F_CadProfessores p, F_CadFuncionario f, F_EditaProfessor ep, F_EditaFuncionario ef)
        {
            InitializeComponent();

            formularioP = p;
            formularioF = f;
            formularioEdicaoP = ep;
            formularioEdicaoF = ef;

            if (formularioP == null && formularioEdicaoP == null)
            {
                cb_situacao.Visible = false;
                lb_situacao.Visible = false;
            }
        }

        private void F_SelecionaInstituicao_Load(object sender, EventArgs e)
        {
            //Carregando a combo box situação

            Dictionary<string, string> situacao = new Dictionary<string, string>();
            situacao.Add("D", "Determinado");
            situacao.Add("I", "Indeterminado");

            cb_situacao.DataSource = new BindingSource(situacao, null);
            cb_situacao.DisplayMember = "Value";
            cb_situacao.ValueMember = "Key";

            //Arredondando imagem

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        private void carregarMais()
        {
            string texto = string.Empty;

            if (tb_pesquisa.Text.Trim() == "Pesquisar instituição...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            //Carregando instituições

            DataTable dt = new DataTable();

            dt = BCO.Dql("SELECT * FROM instituicao WHERE nome_instituicao LIKE '%" + texto + "%' LIMIT " + dgv_instituicao.Rows.Count + ", 10");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i].ItemArray[0].ToString();
                string nome = dt.Rows[i].ItemArray[1].ToString();

                dgv_instituicao.Rows.Add(id, nome);
            }

            panel5.Height = (50 * dgv_instituicao.Rows.Count) + 50;
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar instituição...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar instituição...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgv_instituicao.Rows.Clear();

                carregarMais();
            }
        }

        private void dgv_instituicao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string codigoInstituicao = dgv_instituicao.Rows[dgv_instituicao.SelectedRows[0].Index].Cells[0].Value.ToString();
            string nome = dgv_instituicao.Rows[dgv_instituicao.SelectedRows[0].Index].Cells[1].Value.ToString();

            if (formularioP != null)
            {
                if (formularioP.cod_instituicoes.IndexOf(codigoInstituicao) == -1)
                {
                    formularioP.cod_instituicoes.Add(codigoInstituicao);
                    formularioP.situacoes.Add(cb_situacao.SelectedValue.ToString());
                    formularioP.list_instituicao.Items.Add(nome + " - " + cb_situacao.Text);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta instituição já foi adicionada na lista, Não é possível adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(formularioF != null)
            {
                if (formularioF.cod_instituicoes.IndexOf(codigoInstituicao) == -1)
                {
                    formularioF.cod_instituicoes.Add(codigoInstituicao);
                    formularioF.list_instituicao.Items.Add(nome);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta instituição já foi adicionada na lista, Não é possível adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (formularioEdicaoP != null)
            {
                if (formularioEdicaoP.cod_instituicoes.IndexOf(codigoInstituicao) == -1)
                {
                    formularioEdicaoP.cod_instituicoes.Add(codigoInstituicao);
                    formularioEdicaoP.situacoes.Add(cb_situacao.SelectedValue.ToString());
                    formularioEdicaoP.list_instituicao.Items.Add(nome + " - " + cb_situacao.Text);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta instituição já foi adicionada na lista, Não é possível adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (formularioEdicaoF.cod_instituicoes.IndexOf(codigoInstituicao) == -1)
                {
                    formularioEdicaoF.cod_instituicoes.Add(codigoInstituicao);
                    formularioEdicaoF.list_instituicao.Items.Add(nome);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta instituição já foi adicionada na lista, Não é possível adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
