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
    public partial class F_Professor : Form
    {
        public F_Professor()
        {
            InitializeComponent();
        }

        private void btn_cad_professor_Click(object sender, EventArgs e)
        {
            F_CadProfessor f_CadProfessor = new F_CadProfessor();
            f_CadProfessor.ShowDialog();
        }

        private void F_Professor_Load(object sender, EventArgs e)
        {
            dgv_professor.DataSource = BCO.mostrar_professor();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            // Aluno aluno = new Aluno();
            Professor professor = new Professor();


            if (txt_pesquisar.Text != "")
            {
                professor.pesquisa_rm_Professor = Convert.ToInt64(txt_pesquisar.Text);
                dgv_professor.DataSource = BCO.pesquisar_Professor(professor);
            }

            if (txt_pesquisa_neutra.Text != "")
            {
                professor.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_professor.DataSource = BCO.pesquisa_neutra_Professor(professor);
            }

            if (txt_pesquisar.Text != "" && txt_pesquisa_neutra.Text != "")
            {
                professor.pesquisa_rm_Professor = Convert.ToInt32(txt_pesquisar.Text);
                professor.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_professor.DataSource = BCO.pesquisa_elaborada_Professor(professor);
            }

           // professor.pesquisa_rm_Professor = Convert.ToInt32(txt_pesquisar.Text);         
           // dgv_professor.DataSource = BCO.filtrar_Professor(professor);
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            dgv_professor.DataSource = BCO.mostrar_professor();
        }

        private void btn_relatorio_professor_Click(object sender, EventArgs e)
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
                string textoPdf = "Relátorio Professores";
                Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 15, (int)System.Drawing.FontStyle.Bold));
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(textoPdf + "\n\n");

                PdfPTable tabela = new PdfPTable(13);
                tabela.DefaultCell.FixedHeight = 20;          

                PdfPCell celula = new PdfPCell(new Phrase("Rm"));
                tabela.AddCell("Rm Professor");
                tabela.AddCell("Acesso");
                tabela.AddCell("Status");
                tabela.AddCell("Nome");
                tabela.AddCell("Sobrenome\n\n");
                tabela.AddCell("Cpf");
                tabela.AddCell("Sexo");
                tabela.AddCell("Data Cadastro");
                tabela.AddCell("Sede");
                tabela.AddCell("Id do Curso");
                tabela.AddCell("Curso");
                tabela.AddCell("Cod Etec");
                tabela.AddCell("Situacao\n\n");

                DataTable dtProfessor = BCO.mostrar_professor();
                for (int i = 0; i < dtProfessor.Rows.Count; i++)
                {
                    tabela.AddCell(dtProfessor.Rows[i].Field<Int32>("Rm Professor").ToString());
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Acesso"));
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Status"));
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Nome"));
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Sobrenome"));
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Cpf"));
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Sexo"));
                    tabela.AddCell(dtProfessor.Rows[i].Field<DateTime>("Data Cadastro").ToString());
                    tabela.AddCell(dtProfessor.Rows[i].Field<Int32>("Sede").ToString());
                    tabela.AddCell(dtProfessor.Rows[i].Field<Int32>("Id do Curso").ToString());
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Curso"));
                    tabela.AddCell(dtProfessor.Rows[i].Field<Int32>("Cod Etec").ToString());
                    tabela.AddCell(dtProfessor.Rows[i].Field<string>("Situacao").ToString());

                    doc.Open();
                    doc.Add(paragrafo);
                    doc.Add(tabela);
                    //  doc.Add(tabela1);
                    doc.Close();

                    DialogResult resp = MessageBox.Show("Deseja abrir o Relatório ?", "Relatório", MessageBoxButtons.YesNo);
                    if (resp == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(nome_arquivo);
                    }

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
