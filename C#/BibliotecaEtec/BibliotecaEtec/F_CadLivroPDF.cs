using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    public partial class F_CadLivroPDF : Form
    {
        public List<string> generos = new List<string>();
        public List<string> autores = new List<string>();

        private string imagemCap = string.Empty;
        private string pdfCaminho = string.Empty;

        //Estruturas que irão conter os text box/masked text box dos formulários

        public struct InputsTextBox
        {
            public TextBox input;
            public Label label;
        }

        public struct IputsListBox
        {
            public ListBox list;
            public Label label;
        }

        //Instanciação das estruturas acima

        InputsTextBox[] inputsTextBox = new InputsTextBox[3];
        IputsListBox[] inputsListBox = new IputsListBox[2];

        public F_CadLivroPDF()
        {
            InitializeComponent();

            //Textbox

            inputsTextBox[0].input = txt_titulo;
            inputsTextBox[0].label = lb_titulo;

            inputsTextBox[1].input = tb_idioma;
            inputsTextBox[1].label = lb_idioma;

            inputsTextBox[2].input = tb_pdfCaminho;
            inputsTextBox[2].label = lb_pdf;

            //ListBox

            inputsListBox[0].list = list_generos;
            inputsListBox[0].label = lb_genero;

            inputsListBox[1].list = list_autores;
            inputsListBox[1].label = lb_autor;
        }

        private void img_capa_Click(object sender, EventArgs e)
        {
            DialogResult res = pegarImagem.ShowDialog();

            if (res == DialogResult.OK)
            {
                Bitmap img = new Bitmap(pegarImagem.FileName);
                img_capa.Image = img;
                imagemCap = pegarImagem.FileName.ToString();
                lb_img.Visible = false;
            }
            else
            {
                img_capa.Image = Properties.Resources.ImgAlerta;
                imagemCap = string.Empty;
            }
        }

        private void btn_pegaPDF_Click(object sender, EventArgs e)
        {
            DialogResult res = pegarPDF.ShowDialog();

            if (res == DialogResult.OK)
            {
                tb_pdfCaminho.Text = pegarPDF.SafeFileName;
                pdfCaminho = pegarPDF.FileName;
            }
            else
            {
                tb_pdfCaminho.Clear();
                pdfCaminho = string.Empty;
            }
        }

        private bool verificaCampos()
        {
            bool verifica = true;

            //Verficando imagem

            if (imagemCap.Length == 0)
            {
                lb_img.Visible = true;
                verifica = false;
            }

            //Verificando text box

            for (int i = 0; i < inputsTextBox.Length; i++)
            {
                if (inputsTextBox[i].input.Text.Trim().Length == 0)
                {
                    inputsTextBox[i].label.Visible = true;
                    verifica = false;
                }
            }

            //Verificando Listas

            for (int i = 0; i < inputsListBox.Length; i++)
            {
                if (inputsListBox[i].list.Items.Count == 0)
                {
                    inputsListBox[i].label.Visible = true;
                    verifica = false;
                }
            }

            return verifica;
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                Livro livro = new Livro();
                long tamanho = new System.IO.FileInfo(imagemCap).Length;

                if (tamanho <= 1048576)
                {
                    if (imagemCap.Length > 0)
                    {
                        //Convertendo a imagem para binario

                        FileStream fs = new FileStream(imagemCap, FileMode.Open, FileAccess.Read);

                        BinaryReader br = new BinaryReader(fs);

                        livro.img_livro = br.ReadBytes((int)fs.Length);
                    }

                    livro.pdf = string.Empty;

                    if (tb_pdfCaminho.Text.Trim().Length > 0 && pdfCaminho.Length > 0)
                    {
                        MD5 md5 = MD5.Create();
                        Random rad = new Random();

                        string palavraHash = rad.Next(0, 1000).ToString() + rad.Next(0, 1000).ToString() + rad.Next(0, 1000).ToString() + rad.Next(0, 1000).ToString() + DateTime.Today.ToString("dd/MM/yyyy");
                        string nomeHash = string.Empty;

                        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(palavraHash));

                        foreach (byte h in hash)
                        {
                            nomeHash += h.ToString("x2");
                        }

                        nomeHash += ".pdf";

                        livro.pdf = nomeHash;
                        livro.pdfCaminho = pdfCaminho;
                    }

                    livro.tombo = null;
                    livro.titulo = txt_titulo.Text.Trim();
                    livro.ano_publicacao = Convert.ToDateTime(dtp_ano_publicacao.Value).ToString("yyyy-MM-dd");
                    livro.volume = (txt_volume.Value > 0) ? txt_volume.Value.ToString() : null;
                    livro.edicao = (txt_edicao.Value > 0) ? txt_edicao.Value.ToString() : null;
                    livro.isbn = null;
                    livro.idioma = tb_idioma.Text.Trim();
                    livro.instituicao = null;
                    livro.exemplares = null;
                    livro.generos = generos;
                    livro.editoras = null;
                    livro.autores = autores;

                    if (BCO.cad_livro(livro))
                    {
                        txt_titulo.Clear();
                        dtp_ano_publicacao.Value = DateTime.Today;
                        txt_volume.Value = 0;
                        txt_edicao.Value = 0;
                        tb_idioma.Clear();
                        generos.Clear();
                        autores.Clear();
                        list_generos.Items.Clear();
                        list_autores.Items.Clear();
                        pdfCaminho = string.Empty;
                        tb_pdfCaminho.Clear();
                        imagemCap = string.Empty;
                        img_capa.Image = Properties.Resources.ImgAlerta;
                    }
                }
                else
                {
                    MessageBox.Show("A imagem selecionada é muito grande!, selecione outra imagem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_autor_Click(object sender, EventArgs e)
        {
            F_SelecionaAutor f = new F_SelecionaAutor(null, this, null, null);
            f.ShowDialog();
        }

        private void btn_genero_Click(object sender, EventArgs e)
        {
            F_SelecionaGenero f = new F_SelecionaGenero(null, this, null, null);
            f.ShowDialog();
        }

        private void list_autores_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list_autores.SelectedIndex >= 0)
            {
                autores.RemoveAt(list_autores.SelectedIndex);
                list_autores.Items.RemoveAt(list_autores.SelectedIndex);
            }
        }

        private void list_generos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list_generos.SelectedIndex >= 0)
            {
                generos.RemoveAt(list_generos.SelectedIndex);
                list_generos.Items.RemoveAt(list_generos.SelectedIndex);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            for (int i = 0; i < inputsTextBox.Length; i++)
            {
                if (tb == inputsTextBox[i].input)
                {
                    inputsTextBox[i].label.Visible = false;
                }
            }
        }

        private void list_cursos_Enter(object sender, EventArgs e)
        {
            ListBox tb = (ListBox)sender;

            for (int i = 0; i < inputsListBox.Length; i++)
            {
                if (tb == inputsListBox[i].list)
                {
                    inputsListBox[i].label.Visible = false;
                }
            }
        }
    }
}
