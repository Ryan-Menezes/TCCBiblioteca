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

namespace BibliotecaEtec
{
    public partial class F_EnviaMensagem : Form
    {
        private string codigo = string.Empty; //Codigo do usuário
        private string tipoUser = string.Empty;

        public F_EnviaMensagem(string codigo, string tipoUser)
        {
            InitializeComponent();
            this.codigo = codigo;
            this.tipoUser = tipoUser;
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            if(tb_titulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Digite o titulo da mensagem que deseja enviar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_titulo.Focus();
                return;
            }

            if (tb_mensagem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Digite a mensagem que deseja enviar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_mensagem.Focus();
                return;
            }

            //Enviando mensagem

            MySqlConnection conexao = BCO.conexaoBCO();
            var cmd = conexao.CreateCommand();

            try
            {
                cmd.CommandText = "INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES (@titulo, @msg, 'N', CURDATE(), @idU, @idA)";
                cmd.Parameters.AddWithValue("@titulo", tb_titulo.Text.Trim());
                cmd.Parameters.AddWithValue("@msg", tb_mensagem.Text.Trim());
                cmd.Parameters.AddWithValue("@idU", codigo);
                cmd.Parameters.AddWithValue("@idA", UsuarioLogado.codUsuario);
                cmd.ExecuteNonQuery();

                tb_titulo.Clear();
                tb_mensagem.Clear();
                MessageBox.Show("Mensagem enviada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar a mensagem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.Close();
                this.Close();
            }
        }

        private void F_EnviaMensagem_Load(object sender, EventArgs e)
        {
            MySqlConnection conexao = BCO.conexaoBCO();
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var cmd = conexao.CreateCommand();

            try
            {
                if(tipoUser == "A")
                {
                    dt = BCO.Dql(String.Format("SELECT nome, sobrenome, img_aluno FROM aluno WHERE id_usuario_aluno = {0} LIMIT 1", codigo));
                }
                else if (tipoUser == "P")
                {
                    dt = BCO.Dql(String.Format("SELECT nome, sobrenome, img_professor FROM professor WHERE id_usuario_professor = {0} LIMIT 1", codigo));
                }
                else
                {
                    dt = BCO.Dql(String.Format("SELECT nome, sobrenome, img_funcionario FROM funcionario WHERE id_usuario_funcionario = {0} LIMIT 1", codigo));
                }

                //Covertendo imagem

                byte[] img = (byte[])dt.Rows[0].ItemArray[2];

                MemoryStream ms = new MemoryStream(img);

                img_perfil.Image = System.Drawing.Image.FromStream(ms);

                lb_info.Text = dt.Rows[0].ItemArray[0].ToString() + " " + dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar o formulário da mensagem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
