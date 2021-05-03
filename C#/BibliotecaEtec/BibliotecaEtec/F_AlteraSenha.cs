using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using Biblioteca01;

namespace BibliotecaEtec
{
    public partial class F_AlteraSenha : Form
    {
        public F_AlteraSenha()
        {
            InitializeComponent();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            bool verifica = true;

            if (tb_senha.Text.Trim().Length == 0)
            {
                lb_aviso.Text = "Digite sua senha atual";
                verifica = false;
            }
            else if (tb_NovaSenha.Text.Trim().Length == 0)
            {
                lb_aviso.Text = "Digite sua nova senha com pelo menos 8 digítos!";
                verifica = false;
            }
            else if (tb_RepetirNovaSenha.Text.Trim().Length == 0)
            {
                lb_aviso.Text = "Repita sua nova senha";
                verifica = false;
            }
            else if(tb_NovaSenha.Text.Trim() != tb_RepetirNovaSenha.Text.Trim())
            {
                lb_aviso.Text = "As senhas digitadas não são iguais!";
                verifica = false;
            }

            lb_aviso.Visible = !verifica;

            if (verifica)
            {
                //Criptografando senha digitada(Atual)

                MD5 md5 = MD5.Create();
                string senha = string.Empty;

                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(tb_senha.Text.Trim()));

                foreach(byte b in hash)
                {
                    senha += b.ToString("x2");
                }

                //Verificando se a senha digitada é igual a atual

                if(senha == UsuarioLogado.senha)
                {
                    //Criptografando senha digitada(Nova)

                    senha = string.Empty;

                    hash = md5.ComputeHash(Encoding.UTF8.GetBytes(tb_NovaSenha.Text.Trim()));

                    foreach (byte b in hash)
                    {
                        senha += b.ToString("x2");
                    }

                    if(senha != UsuarioLogado.senha)
                    {
                        //Salvando a nova senha

                        MySqlConnection conexao = BCO.conexaoBCO();
                        var cmd = conexao.CreateCommand();

                        try
                        {
                            cmd.CommandText = "UPDATE usuario SET senha = @senha WHERE id_usuario = @id LIMIT 1";
                            cmd.Parameters.AddWithValue("@senha", senha);
                            cmd.Parameters.AddWithValue("@id", UsuarioLogado.codUsuario);
                            cmd.ExecuteNonQuery();

                            UsuarioLogado.senha = senha;

                            MessageBox.Show("Senha alterada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            tb_senha.Clear();
                            tb_NovaSenha.Clear();
                            tb_RepetirNovaSenha.Clear();
                        }
                        catch
                        {
                            MessageBox.Show("Não foi possivel alterar a senha!, ocorreu um erro na operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel alterar a senha, Sua nova senha deve ser diferente da atual!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar a senha, pois sua senha atual não é igual a senha digitada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tb_senha_TextChanged(object sender, EventArgs e)
        {
            lb_aviso.Visible = false;
        }
    }
}
