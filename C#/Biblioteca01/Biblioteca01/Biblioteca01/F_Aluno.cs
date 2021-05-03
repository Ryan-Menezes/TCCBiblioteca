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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Biblioteca01
{
    public partial class F_Aluno : Form
    {
        public F_Aluno()
        {
            InitializeComponent();
        }

        private void btn_cad_aluno_Click(object sender, EventArgs e)
        {
            F_CadAluno f_CadAluno = new F_CadAluno();
            f_CadAluno.ShowDialog();
        }

        private void F_Aluno_Load(object sender, EventArgs e)
        {
            dgv_aluno.DataSource = BCO.mostrarAluno();

        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

          
            if(txt_pesquisar.Text != "")
            {
                aluno.pesquisa_rm_Aluno = Convert.ToInt64(txt_pesquisar.Text);
                dgv_aluno.DataSource = BCO.pesquisa_Aluno(aluno);
            }

            if (txt_pesquisa_neutra.Text != "")
            {
                aluno.pesquisa_neutra =  txt_pesquisa_neutra.Text;
                dgv_aluno.DataSource = BCO.pesquisa_neutra_Aluno(aluno);
            }

            if (txt_pesquisar.Text != "" && txt_pesquisa_neutra.Text != "")
            {
                aluno.pesquisa_rm_Aluno = Convert.ToInt32(txt_pesquisar.Text);
                aluno.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_aluno.DataSource = BCO.pesquisa_elaborada_Aluno(aluno);
            }


        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            dgv_aluno.DataSource = BCO.mostrarAluno();
        }

        private void btn_relatorio_aluno_Click(object sender, EventArgs e)
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
                string textoPdf = "Relátorio Alunos";
                Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 15, (int)System.Drawing.FontStyle.Bold));
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(textoPdf + "\n\n");

                PdfPTable tabela = new PdfPTable(10);
                tabela.DefaultCell.FixedHeight = 20;

               // PdfPTable tabela1 = new PdfPTable(8);
               // tabela.DefaultCell.FixedHeight = 20;

                PdfPCell celula = new PdfPCell(new Phrase ("Rm"));
                tabela.AddCell("Rm Aluno");
                tabela.AddCell("Acesso");
                tabela.AddCell("Status");
                tabela.AddCell("Nome");
                tabela.AddCell("Sobrenome\n\n");
                tabela.AddCell("Cpf");
                tabela.AddCell("Sexo");
                tabela.AddCell("Data de Cadastro");
                tabela.AddCell("Cod Curso");
                tabela.AddCell("Cod Etec\n\n");
                // aqui vai para outro paragrafo
              /*  tabela1.AddCell("Telefone");
                tabela1.AddCell("Celular");
                tabela1.AddCell("E-mail");
                tabela1.AddCell("Cep");
                tabela1.AddCell("Logradouro");
                tabela1.AddCell("N");
                tabela1.AddCell("Bairro");
                tabela1.AddCell("Cidade");*/

                DataTable dtAlunos = BCO.mostrarAluno();
                for(int i = 0; i < dtAlunos.Rows.Count; i++)
                {
                    tabela.AddCell(dtAlunos.Rows[i].Field<Int32>("Rm Aluno").ToString());
                    tabela.AddCell(dtAlunos.Rows[i].Field<string>("Acesso"));
                    tabela.AddCell(dtAlunos.Rows[i].Field<string>("Status"));
                    tabela.AddCell(dtAlunos.Rows[i].Field<string>("Nome"));
                    tabela.AddCell(dtAlunos.Rows[i].Field<string>("Sobrenome"));
                    tabela.AddCell(dtAlunos.Rows[i].Field<string>("Cpf"));
                    tabela.AddCell(dtAlunos.Rows[i].Field<string>("Sexo"));
                    tabela.AddCell(dtAlunos.Rows[i].Field<DateTime>("Data de Cadastro").ToString());
                    tabela.AddCell(dtAlunos.Rows[i].Field<Int32>("Cod Curso").ToString());
                    tabela.AddCell(dtAlunos.Rows[i].Field<Int32>("Cod Etec").ToString());

                   /* tabela1.AddCell(dtAlunos.Rows[i].Field<string>("Telefone"));
                    tabela1.AddCell(dtAlunos.Rows[i].Field<string>("Celular"));
                    tabela1.AddCell(dtAlunos.Rows[i].Field<string>("E-mail"));
                    tabela1.AddCell(dtAlunos.Rows[i].Field<string>("Cep"));
                    tabela1.AddCell(dtAlunos.Rows[i].Field<string>("Logradouro"));
                    tabela1.AddCell(dtAlunos.Rows[i].Field<string>("N"));
                    tabela1.AddCell(dtAlunos.Rows[i].Field<string>("Bairro"));
                    tabela1.AddCell(dtAlunos.Rows[i].Field<string>("Cidade")); */

                }
                

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }
    }
}
