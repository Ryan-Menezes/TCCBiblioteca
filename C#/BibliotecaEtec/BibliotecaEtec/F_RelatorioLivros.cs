using Biblioteca01;
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

namespace BibliotecaEtec
{
    public partial class F_RelatorioLivros : Form
    {
        string codigoLivros = string.Empty;

        public F_RelatorioLivros(List<string> linhas)
        {
            InitializeComponent();

            string codigos = string.Empty;

            for(int i = 0; i < linhas.Count; i++)
            {
                codigos += linhas[i];

                if(i != linhas.Count - 1)
                {
                    codigos += ", ";
                }
            }

            codigoLivros = codigos;

            DataTable dt = BCO.Dql("SELECT l.img_livro, l.cod_livro, l.tombo, l.titulo, l.volume, l.edicao, e.quantidade, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) AS qtderes, l.insercao, l.ano_publicacao, l.isbn, l.idioma, i.nome_instituicao FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_exemplares IN(" + codigos + ") GROUP BY e.id_exemplares ORDER BY l.titulo");

            for(int l = 0; l < dt.Rows.Count; l++)
            {
                byte[] img = (byte[])dt.Rows[l].ItemArray[0];
                MemoryStream ms = new MemoryStream(img);

                string codigoLivro = dt.Rows[l].ItemArray[1].ToString();
                string tombo = dt.Rows[l].ItemArray[2].ToString();
                string titulo = dt.Rows[l].ItemArray[3].ToString();
                string volume = dt.Rows[l].ItemArray[4].ToString();
                string edicao = dt.Rows[l].ItemArray[5].ToString();
                string quantidade = dt.Rows[l].ItemArray[6].ToString();
                string qtdeRest = dt.Rows[l].ItemArray[7].ToString();
                string insercao = Convert.ToDateTime(dt.Rows[l].ItemArray[8]).ToString("dd/MM/yyyy");
                string ano = Convert.ToDateTime(dt.Rows[l].ItemArray[9]).ToString("dd/MM/yyyy");
                string isbn = dt.Rows[l].ItemArray[10].ToString();
                string idioma = dt.Rows[l].ItemArray[11].ToString();
                string instituicao = dt.Rows[l].ItemArray[12].ToString();

                //Buscando os autores, generos e editoras

                string autores = string.Empty;
                string generos = string.Empty;
                string editoras = string.Empty;

                //Buscando generos deste livro

                try
                {
                    DataTable data = new DataTable();

                    data = BCO.Dql("SELECT g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = " + codigoLivro);

                    for (int j = 0; j < data.Rows.Count; j++)
                    {
                        generos += data.Rows[j].ItemArray[0].ToString();

                        if (j != data.Rows.Count - 1)
                        {
                            generos += ", ";
                        }
                    }
                }
                catch
                {
                    generos = string.Empty;
                }

                //Buscando autores deste livro

                try
                {
                    DataTable data = new DataTable();

                    data = BCO.Dql("SELECT a.nome_autor FROM autor AS a INNER JOIN autor_livro AS al ON al.id_autor_tombo = a.id_autor WHERE al.id_livro_tombo = " + codigoLivro);

                    for (int j = 0; j < data.Rows.Count; j++)
                    {
                        autores += data.Rows[j].ItemArray[0].ToString();

                        if (j != data.Rows.Count - 1)
                        {
                            autores += ", ";
                        }
                    }
                }
                catch
                {
                    autores = string.Empty;
                }

                //Buscando editoras deste livro

                try
                {
                    DataTable data = new DataTable();

                    data = BCO.Dql("SELECT e.nome_editora FROM editora AS e INNER JOIN editora_livro AS el ON el.id_editora = e.id_editora WHERE el.cod_livro = " + codigoLivro);

                    for (int j = 0; j < data.Rows.Count; j++)
                    {
                        editoras += data.Rows[j].ItemArray[0].ToString();

                        if (j != data.Rows.Count - 1)
                        {
                            editoras += ", ";
                        }
                    }
                }
                catch
                {
                    editoras = string.Empty;
                }

                dgv_relatorio.Rows.Add(System.Drawing.Image.FromStream(ms), tombo, titulo, volume, edicao, autores, generos, editoras, qtdeRest, quantidade, insercao, ano, isbn, idioma, instituicao);
            }

            dgv_relatorio.Height = (dgv_relatorio.Rows.Count * 60) + 50;
            p_table.Height = dgv_relatorio.Height + 80;

            //Carregando combo boxes

            //Tamanho da página

            Dictionary<iTextSharp.text.Rectangle, string> tamPag = new Dictionary<iTextSharp.text.Rectangle, string>();
            tamPag.Add(PageSize.A0, "A0");
            tamPag.Add(PageSize.A1, "A1");
            tamPag.Add(PageSize.A2, "A2");
            tamPag.Add(PageSize.A3, "A3");
            tamPag.Add(PageSize.A4, "A4");
            tamPag.Add(PageSize.A5, "A5");
            tamPag.Add(PageSize.A6, "A6");
            tamPag.Add(PageSize.A7, "A7");
            tamPag.Add(PageSize.A8, "A8");
            tamPag.Add(PageSize.A9, "A9");
            tamPag.Add(PageSize.A10, "A10");
            tamPag.Add(PageSize.B0, "B0");
            tamPag.Add(PageSize.B1, "B1");
            tamPag.Add(PageSize.B2, "B2");
            tamPag.Add(PageSize.B3, "B3");
            tamPag.Add(PageSize.B4, "B4");
            tamPag.Add(PageSize.B5, "B5");
            tamPag.Add(PageSize.B6, "B6");
            tamPag.Add(PageSize.B7, "B7");
            tamPag.Add(PageSize.B8, "B8");
            tamPag.Add(PageSize.B9, "B9");
            tamPag.Add(PageSize.B10, "B10");

            cb_tam.DataSource = new BindingSource(tamPag, null);
            cb_tam.DisplayMember = "Value";
            cb_tam.ValueMember = "Key";

            //Orirentação

            Dictionary<string, string> orientacao = new Dictionary<string, string>();
            orientacao.Add("R", "Retrato");
            orientacao.Add("P", "Paisagem");

            cb_orientacao.DataSource = new BindingSource(orientacao, null);
            cb_orientacao.DisplayMember = "Value";
            cb_orientacao.ValueMember = "Key";

            //carregando as checkboxes

            DataGridViewCheckBoxColumn coluna = null;

            for (int i = 0; i < dgv_relatorio.Columns.Count; i++)
            {
                coluna = new DataGridViewCheckBoxColumn();
                dgv_checkboxes.Columns.Add(coluna);
            }

            dgv_checkboxes.Rows.Add(true, true, true, true, true, true, true, true, true, true, true, true, true, true, true);
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            if (tb_titulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Dê um titulo ao seu relatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_titulo.Focus();
                return;
            }

            //Contando colunas selecionadas

            int colunas = 0;

            for (int i = 0; i < dgv_checkboxes.Columns.Count; i++)
            {
                if (Convert.ToBoolean(dgv_checkboxes.Rows[0].Cells[i].Value.ToString()))
                {
                    colunas++;
                }
            }

            if (colunas == 0)
            {
                MessageBox.Show("Selecione pelo menos uma coluna!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            salvarArquivo.Filter = "PDF(*.PDF)|*.PDF";
            salvarArquivo.FileName = tb_titulo.Text.Trim();

            DialogResult res = salvarArquivo.ShowDialog();

            if(res == DialogResult.OK)
            {
                FileStream fs = new FileStream(salvarArquivo.FileName, FileMode.Create);

                Document doc = null;

                if (cb_orientacao.SelectedValue.ToString() == "R")
                {
                    doc = new Document((iTextSharp.text.Rectangle)cb_tam.SelectedValue, 20, 20, 20, 20);
                }
                else
                {
                    doc = new Document(((iTextSharp.text.Rectangle)cb_tam.SelectedValue).Rotate(), 20, 20, 20, 20);
                }
                
                PdfWriter pdf = PdfWriter.GetInstance(doc, fs);

                //Criando a tabela

                PdfPTable tabela = new PdfPTable(colunas);
                tabela.WidthPercentage = 100;

                tabela.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabela.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela.DefaultCell.Padding = 10;
                tabela.DefaultCell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                tabela.DefaultCell.BorderWidthLeft = 0;
                tabela.DefaultCell.BorderWidthLeft = 0;
                tabela.DefaultCell.BorderWidthBottom = 1;
                tabela.DefaultCell.BorderColorBottom = iTextSharp.text.BaseColor.BLACK;

                //Carregando cabeçalho

                Paragraph texto = null;

                PdfPCell celulaTitle = new PdfPCell();
                celulaTitle.Padding = 10;
                celulaTitle.BorderColor = iTextSharp.text.BaseColor.WHITE;
                celulaTitle.BorderWidthLeft = 0;
                celulaTitle.BorderWidthLeft = 0;
                celulaTitle.BorderWidthBottom = 1;
                celulaTitle.BorderColorBottom = iTextSharp.text.BaseColor.WHITE;
                celulaTitle.VerticalAlignment = Element.ALIGN_MIDDLE;
                celulaTitle.HorizontalAlignment = Element.ALIGN_RIGHT;

                //Logo ETEC

                iTextSharp.text.Image imagem = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\Imagens\\LogoJKCircular.png");
                imagem.ScaleToFit(40f, 40f);
                imagem.Alignment = Element.ALIGN_RIGHT;
                celulaTitle.AddElement(imagem);

                tabela.AddCell(celulaTitle);

                //Logo Sistema

                celulaTitle.CompositeElements.Clear();
                celulaTitle.HorizontalAlignment = Element.ALIGN_CENTER;

                imagem = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\Imagens\\LogoCircular.png");
                imagem.ScaleToFit(40f, 40f);
                imagem.Alignment = Element.ALIGN_CENTER;
                celulaTitle.AddElement(imagem);

                tabela.AddCell(celulaTitle);

                //Logo CPS

                celulaTitle.CompositeElements.Clear();
                celulaTitle.HorizontalAlignment = Element.ALIGN_LEFT;

                imagem = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\Imagens\\LogoCPSCircular.png");
                imagem.ScaleToFit(40f, 40f);
                imagem.Alignment = Element.ALIGN_LEFT;
                celulaTitle.AddElement(imagem);

                tabela.AddCell(celulaTitle);

                celulaTitle.CompositeElements.Clear();
                celulaTitle.HorizontalAlignment = Element.ALIGN_LEFT;

                //Titulo

                celulaTitle.Colspan = colunas - 3;

                texto = new Paragraph(tb_titulo.Text.Trim(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10, (int)System.Drawing.FontStyle.Bold));
                celulaTitle.AddElement(texto);

                tabela.AddCell(celulaTitle);

                //Colunas

                PdfPCell celula = new PdfPCell();
                celula.Padding = 10;
                celula.BorderColor = iTextSharp.text.BaseColor.WHITE;
                celula.BorderWidthLeft = 0;
                celula.BorderWidthLeft = 0;
                celula.BorderWidthBottom = 1;
                celula.BorderColorBottom = iTextSharp.text.BaseColor.BLACK;
                celula.VerticalAlignment = Element.ALIGN_MIDDLE;
                celula.HorizontalAlignment = Element.ALIGN_CENTER;

                for (int i = 0; i < dgv_relatorio.Columns.Count; i++)
                {
                    if (Convert.ToBoolean(dgv_checkboxes.Rows[0].Cells[i].Value.ToString()))
                    {
                        texto = new Paragraph(dgv_relatorio.Columns[i].HeaderText.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10, (int)System.Drawing.FontStyle.Bold));
                        texto.Alignment = Element.ALIGN_CENTER;

                        celula.Phrase = new Phrase(texto);

                        tabela.AddCell(celula);
                    }
                }

                //Adicionando dados

                DataTable dt = BCO.Dql("SELECT l.img_livro, l.tombo, l.titulo, l.volume, l.edicao, l.cod_livro, l.cod_livro, l.cod_livro, e.quantidade, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) AS qtderes, l.insercao, l.ano_publicacao, l.isbn, l.idioma, i.nome_instituicao FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_exemplares IN(" + codigoLivros + ") GROUP BY e.id_exemplares ORDER BY l.titulo");

                for(int l = 0; l < dt.Rows.Count; l++)
                {
                    for(int c = 0; c < dt.Rows[l].ItemArray.Length; c++)
                    {
                        if (Convert.ToBoolean(dgv_checkboxes.Rows[0].Cells[c].Value.ToString()))
                        {
                            if (c == 0)
                            {
                                byte[] img = (byte[])dt.Rows[l].ItemArray[c];
                                MemoryStream ms = new MemoryStream(img);

                                imagem = iTextSharp.text.Image.GetInstance(ms);
                                imagem.ScaleToFit(30f, 50f);
                                imagem.Alignment = Element.ALIGN_CENTER;
                                celula.AddElement(imagem);

                                tabela.AddCell(celula);
                            }
                            else if (c == 5)
                            {
                                //Buscando autores deste livro

                                string autores = string.Empty;

                                try
                                {
                                    DataTable data = new DataTable();

                                    data = BCO.Dql("SELECT a.nome_autor FROM autor AS a INNER JOIN autor_livro AS al ON al.id_autor_tombo = a.id_autor WHERE al.id_livro_tombo = " + dt.Rows[l].ItemArray[c].ToString());

                                    for (int j = 0; j < data.Rows.Count; j++)
                                    {
                                        autores += data.Rows[j].ItemArray[0].ToString();

                                        if (j != data.Rows.Count - 1)
                                        {
                                            autores += ", ";
                                        }
                                    }
                                }
                                catch
                                {
                                    autores = string.Empty;
                                }

                                texto = new Paragraph(autores, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10, (int)System.Drawing.FontStyle.Regular));
                                celula.Phrase = new Phrase(texto);

                                tabela.AddCell(celula);
                            }
                            else if (c == 6)
                            {
                                //Buscando generos deste livro

                                string generos = string.Empty;

                                try
                                {
                                    DataTable data = new DataTable();

                                    data = BCO.Dql("SELECT g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = " + dt.Rows[l].ItemArray[c].ToString());

                                    for (int j = 0; j < data.Rows.Count; j++)
                                    {
                                        generos += data.Rows[j].ItemArray[0].ToString();

                                        if (j != data.Rows.Count - 1)
                                        {
                                            generos += ", ";
                                        }
                                    }
                                }
                                catch
                                {
                                    generos = string.Empty;
                                }

                                texto = new Paragraph(generos, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10, (int)System.Drawing.FontStyle.Regular));
                                celula.Phrase = new Phrase(generos);

                                tabela.AddCell(celula);
                            }
                            else if (c == 7)
                            {
                                //Buscando editoras deste livro

                                string editoras = string.Empty;

                                try
                                {
                                    DataTable data = new DataTable();

                                    data = BCO.Dql("SELECT e.nome_editora FROM editora AS e INNER JOIN editora_livro AS el ON el.id_editora = e.id_editora WHERE el.cod_livro = " + dt.Rows[l].ItemArray[c].ToString());

                                    for (int j = 0; j < data.Rows.Count; j++)
                                    {
                                        editoras += data.Rows[j].ItemArray[0].ToString();

                                        if (j != data.Rows.Count - 1)
                                        {
                                            editoras += ", ";
                                        }
                                    }
                                }
                                catch
                                {
                                    editoras = string.Empty;
                                }

                                texto = new Paragraph(editoras, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10, (int)System.Drawing.FontStyle.Regular));
                                celula.Phrase = new Phrase(texto);

                                tabela.AddCell(celula);
                            }
                            else if(c == 10 || c == 11)
                            {
                                texto = new Paragraph(Convert.ToDateTime(dt.Rows[l].ItemArray[c]).ToString("dd/MM/yyyy"), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10, (int)System.Drawing.FontStyle.Regular));
                                celula.Phrase = new Phrase(texto);

                                tabela.AddCell(celula);
                            }
                            else
                            {
                                texto = new Paragraph(dt.Rows[l].ItemArray[c].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10, (int)System.Drawing.FontStyle.Regular));
                                celula.Phrase = new Phrase(texto);

                                tabela.AddCell(celula);
                            }
                        }
                    }
                }

                doc.Open();
                doc.Add(tabela);
                doc.Close();
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            if(tb_titulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Dê um titulo ao seu relatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_titulo.Focus();
                return;
            }

            //Contando colunas selecionadas

            int colunas = 0;

            for (int i = 1; i < dgv_checkboxes.Columns.Count; i++)
            {
                if (Convert.ToBoolean(dgv_checkboxes.Rows[0].Cells[i].Value.ToString()))
                {
                    colunas++;
                }
            }

            if (colunas == 0)
            {
                MessageBox.Show("Selecione pelo menos uma coluna!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Salvando o arquivo

            salvarArquivo.Filter = "XLS(*.XLS)|*.XLS";
            salvarArquivo.FileName = tb_titulo.Text.Trim();

            DialogResult res = salvarArquivo.ShowDialog();

            if (res == DialogResult.OK)
            {
                FileStream fs = new FileStream(salvarArquivo.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter doc = new StreamWriter(fs);
                doc.Flush();
                doc.BaseStream.Seek(0, SeekOrigin.Begin);

                string texto = @"<!DOCTYPE html>
						         <html lang='pt-br'>
						         <head>
							        <title>Livros</title>
							        <meta charset='utf-8'>
						         </head>
						         <body>
						         <table style='text-align: center'>
							        <thead>
								        <tr class='thHeader'>
									        <th colspan='" + colunas + "'>" + tb_titulo.Text.Trim() + "</th></tr><tr>";

                for (int i = 1; i < dgv_relatorio.Columns.Count; i++)
                {
                    if (Convert.ToBoolean(dgv_checkboxes.Rows[0].Cells[i].Value.ToString()))
                    {
                        texto += "<th>" + dgv_relatorio.Columns[i].HeaderText.ToString() + "</th>";
                    }
                }

                texto += "</tr></thead><tbody>";

                //Adicionando dados

                DataTable dt = BCO.Dql("SELECT l.img_livro, l.tombo, l.titulo, l.volume, l.edicao, l.cod_livro, l.cod_livro, l.cod_livro, e.quantidade, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) AS qtderes, l.insercao, l.ano_publicacao, l.isbn, l.idioma, i.nome_instituicao FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_exemplares IN(" + codigoLivros + ") GROUP BY e.id_exemplares ORDER BY l.titulo");

                for (int l = 0; l < dt.Rows.Count; l++)
                {
                    texto += "<tr>";

                    for (int c = 1; c < dt.Rows[l].ItemArray.Length; c++)
                    {
                        if (Convert.ToBoolean(dgv_checkboxes.Rows[0].Cells[c].Value.ToString()))
                        {
                            if (c == 5)
                            {
                                //Buscando autores deste livro

                                string autores = string.Empty;

                                try
                                {
                                    DataTable data = new DataTable();

                                    data = BCO.Dql("SELECT a.nome_autor FROM autor AS a INNER JOIN autor_livro AS al ON al.id_autor_tombo = a.id_autor WHERE al.id_livro_tombo = " + dt.Rows[l].ItemArray[c].ToString());

                                    for (int j = 0; j < data.Rows.Count; j++)
                                    {
                                        autores += data.Rows[j].ItemArray[0].ToString();

                                        if (j != data.Rows.Count - 1)
                                        {
                                            autores += ", ";
                                        }
                                    }
                                }
                                catch
                                {
                                    autores = string.Empty;
                                }

                                texto += "<td>" + autores + "</td>";
                            }
                            else if (c == 6)
                            {
                                //Buscando generos deste livro

                                string generos = string.Empty;

                                try
                                {
                                    DataTable data = new DataTable();

                                    data = BCO.Dql("SELECT g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = " + dt.Rows[l].ItemArray[c].ToString());

                                    for (int j = 0; j < data.Rows.Count; j++)
                                    {
                                        generos += data.Rows[j].ItemArray[0].ToString();

                                        if (j != data.Rows.Count - 1)
                                        {
                                            generos += ", ";
                                        }
                                    }
                                }
                                catch
                                {
                                    generos = string.Empty;
                                }

                                texto += "<td>" + generos + "</td>";
                            }
                            else if (c == 7)
                            {
                                //Buscando editoras deste livro

                                string editoras = string.Empty;

                                try
                                {
                                    DataTable data = new DataTable();

                                    data = BCO.Dql("SELECT e.nome_editora FROM editora AS e INNER JOIN editora_livro AS el ON el.id_editora = e.id_editora WHERE el.cod_livro = " + dt.Rows[l].ItemArray[c].ToString());

                                    for (int j = 0; j < data.Rows.Count; j++)
                                    {
                                        editoras += data.Rows[j].ItemArray[0].ToString();

                                        if (j != data.Rows.Count - 1)
                                        {
                                            editoras += ", ";
                                        }
                                    }
                                }
                                catch
                                {
                                    editoras = string.Empty;
                                }

                                texto += "<td>" + editoras + "</td>";
                            }
                            else if (c == 10 || c == 11)
                            {
                                texto += "<td>" + Convert.ToDateTime(dt.Rows[l].ItemArray[c]).ToString("dd/MM/yyyy") + "</td>";
                            }
                            else
                            {
                                texto += "<td>" + dt.Rows[l].ItemArray[c].ToString() + "</td>";
                            }
                        }
                    }

                    texto += "</tr>";
                }

                texto += "</tbody></table></body></html>";

                doc.Write(texto);
                doc.Flush();
                doc.Close();
            }
        }
    }
}
