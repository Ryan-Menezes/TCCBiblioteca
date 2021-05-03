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
    public partial class F_Cursos : Form
    {
        public F_Cursos()
        {
            InitializeComponent();
        }

        private void btn_cad_curso_Click(object sender, EventArgs e)
        {
            F_CadCursos f_CadCursos = new F_CadCursos();
            f_CadCursos.ShowDialog();
        }

        private void F_Cursos_Load(object sender, EventArgs e)
        {
            dgv_cursos.DataSource = BCO.mostrar_Cursos();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();

            if (txt_pesquisar.Text != "")
            {
                curso.pesquisa_curso = Convert.ToInt64(txt_pesquisar.Text);
                dgv_cursos.DataSource = BCO.pesquisa_Cursos(curso);
            }

            if (txt_pesquisa_neutra.Text != "")
            {
                curso.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_cursos.DataSource = BCO.pesquisa_neutra_Cursos(curso);
            }

            if (txt_pesquisar.Text != "" && txt_pesquisa_neutra.Text != "")
            {
                curso.pesquisa_curso = Convert.ToInt32(txt_pesquisar.Text);
                curso.pesquisa_neutra = txt_pesquisa_neutra.Text;

                dgv_cursos.DataSource = BCO.pesquisa_elaborada_Cursos(curso);
            }
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            dgv_cursos.DataSource = BCO.mostrar_Cursos();
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog salvararq = new SaveFileDialog();
                salvararq.Filter = "Arquivo PDF | *.pdf";
                salvararq.ShowDialog();         

                string nome_arquivo = salvararq.FileName;
                FileStream arquivo_Pdf = new FileStream(nome_arquivo, FileMode.Create);
                Document doc = new Document(PageSize.A1);
                PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivo_Pdf);

                string dados = "";
                string textoPdf = "Relátorio Cursos";
                Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 15, (int)System.Drawing.FontStyle.Bold));
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(textoPdf + "\n\n");

                PdfPTable tabela = new PdfPTable(7);
                tabela.DefaultCell.FixedHeight = 20;

                PdfPCell celula = new PdfPCell(new Phrase("Curso"));
                tabela.AddCell("Curso");        
                tabela.AddCell("Modulos");
                tabela.AddCell("Periodo");
                tabela.AddCell("Turma");
                tabela.AddCell("Tipo\n\n");
                tabela.AddCell("Instituicao");
                tabela.AddCell("Cod Curso\n\n");

                DataTable dtCursos = BCO.mostrar_Cursos();
                for (int i = 0; i < dtCursos.Rows.Count; i++)
                {
                    tabela.AddCell(dtCursos.Rows[i].Field<string>("Curso").ToString());
                    tabela.AddCell(dtCursos.Rows[i].Field<string>("Modulos").ToString());
                    tabela.AddCell(dtCursos.Rows[i].Field<string>("Periodo").ToString());
                    tabela.AddCell(dtCursos.Rows[i].Field<string>("Turma").ToString());
                    tabela.AddCell(dtCursos.Rows[i].Field<string>("Tipo").ToString());
                    tabela.AddCell(dtCursos.Rows[i].Field<Int32>("Instituicao").ToString());
                    tabela.AddCell(dtCursos.Rows[i].Field<Int32>("Cod Curso").ToString());

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
