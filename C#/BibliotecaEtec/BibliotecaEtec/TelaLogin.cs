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
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Drawing.Drawing2D;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BibliotecaEtec
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, panel6.Width, panel6.Width);
            panel6.Region = new Region(gp);
        }

        private void TelaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Efeito placeholder na textbox da senha

        private void tb_senha_Enter(object sender, EventArgs e)
        {
            if (tb_senha.Text.Trim() == "Senha")
            {
                if(btn_visualizar.IconChar == FontAwesome.Sharp.IconChar.Eye)
                {
                    tb_senha.PasswordChar = '*';
                }

                tb_senha.Clear();
                tb_senha.ForeColor = Color.White;
            }
        }

        private void tb_senha_Leave(object sender, EventArgs e)
        {
            if (tb_senha.Text.Trim().Length == 0)
            {
                tb_senha.PasswordChar = '\0';
                tb_senha.Text = "Senha";
                tb_senha.ForeColor = Color.Gray;
            }
        }

        private void btn_visualizar_Click(object sender, EventArgs e)
        {
            if(btn_visualizar.IconChar == FontAwesome.Sharp.IconChar.Eye)
            {
                tb_senha.PasswordChar = '\0';
                btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                if (tb_senha.Text.Trim() != "Senha")
                {
                    tb_senha.PasswordChar = '*';
                }
                
                btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void tb_rm_Enter(object sender, EventArgs e)
        {
            if (tb_rm.Text.Trim() == "RM")
            {
                tb_rm.Clear();
                tb_rm.ForeColor = Color.White;
            }
        }

        private void tb_rm_Leave(object sender, EventArgs e)
        {
            if (tb_rm.Text.Trim().Length == 0)
            {
                tb_rm.Text = "RM";
                tb_rm.ForeColor = Color.Gray;
            }
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string rm = tb_rm.Text.Trim();
            string senha = tb_senha.Text.Trim();

            bool preenchido = true;

            if(rm.Trim() == "RM")
            {
                lb_rm.Visible = true;
                barra_rm.Visible = true;
                preenchido = false;
            }

            if (senha.Trim() == "Senha")
            {
                lb_senha.Visible = true;
                barra_senha.Visible = true;
                preenchido = false;
            }

            if (preenchido)
            {
                //Criptografando senha digitada

                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));

                senha = string.Empty;

                foreach (byte b in hash)
                {
                    senha += b.ToString("x2");
                }

                //Procurando usuário

                string sql = "SELECT CONCAT(p.nome, CONCAT(' ', p.sobrenome)) AS nome, p.img_professor, p.cpf, u.nivel_acesso, u.senha, u.status_usuario, u.id_usuario FROM usuario AS u INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE p.rm_professor='" + rm + "' AND u.senha='" + senha + "' LIMIT 1";
                dt = BCO.Dql(sql);

                if (dt.Rows.Count == 1)
                {
                    //Verificando se o usuário esta desbloqueado

                    string status = dt.Rows[0].ItemArray[5].ToString();
                    string acesso = dt.Rows[0].ItemArray[3].ToString();

                    if (status == "D")
                    {
                        //Verificando nivel de acesso

                        if(acesso == "A")
                        {
                            //Adicionando os dados na classe UsuarioLogado

                            UsuarioLogado.nomeCompleto = dt.Rows[0].ItemArray[0].ToString();
                            UsuarioLogado.cpf = dt.Rows[0].ItemArray[2].ToString();
                            UsuarioLogado.rm = rm;
                            UsuarioLogado.senha = dt.Rows[0].ItemArray[4].ToString();
                            UsuarioLogado.codUsuario = dt.Rows[0].ItemArray[6].ToString();

                            MySqlConnection conexao = BCO.conexaoBCO();
                            MySqlDataAdapter da = null;
                            DataTable data = new DataTable();
                            var cmd = conexao.CreateCommand();

                            cmd.CommandText = "SELECT i.id_instituicao, i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario as iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = " + UsuarioLogado.codUsuario + " GROUP BY iu.id_instituicao";
                            da = new MySqlDataAdapter(cmd.CommandText, conexao);
                            da.Fill(data);

                            for(int i = 0; i < data.Rows.Count; i++)
                            {
                                UsuarioLogado.instituicoes.Add(data.Rows[i].ItemArray[0].ToString(), data.Rows[i].ItemArray[1].ToString());
                            }

                            //Iniciando formulário

                            Globais.tela.lb_nome_usuario.Text = dt.Rows[0].ItemArray[0].ToString();

                            byte[] imagem = (byte[])(dt.Rows[0].ItemArray[1]);
                            MemoryStream ms = new MemoryStream(imagem);

                            Globais.tela.img_perfil.Image = System.Drawing.Image.FromStream(ms);

                            //Resetando inputs

                            tb_senha.PasswordChar = '\0';
                            tb_senha.Text = "Senha";
                            tb_senha.ForeColor = Color.Gray;

                            tb_rm.Text = "RM";
                            tb_rm.ForeColor = Color.Gray;

                            btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.Eye;

                            //Abrindo tela principal

                            this.Visible = false;
                            Globais.logado = true;
                            Globais.tela.Visible = true;
                            Globais.tela.WindowState = FormWindowState.Maximized;
                            Globais.tela.Show();
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel completar o login, pois este usuário não é um administrador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não é possivel completar o login, pois este usuário está bloqueado pelo sistema!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("RM ou Senha Inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tb_rm_TextChanged(object sender, EventArgs e)
        {
            lb_rm.Visible = false;
            barra_rm.Visible = false;
        }

        private void tb_senha_TextChanged(object sender, EventArgs e)
        {
            lb_senha.Visible = false;
            barra_senha.Visible = false;
        }

        private void lb_esqueciSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Globais.url);
        }
    }
}
