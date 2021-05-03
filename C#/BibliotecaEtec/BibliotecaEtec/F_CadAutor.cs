using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    public partial class F_CadAutor : Form
    {
        F_SelecionaAutor formulario = null;
        int tipoOp = 0;
        string codigo = string.Empty;
        string codigoC = string.Empty;

        public F_CadAutor(F_SelecionaAutor f, int tipoOp, string codigo = null, string codigoC = null) //1 - Cadastro | 2 - Edição
        {
            InitializeComponent();

            this.formulario = f;
            this.tipoOp = tipoOp;
            this.codigo = codigo;
            this.codigoC = codigo;

            if (this.tipoOp == 1)
            {
                btn_executa.Text = "Cadastrar Autor";
            }
            else
            {
                btn_executa.Text = "Salvar Edições";

                DataTable dt = BCO.Dql("SELECT a.nome_autor, a.nacionalidade, c.nomes FROM autor AS a INNER JOIN colaboradores AS c ON a.cod_colaborador = c.cod_colaborador WHERE a.id_autor = " + codigo + " LIMIT 1");

                if (dt.Rows.Count > 0)
                {
                    txt_nome_autor.Text = dt.Rows[0].ItemArray[0].ToString();
                    txt_nacionalidade.Text = dt.Rows[0].ItemArray[1].ToString();
                    txt_colaboradores.Text = dt.Rows[0].ItemArray[2].ToString();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btn_executa_Click(object sender, EventArgs e)
        {
            bool verifica = true;

            if (txt_nome_autor.Text.Trim().Length == 0)
            {
                lb_nome.Visible = true;
                verifica = false;
            }

            if (txt_nacionalidade.Text.Trim().Length == 0)
            {
                lb_nacionalidade.Visible = true;
                verifica = false;
            }

            if (verifica)
            {
                string sql = string.Empty;

                var conexao = BCO.conexaoBCO();
                var cmd = conexao.CreateCommand();

                if (this.tipoOp == 1) //Cadastro
                {
                    try
                    {

                        //Cadastrando colaboradores

                        cmd.CommandText = "INSERT INTO colaboradores (nomes) VALUES (@nomes)";
                        cmd.Parameters.AddWithValue("@nomes", txt_colaboradores.Text.Trim());
                        cmd.ExecuteNonQuery();

                        //Cadastrando autor

                        string cod = cmd.LastInsertedId.ToString();

                        cmd.CommandText = "INSERT INTO autor (nome_autor, nacionalidade, cod_colaborador) VALUES (@nome, @nacio, @cod)";
                        cmd.Parameters.AddWithValue("@nome", txt_nome_autor.Text.Trim());
                        cmd.Parameters.AddWithValue("@nacio", txt_nacionalidade.Text.Trim());
                        cmd.Parameters.AddWithValue("@cod", cod);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Autor cadastrado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt_nome_autor.Clear();
                        txt_nacionalidade.Clear();
                        txt_colaboradores.Clear();

                        formulario.dgv_autor.Rows.Clear();

                        formulario.carregarMais();
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possivel cadastrar este autor, Ocorreu um erro na operação de cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //Edição
                {
                    try
                    {
                        //Editando colaboradores

                        cmd.CommandText = "UPDATE colaboradores SET nomes = @cola WHERE cod_colaborador = @codC LIMIT 1";
                        cmd.Parameters.AddWithValue("@cola", txt_colaboradores.Text.Trim());
                        cmd.Parameters.AddWithValue("@codC", codigoC);
                        cmd.ExecuteNonQuery();

                        //Editando autor

                        string cod = cmd.LastInsertedId.ToString();

                        cmd.CommandText = "UPDATE autor SET nome_autor = @nome, nacionalidade = @nacio WHERE id_autor = @cod LIMIT 1";
                        cmd.Parameters.AddWithValue("@nome", txt_nome_autor.Text.Trim());
                        cmd.Parameters.AddWithValue("@nacio", txt_nacionalidade.Text.Trim());
                        cmd.Parameters.AddWithValue("@cod", codigo);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Autor editado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        formulario.dgv_autor.Rows.Clear();

                        formulario.carregarMais();
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possivel editar este autor, Ocorreu um erro na operação de edição ou você não alterou nenhum dado para edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txt_nome_autor_TextChanged(object sender, EventArgs e)
        {
            lb_nome.Visible = false;
        }

        private void txt_nacionalidade_TextChanged(object sender, EventArgs e)
        {
            lb_nacionalidade.Visible = false;
        }
    }
}
