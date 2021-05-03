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
using System.Net;
using System.Collections.Specialized;

namespace BibliotecaEtec
{
    public partial class F_PegarSenha : Form
    {
        private string exemplares = string.Empty;
        private string codLivro = string.Empty;
        F_Livros formulario = null;

        public F_PegarSenha(F_Livros f, string cod_exemplares, string cod_livro)
        {
            InitializeComponent();

            exemplares = cod_exemplares;
            codLivro = cod_livro;
            formulario = f;
        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if(tb_senha.Text.Trim().Length > 0)
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
                    var conBCO = BCO.conexaoBCO();

                    try
                    {
                        MySqlDataAdapter da = null;
                        DataTable data = new DataTable();

                        //Verificando se este livro está envolvido com alguma alocação

                        var cmd = conBCO.CreateCommand();

                        cmd.CommandText = "SELECT * FROM locacao WHERE id_exemplares = '" + exemplares + "' LIMIT 1";
                        da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                        da.Fill(data);

                        if (data.Rows.Count == 0)
                        {
                            data.Clear();

                            //Deletando exemplares

                            cmd.CommandText = "DELETE FROM exemplares WHERE id_exemplares = '" + exemplares + "' LIMIT 1";
                            cmd.ExecuteNonQuery();

                            //Pesquisando exemplares

                            cmd.CommandText = "SELECT * FROM locacao WHERE id_exemplares = '" + exemplares + "' LIMIT 1";
                            da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                            da.Fill(data);

                            if (data.Rows.Count == 0)
                            {
                                //Pegando pdf do livro

                                DataTable dt = new DataTable();

                                cmd.CommandText = "SELECT pdf_livro FROM livro WHERE cod_livro = '" + codLivro + "' LIMIT 1";
                                da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                                da.Fill(dt);

                                string pdf = dt.Rows[0].ItemArray[0].ToString();

                                //Deletando livro

                                cmd.CommandText = "DELETE FROM livro WHERE cod_livro = '" + codLivro + "' LIMIT 1";
                                cmd.ExecuteNonQuery();

                                //Deletando pdf do livro

                                if (pdf.Length > 0)
                                {
                                    WebClient client = new WebClient();

                                    NameValueCollection dados = new NameValueCollection();
                                    dados.Add("arquivo", pdf);

                                    client.UploadValues(Globais.url + "CSharpPHP/deletaPDF.php", "POST", dados);
                                }
                            }

                            MessageBox.Show("Livro deletado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            formulario.dgv_livros.Rows.Clear();
                            formulario.carregarMais();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Este livro tem algumas cópias alocadas, no momento não é possivel deletá-lo!, caso seja preciso, você deve encerrar todas essas alocações envolvendo este livro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Livro não deletado, Ocorreu um erro na operação de exclusão", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conBCO.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Senha inválida, não foi possivel deletar o livro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
