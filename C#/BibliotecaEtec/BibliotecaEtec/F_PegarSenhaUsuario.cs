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
using System.Security.Cryptography;

namespace BibliotecaEtec
{
    public partial class F_PegarSenhaUsuario : Form
    {
        F_Alunos formularioA = null;
        F_Professores formularioP = null;
        F_Funcionarios formularioF = null;
        string codUsuario = string.Empty;
        string codInstituicao = string.Empty;

        public F_PegarSenhaUsuario(F_Alunos fa, F_Professores fp, F_Funcionarios ff, string cod, string codI)
        {
            InitializeComponent();

            formularioA = fa;
            formularioP = fp;
            formularioF = ff;
            codUsuario = cod;
            codInstituicao = codI;

            if (formularioA != null)
            {
                btn_deletar.Text = "Deletar Aluno";
            }
            else if (formularioP != null)
            {
                btn_deletar.Text = "Deletar Professor";
            }
            else
            {
                btn_deletar.Text = "Deletar Funcionário";
            }
        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (tb_senha.Text.Trim().Length > 0)
            {
                //Criptografando senha digitada

                string senha = string.Empty;

                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(tb_senha.Text));

                foreach (byte b in hash)
                {
                    senha += b.ToString("x2");
                }

                //Verificando senha

                if (senha == UsuarioLogado.senha)
                {
                    MySqlConnection conBCO = BCO.conexaoBCO();

                    try
                    {
                        MySqlDataAdapter da = null;
                        DataTable dt = new DataTable();
                        var cmd = conBCO.CreateCommand();

                        //Verificando se este usuário está envolvido com alguma alocação

                        cmd.CommandText = "SELECT * FROM locacao AS l INNER JOIN exemplares AS e ON e.id_exemplares = l.id_exemplares WHERE id_usuario_locacao = " + codUsuario + " OR id_usuarioAdimin_locacao = " + codUsuario + " AND e.id_instituicao = " + codInstituicao + " LIMIT 1";
                        da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                        da.Fill(dt);

                        if(dt.Rows.Count == 0)
                        {
                            //Deletendo instituições do usuário

                            cmd.CommandText = "DELETE FROM instituicao_usuario WHERE id_instituicao = " + codInstituicao + " AND id_usuario = " + codUsuario;

                            cmd.ExecuteNonQuery();

                            //Buscando cursos do usuário

                            cmd.CommandText = "SELECT ca.id_curso_usuario FROM curso_usuario AS ca INNER JOIN curso AS c ON ca.curso_id_curso = c.id_curso INNER JOIN instituicao AS i ON i.id_instituicao = c.id_instituicao_curso WHERE i.id_instituicao = " + codInstituicao + " AND ca.usuario_id_usuario = " + codUsuario;
                            da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                            da.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                cmd.CommandText = String.Format("DELETE FROM curso_usuario WHERE id_curso_usuario = {0} LIMIT 1", dt.Rows[i].Field<Int32>("id_curso_usuario").ToString());

                                cmd.ExecuteNonQuery();
                            }

                            //Verificando todos os cursos e instituições do usuário

                            DataTable dataI = new DataTable();
                            DataTable dataC = new DataTable();

                            //Cursos

                            cmd.CommandText = "SELECT id_instituicao_usuario FROM instituicao_usuario WHERE id_usuario = " + codUsuario + " LIMIT 1";
                            da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                            da.Fill(dataI);

                            //Instituição

                            cmd.CommandText = "SELECT ca.id_curso_usuario FROM curso_usuario AS ca INNER JOIN curso AS c ON ca.curso_id_curso = c.id_curso INNER JOIN instituicao AS i ON i.id_instituicao = c.id_instituicao_curso WHERE ca.usuario_id_usuario = " + codUsuario + " LIMIT 1";
                            da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                            da.Fill(dataC);

                            if(dataI.Rows.Count == 0 && dataC.Rows.Count == 0)
                            {
                                //Deletando usuario por completo

                                cmd.CommandText = "DELETE FROM usuario WHERE id_usuario = " + codUsuario + " LIMIT 1";

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Usuário deletado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if(formularioA != null)
                            {
                                formularioA.dgv_alunos.Rows.Clear();
                                formularioA.carregarMais();
                            }
                            else if (formularioP != null)
                            {
                                formularioP.dgv_professores.Rows.Clear();
                                formularioP.carregarMais();
                            }
                            else
                            {
                                formularioF.dgv_funcionarios.Rows.Clear();
                                formularioF.carregarMais();
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Este usuário está devendo alguns livros a biblioteca ou está associado a alguma alocação feita, portanto não é possivel deletá-lo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Usuário não deletado, Ocorreu um erro na operação de exclusão", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conBCO.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Senha inválida, não foi possivel deletar o usuário", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                lb_senha.Visible = true;
            }
        }

        private void tb_senha_TextChanged(object sender, EventArgs e)
        {
            lb_senha.Visible = false;
        }
    }
}
