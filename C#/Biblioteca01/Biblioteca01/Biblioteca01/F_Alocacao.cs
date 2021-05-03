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
    public partial class F_Alocacao : Form
    {
        public F_Alocacao()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_alocacao_Click(object sender, EventArgs e)
        {              
            Alocacao alocacao = new Alocacao();

            if (dtp_data_emprestimo.Text == "")
            {
                MessageBox.Show("Digite a data de emprestimo!");
                dtp_data_emprestimo.Focus();
                return;
            }
            alocacao.data_locacao = Convert.ToDateTime(dtp_data_emprestimo.Value).ToString("yyy/MM/dd");

            if (dtp_data_devolucao.Text == "")
            {
                MessageBox.Show("Digite a data de devolução!");
                dtp_data_devolucao.Focus();
                return;
            }
            alocacao.data_devolucao = Convert.ToDateTime(dtp_data_devolucao.Value).ToString("yyy/MM/dd");

            if (nud_tombo_locacao.Text == "")
            {
                MessageBox.Show("Digite o tombo do livro!");
                nud_tombo_locacao.Focus();
                return;
            }
            alocacao.tombo_exemplares = Convert.ToInt32(Math.Round(nud_tombo_locacao.Value, 0));

            if (nud_rm_aluno_locacao.Text == "")
            {
                MessageBox.Show("Digite o rm do usuário!");
                nud_rm_aluno_locacao.Focus();
                return;
            }
            alocacao.rm_usuario = Convert.ToInt32(Math.Round(nud_rm_aluno_locacao.Value, 0));

            if (nud_rm_admin_locacao.Text == "")
            {
                MessageBox.Show("Digite o rm do Admin!");
                nud_rm_admin_locacao.Focus();
                return;
            }
            alocacao.rm_admin= Convert.ToInt32(Math.Round(nud_rm_admin_locacao.Value, 0));


            if (cb_status.Text == "")
            {
                MessageBox.Show("Digite o status da locação!");
                cb_status.Focus();
                return;
            }
            alocacao.situacao = cb_status.Text;
           
            BCO.cad_locacaoes(alocacao);
            
    }

        private void F_Alocacao_Load(object sender, EventArgs e)
        {
            dgv_alocao_livros.DataSource = BCO.mostrar_locacaoes();
            dgv_alocao_livros.Columns[0].Width = 50;
            dgv_alocao_livros.Columns[1].Width = 80;
            dgv_alocao_livros.Columns[2].Width = 100;
            dgv_alocao_livros.Columns[3].Width = 100;
            dgv_alocao_livros.Columns[4].Width = 120;
            dgv_alocao_livros.Columns[5].Width = 80;
            dgv_alocao_livros.Columns[6].Width = 80;
            dgv_alocao_livros.Columns[7].Width = 80;
            dgv_alocao_livros.Columns[8].Width = 80;
            dgv_alocao_livros.Columns[9].Width = 50;
        }
    

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            dgv_alocao_livros.DataSource = BCO.mostrar_locacaoes();
            dgv_alocao_livros.Columns[0].Width = 50 ;
            dgv_alocao_livros.Columns[1].Width = 80;
            dgv_alocao_livros.Columns[2].Width = 100;
            dgv_alocao_livros.Columns[3].Width = 100;
            dgv_alocao_livros.Columns[4].Width = 120;
            dgv_alocao_livros.Columns[5].Width = 80;
            dgv_alocao_livros.Columns[6].Width = 80;
            dgv_alocao_livros.Columns[7].Width = 80;
            dgv_alocao_livros.Columns[8].Width = 80;
            dgv_alocao_livros.Columns[9].Width = 50;
        }

       

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Alocacao alocacao = new Alocacao();
     
            if (txt_pesquisar_letra.Text != "")
            {
                alocacao.pesquisar_letra = txt_pesquisar_letra.Text;
                dgv_alocao_livros.DataSource = BCO.pesquisar_letras_Locacao(alocacao);
            }
            if (txt_pesquisar_numeros.Text != "")
            {
                alocacao.pesquisar_num = Convert.ToInt64(txt_pesquisar_numeros.Text);
                dgv_alocao_livros.DataSource = BCO.pesquisar_numeros_Locacao(alocacao);
            }
            if (txt_pesquisar_letra.Text != "" && txt_pesquisar_numeros.Text != "")
            {

            }
            
        }

        private void txt_pesquisar_letra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar)&&!char.IsControl(e.KeyChar)&&!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                DialogResult msgtex = MessageBox.Show("Apenas Letras", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_pesquisar_numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                DialogResult msgnum = MessageBox.Show("Apenas Números", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_excluir_alocacao_Click(object sender, EventArgs e)
        {
            Alocacao alocacao = new Alocacao();

            if (nud_id_locacao.Text != "")
            {
                alocacao.id_locacao = Convert.ToInt32(nud_id_locacao.Text);
                BCO.excluir_locacao(alocacao);
            }

        }

        private void btn_alterar_alocacao_Click(object sender, EventArgs e)
        {
            Alocacao alocacao = new Alocacao();
            if (nud_id_locacao.Text != "")
            {
                alocacao.id_locacao = Convert.ToInt32(nud_id_locacao.Text);
                alocacao.tombo_exemplares = Convert.ToInt32(nud_tombo_locacao.Text);
                alocacao.rm_usuario = Convert.ToInt32(nud_rm_aluno_locacao.Text);
                alocacao.rm_admin = Convert.ToInt32(nud_rm_admin_locacao.Text);
                alocacao.data_locacao = Convert.ToDateTime(dtp_data_emprestimo.Value).ToString("yyy/MM/dd");
                alocacao.data_devolucao = Convert.ToDateTime(dtp_data_devolucao.Value).ToString("yyy/MM/dd");
                alocacao.situacao = cb_status.Text;

                BCO.alterar_Locacao(alocacao);
            }
            else
            {
                MessageBox.Show("Erro - digite o Id da Locação!");
                nud_id_locacao.Focus();
                return;
            }
        }

        private void dgv_alocao_livros_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {
                DataTable dt = new DataTable();
                string id_loc = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = BCO.mostrando_locacoes(id_loc);
                nud_id_locacao.Value = dt.Rows[0].Field<Int32>("id_locacao");
                nud_tombo_locacao.Value = dt.Rows[0].Field<Int32>("tombo_exemplares");
                nud_rm_aluno_locacao.Value = dt.Rows[0].Field<Int32>("rm_usuario_locacao");
                nud_rm_admin_locacao.Value = dt.Rows[0].Field<Int32>("rm_usuarioAdimin_locacao");
                dtp_data_emprestimo.Text = dt.Rows[0].Field<DateTime>("data_locacao").ToString();
                dtp_data_devolucao.Text = dt.Rows[0].Field<DateTime>("data_devolucao").ToString();
                cb_status.Text = dt.Rows[0].Field<string>("situacao").ToString();
            }
           
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
                string textoPdf = "Relátorio Cursos";
                Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 15, (int)System.Drawing.FontStyle.Bold));
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(textoPdf + "\n\n");

                PdfPTable tabela = new PdfPTable(11);
                tabela.DefaultCell.FixedHeight = 20;

                PdfPCell celula = new PdfPCell(new Phrase("Id"));
                tabela.AddCell("Id");
                tabela.AddCell("Rm");
                tabela.AddCell("Nome");
                tabela.AddCell("Sobrenome");
                tabela.AddCell("Status");
                tabela.AddCell("Titulo");
                tabela.AddCell("Tombo");
                tabela.AddCell("Data de Locacao");
                tabela.AddCell("Situacao");
                tabela.AddCell("Data de Entrega");
                tabela.AddCell("Rm Admin");

                DataTable dtLocacao = BCO.mostrar_locacaoes();
                for (int i = 0; i < dtLocacao.Rows.Count; i++)
                {
                    tabela.AddCell(dtLocacao.Rows[i].Field<Int32>("Id").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<Int32>("Rm").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<string>("Nome").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<string>("Sobrenome").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<string>("Status").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<string>("Titulo").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<Int32>("Tombo").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<DateTime>("Data de Locacao").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<string>("Situacao").ToString());
                    tabela.AddCell(dtLocacao.Rows[i].Field<DateTime>("Data de Entrega").ToString());               
                    tabela.AddCell(dtLocacao.Rows[i].Field<Int32>("Rm Admin").ToString());

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
