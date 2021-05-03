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
    public partial class F_SelecionaAutor : Form
    {
        F_CadLivro formulario = null;
        F_CadLivroPDF formularioPDF = null;
        F_EditaLivro formularioE = null;
        F_EditaLivroPDF formularioEP = null;

        public F_SelecionaAutor(F_CadLivro f, F_CadLivroPDF fp, F_EditaLivro fe, F_EditaLivroPDF fep)
        {
            InitializeComponent();

            this.formulario = f;
            this.formularioPDF = fp;
            this.formularioE = fe;
            this.formularioEP = fep;

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        public void carregarMais()
        {
            DataTable dt = new DataTable();

            string texto = string.Empty;

            if(tb_pesquisa.Text.Trim() == "Pesquisar autor...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            try
            {
                dt = BCO.Dql("SELECT a.id_autor, a.nome_autor, a.nacionalidade, c.cod_colaborador, c.nomes FROM autor AS a INNER JOIN colaboradores AS c ON a.cod_colaborador = c.cod_colaborador WHERE a.nome_autor LIKE '%" + texto + "%' ORDER BY a.nome_autor LIMIT " + dgv_autor.Rows.Count + ", 10");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i].ItemArray[0].ToString();
                    string nome = dt.Rows[i].ItemArray[1].ToString();
                    string nacionalidade = dt.Rows[i].ItemArray[2].ToString();
                    string cod_colaborador = dt.Rows[i].ItemArray[3].ToString();
                    string nomes = dt.Rows[i].ItemArray[4].ToString();

                    dgv_autor.Rows.Add(id, cod_colaborador, nome, nomes, nacionalidade);
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao carregar mais autores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panel5.Height = (50 * dgv_autor.Rows.Count) + 50;
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar autor...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar autor...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void btn_autor_Click(object sender, EventArgs e)
        {
            F_CadAutor f = new F_CadAutor(this, 1);
            f.ShowDialog();
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgv_autor.Rows.Clear();

                carregarMais();
            }
        }

        // Função para excluir e editar

        private void dgv_autor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_autor.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_autor.Rows[e.RowIndex].Cells[0].Value.ToString(); //Codigo da editora selecionada
                string codigoC = dgv_autor.Rows[e.RowIndex].Cells[1].Value.ToString(); //Codigo dcolaborador

                if (e.ColumnIndex == 5) //Deletar Editora
                {
                    DialogResult res = MessageBox.Show("Você realmente deseja deletar este autor?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if(res == DialogResult.Yes)
                    {
                        //Buscando autor

                        DataTable dt = BCO.Dql("SELECT * FROM autor_livro WHERE id_autor_tombo = " + codigo + " LIMIT 1");

                        if(dt.Rows.Count == 0)
                        {
                            BCO.Dml("DELETE FROM colaboradores WHERE cod_colaborador = " + codigoC + " LIMIT 1", "Autor deletado com sucesso", "Não foi possivel deletar este autor, Ocorreu um erro no procedimento");

                            dgv_autor.Rows.Clear();
                            carregarMais();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possivel deletar este autor, pois ele se encontra cadastrado a um livro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (e.ColumnIndex == 6) //Editar dados
                {
                    F_CadAutor c = new F_CadAutor(this, 2, codigo, codigoC);
                    c.ShowDialog();
                }
            }
        }

        private void dgv_autor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = dgv_autor.Rows[dgv_autor.SelectedRows[0].Index].Cells[0].Value.ToString();
            string nome = dgv_autor.Rows[dgv_autor.SelectedRows[0].Index].Cells[2].Value.ToString();

            if (formulario != null)
            {
                if (formulario.autores.IndexOf(id) == -1)
                {
                    formulario.autores.Add(id);
                    formulario.list_autores.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este autor já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(formularioPDF != null)
            {
                if (formularioPDF.autores.IndexOf(id) == -1)
                {
                    formularioPDF.autores.Add(id);
                    formularioPDF.list_autores.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este autor já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (formularioE != null)
            {
                if (formularioE.autores.IndexOf(id) == -1)
                {
                    formularioE.autores.Add(id);
                    formularioE.list_autores.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este autor já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (formularioEP != null)
            {
                if (formularioEP.autores.IndexOf(id) == -1)
                {
                    formularioEP.autores.Add(id);
                    formularioEP.list_autores.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este autor já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
