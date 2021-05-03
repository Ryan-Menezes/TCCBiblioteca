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
    public partial class F_Funcionario : Form
    {
        public F_Funcionario()
        {
            InitializeComponent();
        }

        private void btn_cad_funcionario_Click(object sender, EventArgs e)
        {
            F_CadFuncionario f_CadFuncionario = new F_CadFuncionario();
            f_CadFuncionario.ShowDialog();
        }

        private void F_Funcionario_Load(object sender, EventArgs e)
        {
            dgv_funcionario.DataSource = BCO.mostrar_Funcionario();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();


            if (txt_pesquisar.Text != "")
            {
                funcionario.pesquisa_rm_Funcionario = Convert.ToInt64(txt_pesquisar.Text);
                dgv_funcionario.DataSource = BCO.pesquisar_Funcionario(funcionario);
            }

            if (txt_pesquisa_neutra.Text != "")
            {
                funcionario.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_funcionario.DataSource = BCO.pesquisa_neutra_Funcionario(funcionario);
            }

            if (txt_pesquisar.Text != "" && txt_pesquisa_neutra.Text != "")
            {
                funcionario.pesquisa_rm_Funcionario = Convert.ToInt32(txt_pesquisar.Text);
                funcionario.pesquisa_neutra = txt_pesquisa_neutra.Text;
                dgv_funcionario.DataSource = BCO.pesquisa_elaborada_Funcionario(funcionario);
            }


            //funcionario.pesquisa_rm_Funcionario = Convert.ToInt32(txt_pesquisar.Text);
            // dgv_funcionario.DataSource = BCO.filtrar_funcionario(funcionario);
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            dgv_funcionario.DataSource = BCO.mostrar_Funcionario();
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
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
                string textoPdf = "Relátorio Funcionários";
                Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 15, (int)System.Drawing.FontStyle.Bold));
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(textoPdf + "\n\n");

                PdfPTable tabela = new PdfPTable(10);
                tabela.DefaultCell.FixedHeight = 20;

                PdfPCell celula = new PdfPCell(new Phrase("Rm"));
                tabela.AddCell("Rm Funcionario");
                tabela.AddCell("Acesso");
                tabela.AddCell("Status");
                tabela.AddCell("Nome");
                tabela.AddCell("Sobrenome\n\n");
                tabela.AddCell("Cpf");
                tabela.AddCell("Sexo");
                tabela.AddCell("Data Cadastro");
                tabela.AddCell("Cod Etec");
                tabela.AddCell("Situacao\n\n");

                DataTable dtFuncionario = BCO.mostrar_Funcionario();
                for (int i = 0; i < dtFuncionario.Rows.Count; i++)
                {
                    tabela.AddCell(dtFuncionario.Rows[i].Field<Int32>("Rm Funcionario").ToString());
                    tabela.AddCell(dtFuncionario.Rows[i].Field<string>("Acesso"));
                    tabela.AddCell(dtFuncionario.Rows[i].Field<string>("Status"));
                    tabela.AddCell(dtFuncionario.Rows[i].Field<string>("Nome"));
                    tabela.AddCell(dtFuncionario.Rows[i].Field<string>("Sobrenome"));
                    tabela.AddCell(dtFuncionario.Rows[i].Field<string>("Cpf"));
                    tabela.AddCell(dtFuncionario.Rows[i].Field<string>("Sexo"));
                    tabela.AddCell(dtFuncionario.Rows[i].Field<DateTime>("Data Cadastro").ToString());
                    tabela.AddCell(dtFuncionario.Rows[i].Field<Int32>("Cod Etec").ToString());
                    tabela.AddCell(dtFuncionario.Rows[i].Field<string>("Situacao").ToString());

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
