using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca01
{
    public partial class F_Livro : Form
    {
        public F_Livro()
        {
            InitializeComponent();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_cad_livro_Click(object sender, EventArgs e)
        {
            F_CadLivro f_CadLivro = new F_CadLivro();
            f_CadLivro.ShowDialog();
        }

        private void F_Livro_Load(object sender, EventArgs e)
        {
            dgv_livro.DataSource = BCO.mostrar_livro();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();

            if (txt_pesquisar.Text != "")
            {
                livro.pesquisa_tombo = Convert.ToInt64(txt_pesquisar.Text);
                dgv_livro.DataSource = BCO.pesquisar_Tombo(livro);
            }

            if (txt_pesquisa_neutra.Text != "")
            {
                livro.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_livro.DataSource = BCO.pesquisar_neutra_Livro(livro);
            }

            if (txt_pesquisar.Text != "" && txt_pesquisa_neutra.Text != "")
            {
                livro.pesquisa_tombo = Convert.ToInt64(txt_pesquisar.Text);
                livro.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_livro.DataSource = BCO.pesquisar_avançada_Livro(livro);
            }
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            dgv_livro.DataSource = BCO.mostrar_livro();
        }

        private void btn_relatorio_livro_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog salvararq = new SaveFileDialog();
                salvararq.Filter = "Arquivo PDF | *.pdf";
                salvararq.ShowDialog();
                // if(string.IsNullOrEmpty(salvararq.FileName)== false)

                string nome_arquivo = salvararq.FileName;
                FileStream arquivo_Pdf = new FileStream(nome_arquivo, FileMode.Create);
                Document doc = new Document(PageSize.A1);
                PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivo_Pdf);

                string dados = "";
                string textoPdf = "Relátorio Livros";
                Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 15, (int)System.Drawing.FontStyle.Bold));
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(textoPdf + "\n\n");

                PdfPTable tabela = new PdfPTable(10);
                tabela.DefaultCell.FixedHeight = 20;

                PdfPCell celula = new PdfPCell(new Phrase("Tombo"));
                tabela.AddCell("Tombo");
                tabela.AddCell("Titulo");
                tabela.AddCell("Publicacao");
                tabela.AddCell("Volume");
                tabela.AddCell("Edicao\n\n");
                tabela.AddCell("Insercao");
                tabela.AddCell("Idioma");
                tabela.AddCell("Genero");
                tabela.AddCell("Autor");
                tabela.AddCell("Editora\n\n");

                DataTable dtLivros = BCO.mostrar_livro();
                for (int i = 0; i < dtLivros.Rows.Count; i++)
                {
                    tabela.AddCell(dtLivros.Rows[i].Field<Int32>("Tombo").ToString());
                    tabela.AddCell(dtLivros.Rows[i].Field<string>("Titulo"));
                    tabela.AddCell(dtLivros.Rows[i].Field<DateTime>("Publicacao").ToString());
                    tabela.AddCell(dtLivros.Rows[i].Field<Int32>("Volume").ToString());
                    tabela.AddCell(dtLivros.Rows[i].Field<Int32>("Edicao").ToString());
                    tabela.AddCell(dtLivros.Rows[i].Field<DateTime>("Insercao").ToString());
                    tabela.AddCell(dtLivros.Rows[i].Field<string>("Idioma"));
                    tabela.AddCell(dtLivros.Rows[i].Field<string>("Genero"));
                    tabela.AddCell(dtLivros.Rows[i].Field<string>("Autor"));
                    tabela.AddCell(dtLivros.Rows[i].Field<string>("Editora"));              

                }

                doc.Open();
                doc.Add(paragrafo);
                doc.Add(tabela);
                doc.Close();

                DialogResult resp = MessageBox.Show("Deseja abrir o Relatório ?", "Relatório", MessageBoxButtons.YesNo);
                if (resp == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(nome_arquivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
    }
}
