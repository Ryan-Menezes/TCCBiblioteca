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
    public partial class F_SelecionaEditora : Form
    {
        F_CadLivro formularioL = null;
        F_AdicionaExemplares formularioA = null;
        F_EditaLivro formularioE = null;

        public F_SelecionaEditora(F_CadLivro fl, F_AdicionaExemplares fa, F_EditaLivro fe)
        {
            InitializeComponent();

            this.formularioL = fl;
            this.formularioA = fa;
            this.formularioE = fe;
        }

        private void F_SelecionaEditora_Load(object sender, EventArgs e)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        public void carregarMais()
        {
            DataTable dt = new DataTable();

            string texto = string.Empty;

            if (tb_pesquisa.Text.Trim() == "Pesquisar editora...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            try
            {
                dt = BCO.Dql("SELECT * FROM editora WHERE nome_editora LIKE '%" + texto + "%' ORDER BY nome_editora LIMIT " + dgv_editora.Rows.Count + ", 10");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i].ItemArray[0].ToString();
                    string nome = dt.Rows[i].ItemArray[1].ToString();
                    string cnpj = dt.Rows[i].ItemArray[2].ToString();

                    dgv_editora.Rows.Add(id, nome, cnpj);
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao carregar mais autores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panel5.Height = (50 * dgv_editora.Rows.Count) + 50;
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar editora...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar editora...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void btn_editora_Click(object sender, EventArgs e)
        {
            F_CadEditora c = new F_CadEditora(this, 1);
            c.ShowDialog();
        }

        // Função para excluir e editar

        private void dgv_editora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_editora.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_editora.Rows[e.RowIndex].Cells[0].Value.ToString(); //Codigo da editora selecionada

                if (e.ColumnIndex == 3) //Deletar Editora
                {
                    DialogResult res = MessageBox.Show("Você realmente deseja deletar esta editora?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (res == DialogResult.Yes)
                    {
                        //Buscando editora

                        DataTable dt = BCO.Dql("SELECT * FROM editora_livro WHERE id_editora = " + codigo + " LIMIT 1");

                        if (dt.Rows.Count == 0)
                        {
                            BCO.Dml("DELETE FROM editora WHERE id_editora = " + codigo + " LIMIT 1", "Editora deletada com sucesso", "Não foi possivel deletar esta editora, Ocorreu um erro no procedimento");

                            dgv_editora.Rows.Clear();
                            carregarMais();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possivel deletar esta editora, pois ela se encontra cadastrada a um livro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (e.ColumnIndex == 4) //Editar dados
                {
                    F_CadEditora c = new F_CadEditora(this, 2, codigo);
                    c.ShowDialog();
                }
            }
        }

        private void dgv_editora_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = dgv_editora.Rows[dgv_editora.SelectedRows[0].Index].Cells[0].Value.ToString();
            string nome = dgv_editora.Rows[dgv_editora.SelectedRows[0].Index].Cells[1].Value.ToString();

            if(formularioL != null)
            {
                if (formularioL.editoras.IndexOf(id) == -1)
                {
                    formularioL.editoras.Add(id);
                    formularioL.list_editora.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta editora já foi adicionada na lista, Não é possivel adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(formularioA != null)
            {
                if (formularioA.editoras.IndexOf(id) == -1)
                {
                    formularioA.editoras.Add(id);
                    formularioA.list_editora.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta editora já foi adicionada na lista, Não é possivel adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (formularioE != null)
            {
                if (formularioE.editoras.IndexOf(id) == -1)
                {
                    formularioE.editoras.Add(id);
                    formularioE.list_editora.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta editora já foi adicionada na lista, Não é possivel adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgv_editora.Rows.Clear();

                carregarMais();
            }
        }
    }
}
