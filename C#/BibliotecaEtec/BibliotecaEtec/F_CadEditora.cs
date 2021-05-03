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
    public partial class F_CadEditora : Form
    {
        F_SelecionaEditora formulario = null;
        int tipoOp = 0;
        string codigo = string.Empty;

        public F_CadEditora(F_SelecionaEditora f, int tipoOp, string codigo = null) //1 - Cadastro | 2 - Edição
        {
            InitializeComponent();

            this.formulario = f;
            this.tipoOp = tipoOp;
            this.codigo = codigo;

            if (this.tipoOp == 1)
            {
                btn_executa.Text = "Cadastrar Editora";
            }
            else
            {
                btn_executa.Text = "Salvar Edições";

                DataTable dt = BCO.Dql("SELECT * FROM editora WHERE id_editora = " + codigo + " LIMIT 1");

                if(dt.Rows.Count > 0)
                {
                    txt_nome_editora.Text = dt.Rows[0].ItemArray[1].ToString();
                    txt_cnpj_editora.Text = dt.Rows[0].ItemArray[2].ToString();
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

            if(txt_nome_editora.Text.Trim().Length == 0)
            {
                lb_nome.Visible = true;
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
                        cmd.CommandText = "INSERT INTO editora (nome_editora, cnpj) VALUES (@nome, @cnpj)";
                        cmd.Parameters.AddWithValue("@nome", txt_nome_editora.Text.Trim());
                        cmd.Parameters.AddWithValue("@cnpj", txt_cnpj_editora.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Editora cadastrada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt_nome_editora.Clear();
                        txt_cnpj_editora.Clear();

                        formulario.dgv_editora.Rows.Clear();

                        formulario.carregarMais();
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possivel cadastrar esta editora, Ocorreu um erro na operação de cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //Edição
                {
                    try
                    {
                        cmd.CommandText = "UPDATE editora SET nome_editora = @nome, cnpj = @cnpj WHERE id_editora = @cod LIMIT 1";
                        cmd.Parameters.AddWithValue("@nome", txt_nome_editora.Text.Trim());
                        cmd.Parameters.AddWithValue("@cnpj", txt_cnpj_editora.Text.Trim());
                        cmd.Parameters.AddWithValue("@cod", codigo);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Editora editada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        formulario.dgv_editora.Rows.Clear();

                        formulario.carregarMais();
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possivel editar esta editora, Ocorreu um erro na operação de edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txt_nome_editora_TextChanged(object sender, EventArgs e)
        {
            lb_nome.Visible = false;
        }
    }
}
