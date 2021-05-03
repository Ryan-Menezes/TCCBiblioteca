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
    public partial class F_Livros : Form
    {
        public string tipoPesquisa = "TI";
        public string genero = "T";
        public string instituicao = null;

        List<string> codigos = new List<string>();

        public F_Livros()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void F_Livros_Load(object sender, EventArgs e)
        {
            //Verificando o número de instituições cadastradas no sistema

            DataTable dt = BCO.Dql("SELECT * FROM instituicao LIMIT 2");

            if(dt.Rows.Count < 2)
            {
                dgv_livros.Columns[11].Visible = false;
            }

            foreach (KeyValuePair<string, string> valor in UsuarioLogado.instituicoes)
            {
                instituicao = valor.Key;
                break;
            }

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        private void verificaSelecionados()
        {
            for (int i = 0; i < dgv_livros.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv_livros.Rows[i].Cells[2].Value.ToString()))
                {
                    if (codigos.IndexOf(dgv_livros.Rows[i].Cells[1].Value.ToString()) == -1 && dgv_livros.Rows[i].Cells[1].Value.ToString().Length > 0)
                    {
                        codigos.Add(dgv_livros.Rows[i].Cells[1].Value.ToString());
                    }
                }
                else
                {
                    if (codigos.IndexOf(dgv_livros.Rows[i].Cells[1].Value.ToString()) != -1)
                    {
                        codigos.RemoveAt(codigos.IndexOf(dgv_livros.Rows[i].Cells[1].Value.ToString()));
                    }
                }
            }
        }

        //Metodo responsavel de carregar mais dados na tabela

        public void carregarMais()
        {
            verificaSelecionados();

            btn_carregarMais.Visible = false;
            img_loading.Visible = true;

            string texto = string.Empty;

            if(tb_pesquisa.Text.Trim() == "Pesquisar livro...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            DataTable dt = new DataTable();

            try
            {

                string generoSql = (genero != "T") ? " AND gl.id_genero_tombo = " + genero : string.Empty;

                if (tipoPesquisa == "TI")
                {
                    dt = BCO.Dql("SELECT l.cod_livro, l.tombo, l.titulo, l.insercao, l.isbn, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)), e.id_exemplares FROM livro AS l LEFT JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE (e.id_instituicao = " + instituicao + " OR l.tombo IS NULL) AND l.titulo LIKE '%" + texto + "%'" + generoSql + " GROUP BY e.id_exemplares ORDER BY l.titulo LIMIT " + dgv_livros.Rows.Count + ", 10");
                }
                else if (tipoPesquisa == "TO")
                {
                    dt = BCO.Dql("SELECT l.cod_livro, l.tombo, l.titulo, l.insercao, l.isbn, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)), e.id_exemplares FROM livro AS l LEFT JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE (e.id_instituicao = " + instituicao + " OR l.tombo IS NULL) AND l.tombo LIKE '%" + texto + "%'" + generoSql + " GROUP BY e.id_exemplares ORDER BY l.titulo LIMIT " + dgv_livros.Rows.Count + ", 10");
                }
                else
                {
                    dt = BCO.Dql("SELECT l.cod_livro, l.tombo, l.titulo, l.insercao, l.isbn, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)), e.id_exemplares FROM livro AS l LEFT JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE (e.id_instituicao = " + instituicao + " OR l.tombo IS NULL) AND l.isbn LIKE '%" + texto + "%'" + generoSql + " GROUP BY e.id_exemplares ORDER BY l.titulo LIMIT " + dgv_livros.Rows.Count + ", 10");
                }
            }
            catch{}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string codigoLivro = dt.Rows[i].ItemArray[0].ToString();

                //Capa

                byte[] imagem = (byte[])(dt.Rows[i].ItemArray[5]);

                MemoryStream ms = new MemoryStream(imagem);

                //Dados Restantes

                string tombo = dt.Rows[i].ItemArray[1].ToString();
                string titulo = dt.Rows[i].ItemArray[2].ToString();
                string insercao = Convert.ToDateTime(dt.Rows[i].ItemArray[3]).ToString("dd/MM/yyyy");
                string isbn = dt.Rows[i].ItemArray[4].ToString();
                string exemplares = dt.Rows[i].ItemArray[6].ToString();
                string id_exemplares = dt.Rows[i].ItemArray[7].ToString();

                //Buscando os autores e os generos

                string autores = string.Empty;
                string generos = string.Empty;
                
                //Buscando generos deste livro

                try
                {
                    DataTable data = new DataTable();

                    data = BCO.Dql("SELECT g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = " + codigoLivro);

                    for(int j = 0; j < data.Rows.Count; j++)
                    {
                        generos += data.Rows[j].ItemArray[0].ToString();

                        if(j != data.Rows.Count - 1)
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

                //Adicionando itens ao data grid view

                if (tombo.Length > 0)
                {
                    if (codigos.IndexOf(id_exemplares) == -1)
                    {
                        dgv_livros.Rows.Add(codigoLivro, id_exemplares, false, System.Drawing.Image.FromStream(ms), tombo, titulo, autores, generos, exemplares, insercao, isbn);
                    }
                    else
                    {
                        dgv_livros.Rows.Add(codigoLivro, id_exemplares, true, System.Drawing.Image.FromStream(ms), tombo, titulo, autores, generos, exemplares, insercao, isbn);
                    }
                }
                else
                {
                    dgv_livros.Rows.Add(codigoLivro, id_exemplares, false, System.Drawing.Image.FromStream(ms), string.Empty, titulo, autores, generos, string.Empty, insercao, string.Empty);
                }
            }

            panel5.Height = (60 * dgv_livros.Rows.Count) + 50;

            btn_carregarMais.Visible = true;
            img_loading.Visible = false;
        }

        //Metodos para criar efeito placeholder na barra de pesquisa

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar livro...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar livro...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        //Evento do botão de carregar mais

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        // Função para excluir e editar

        private void dgv_livros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_livros.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                
                if (e.ColumnIndex == 11)
                {
                    if(dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[1].Value.ToString().Length > 0)
                    {
                        F_ExportarExemplares f = new F_ExportarExemplares(this, dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[0].Value.ToString(), dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[1].Value.ToString());
                        f.ShowDialog();
                    }
                }
                else if (e.ColumnIndex == 12) //Deletar Livro
                {
                    F_PegarSenha f = new F_PegarSenha(this, dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[1].Value.ToString(), dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[0].Value.ToString());
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 13) //Editar dados
                {
                    if (dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[1].Value.ToString().Length > 0)
                    {
                        F_EditaLivro f = new F_EditaLivro(dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[0].Value.ToString(), dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[1].Value.ToString(), this);
                        f.ShowDialog();
                    }
                    else
                    {
                        F_EditaLivroPDF f = new F_EditaLivroPDF(dgv_livros.Rows[dgv_livros.SelectedRows[0].Index].Cells[0].Value.ToString(), this);
                        f.ShowDialog();
                    }
                }
            }
        }

        private void btn_cad_Click(object sender, EventArgs e)
        {
            F_CadLivro c = new F_CadLivro();

            c.ShowDialog();
        }

        private void btn_adiciona_Click(object sender, EventArgs e)
        {
            F_AdicionaExemplares c = new F_AdicionaExemplares();

            c.ShowDialog();
        }

        //Relatório

        private void btn_relatorio_livro_Click(object sender, EventArgs e)
        {
            
        }

        //Metodo do munu de opções

        private void btn_opcoes_Click(object sender, EventArgs e)
        {
            if (menu_opcao.Visible)
            {
                menu_opcao.Visible = false;
            }
            else
            {
                menu_opcao.Visible = true;
            }
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                verificaSelecionados();

                dgv_livros.Rows.Clear();

                carregarMais();
            }
        }

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            F_DefineFiltroLivro f = new F_DefineFiltroLivro(this);
            f.ShowDialog();
        }

        private void btn_cadPDF_Click(object sender, EventArgs e)
        {
            F_CadLivroPDF f = new F_CadLivroPDF();
            f.ShowDialog();
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            verificaSelecionados();

            if(codigos.Count > 0)
            {
                F_RelatorioLivros f = new F_RelatorioLivros(codigos);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione pelo menos um livro para emitir o relatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
