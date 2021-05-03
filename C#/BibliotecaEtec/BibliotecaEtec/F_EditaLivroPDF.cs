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
using System.IO;
using System.Drawing.Drawing2D;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using Biblioteca01;
using System.Net;
using System.Collections.Specialized;

namespace BibliotecaEtec
{
    public partial class F_EditaLivroPDF : Form
    {
        public List<string> generos = new List<string>();
        public List<string> autores = new List<string>();

        private string imagemCap = string.Empty;
        private string pdfCaminho = string.Empty;
        private byte[] imgCarregado = null;

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

        private string nomePdf = null;
        private string codigoLivro = string.Empty;
        private string codigoExemplares = string.Empty;
        private F_Livros formulario = null;

        InputsTextBox[] inputsTextBox = new InputsTextBox[3];
        IputsListBox[] inputsListBox = new IputsListBox[2];

        public F_EditaLivroPDF(string codigoL, F_Livros f)
        {
            InitializeComponent();

            this.codigoLivro = codigoL;
            this.formulario = f;

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

            //Buscando dados do livro

            DataTable dt = BCO.Dql("SELECT l.tombo, l.titulo, l.ano_publicacao, l.volume, l.edicao, l.isbn, l.idioma, l.img_livro, l.pdf_livro FROM livro AS l WHERE l.cod_livro = " + this.codigoLivro + " AND l.tombo IS NULL LIMIT 1");

            if (dt.Rows.Count > 0)
            {
                this.imgCarregado = dt.Rows[0].Field<byte[]>("img_livro");
                this.nomePdf = dt.Rows[0].Field<string>("pdf_livro");

                img_capa.Image = System.Drawing.Image.FromStream(new MemoryStream(imgCarregado));
                txt_titulo.Text = dt.Rows[0].Field<string>("titulo");
                dtp_ano_publicacao.Value = dt.Rows[0].Field<DateTime>("ano_publicacao");
                txt_volume.Value = Convert.ToDecimal(dt.Rows[0].Field<Int32>("volume"));
                txt_edicao.Value = Convert.ToDecimal(dt.Rows[0].Field<Int32>("edicao"));
                tb_idioma.Text = dt.Rows[0].Field<string>("idioma");
                tb_pdfCaminho.Text = this.nomePdf;

                //Buscando generos

                dt = BCO.Dql("SELECT g.id_genero, g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = " + this.codigoLivro);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    generos.Add(dt.Rows[i].ItemArray[0].ToString());
                    list_generos.Items.Add(dt.Rows[i].ItemArray[1].ToString());
                }

                //Buscando autores

                dt = BCO.Dql("SELECT a.id_autor, a.nome_autor FROM autor AS a INNER JOIN autor_livro AS al ON al.id_autor_tombo = a.id_autor WHERE al.id_livro_tombo = " + this.codigoLivro);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    autores.Add(dt.Rows[i].ItemArray[0].ToString());
                    list_autores.Items.Add(dt.Rows[i].ItemArray[1].ToString());
                }
            }
            else
            {
                this.Close();
            }
        }

        private void img_capa_Click(object sender, EventArgs e)
        {
            DialogResult res = pegarImagem.ShowDialog();

            if (res == DialogResult.OK)
            {
                Bitmap img = new Bitmap(pegarImagem.FileName);
                img_capa.Image = img;
                imagemCap = pegarImagem.FileName.ToString();
            }
            else
            {
                img_capa.Image = System.Drawing.Image.FromStream(new MemoryStream(imgCarregado)); ;
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
                tb_pdfCaminho.Text = this.nomePdf;
                pdfCaminho = string.Empty;
            }
        }

        private bool verificaCampos()
        {
            bool verifica = true;

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

        private void btn_editar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = BCO.conexaoBCO();
            var cmd = conexao.CreateCommand();

            if (verificaCampos())
            {
                //Verficando se os arquivos existem

                if (!File.Exists(this.imagemCap))
                {
                    this.imagemCap = string.Empty;
                }

                if (!File.Exists(this.pdfCaminho))
                {
                    this.pdfCaminho = string.Empty;
                }

                //Verificando tamanho da imagem

                long tamanho = (imagemCap.Length > 0) ? new System.IO.FileInfo(this.imagemCap).Length : 1;

                if (tamanho <= 1048576)
                {
                    try
                    {
                        if (pdfCaminho.Length > 0)
                        {
                            //Deletando arquivo antigo

                            WebClient web = new WebClient();

                            NameValueCollection dados = new NameValueCollection();
                            dados.Add("arquivo", nomePdf);
                            dados.Add("code", "Excluir");

                            web.UploadValues(Globais.url + "CSharpPHP/deletaPDF.php", "POST", dados);

                            //Adicionando novo arquivo

                            this.nomePdf = string.Empty;

                            MD5 md5 = MD5.Create();
                            Random rad = new Random();

                            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(rad.Next(0, 1000).ToString() + rad.Next(0, 1000).ToString() + rad.Next(0, 1000).ToString() + rad.Next(0, 1000).ToString() + DateTime.Today.ToString("dd/MM/yyyy")));

                            foreach (byte b in hash)
                            {
                                this.nomePdf += b.ToString("x2");
                            }

                            this.nomePdf += ".pdf";

                            web.UploadFile(Globais.url + "CSharpPHP/UploadPDF.php?a=" + this.nomePdf + "&cod=" + this.codigoLivro, this.pdfCaminho);
                        }

                        //Editando livro

                        if (imagemCap.Length > 0)
                        {
                            FileStream fs = new FileStream(imagemCap, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);

                            byte[] img = br.ReadBytes((int)fs.Length);

                            cmd.CommandText = "UPDATE livro SET titulo = @titulo, ano_publicacao = @data, volume = @volume, edicao = @edicao, idioma = @idioma, img_livro = @img, pdf_livro = @pdf WHERE cod_livro = @cod LIMIT 1";
                            cmd.Parameters.AddWithValue("@titulo", txt_titulo.Text.Trim());
                            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtp_ano_publicacao.Value.ToString()).ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@volume", txt_volume.Text.Trim());
                            cmd.Parameters.AddWithValue("@edicao", txt_edicao.Text.Trim());
                            cmd.Parameters.AddWithValue("@idioma", tb_idioma.Text.Trim());
                            cmd.Parameters.AddWithValue("@img", img);
                            cmd.Parameters.AddWithValue("@pdf", this.nomePdf);
                            cmd.Parameters.AddWithValue("@cod", this.codigoLivro);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "UPDATE livro SET titulo = @titulo, ano_publicacao = @data, volume = @volume, edicao = @edicao, idioma = @idioma, pdf_livro = @pdf WHERE cod_livro = @cod LIMIT 1";
                            cmd.Parameters.AddWithValue("@titulo", txt_titulo.Text.Trim());
                            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtp_ano_publicacao.Value.ToString()).ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@volume", txt_volume.Text.Trim());
                            cmd.Parameters.AddWithValue("@edicao", txt_edicao.Text.Trim());
                            cmd.Parameters.AddWithValue("@idioma", tb_idioma.Text.Trim());
                            cmd.Parameters.AddWithValue("@pdf", this.nomePdf);
                            cmd.Parameters.AddWithValue("@cod", this.codigoLivro);
                            cmd.ExecuteNonQuery();
                        }

                        //Deletando editoras, generos e  autores

                        BCO.Dml("DELETE FROM genero_livro WHERE id_livro_tombo = " + codigoLivro);
                        BCO.Dml("DELETE FROM editora_livro WHERE cod_livro = " + codigoLivro);
                        BCO.Dml("DELETE FROM autor_livro WHERE id_livro_tombo = " + codigoLivro);

                        //Editando generos

                        foreach (string genero in generos)
                        {
                            BCO.Dml("INSERT INTO genero_livro (id_genero_tombo, id_livro_tombo) VALUES (" + genero + ", " + codigoLivro + ")");
                        }

                        //Editando autores

                        foreach (string autor in autores)
                        {
                            BCO.Dml("INSERT INTO autor_livro (id_autor_tombo, id_livro_tombo) VALUES (" + autor + ", " + codigoLivro + ")");
                        }

                        MessageBox.Show("Livro editado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Recarregar imagem preview

                        if (this.imagemCap.Length > 0)
                        {
                            if (File.Exists(this.imagemCap))
                            {
                                FileStream fs = new FileStream(this.imagemCap, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fs);
                                this.imgCarregado = br.ReadBytes((int)fs.Length);
                            }
                        }

                        this.imagemCap = string.Empty;
                        this.pdfCaminho = string.Empty;
                        formulario.dgv_livros.Rows.Clear();
                        formulario.carregarMais();
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possivel finalizar a edição, Ocorreu um erro na edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            F_SelecionaAutor f = new F_SelecionaAutor(null, null, null, this);
            f.ShowDialog();
        }

        private void btn_genero_Click(object sender, EventArgs e)
        {
            F_SelecionaGenero f = new F_SelecionaGenero(null, null, null, this);
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
