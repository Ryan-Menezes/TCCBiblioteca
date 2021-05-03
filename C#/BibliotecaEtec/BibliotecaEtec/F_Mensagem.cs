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
    public partial class F_Mensagem : Form
    {
        private string codigo = string.Empty; //Codigo da mensagem

        public F_Mensagem(string codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
        }

        private void F_Mensagem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = BCO.Dql(String.Format("SELECT a.titulo, a.mensagem, a.data_envio, p.nome, p.sobrenome, p.img_professor FROM avisos AS a INNER JOIN professor AS p ON p.id_usuario_professor = a.id_usuarioRemetente_avisos WHERE a.id_usuario_avisos = {0} AND a.id_aviso = {1} LIMIT 1", UsuarioLogado.codUsuario, codigo));

                //Covertendo imagem

                byte[] img = (byte[])dt.Rows[0].ItemArray[5];

                MemoryStream ms = new MemoryStream(img);

                img_perfil.Image = System.Drawing.Image.FromStream(ms);

                lb_info.Text = dt.Rows[0].ItemArray[3].ToString() + " " + dt.Rows[0].ItemArray[4].ToString() + " - " + Convert.ToDateTime(dt.Rows[0].ItemArray[2]).ToString("dd/MM/yyyy");

                lb_titulo.Text = dt.Rows[0].ItemArray[0].ToString();

                tb_mensagem.Text = dt.Rows[0].ItemArray[1].ToString();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar a mensagem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
