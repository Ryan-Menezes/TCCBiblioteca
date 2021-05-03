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
    public partial class F_Alocacoes : Form
    {
        public string tipoPesquisa = "TI";
        public string situacao = "T";
        public string tipo = "T";
        public string instituicao = null;

        List<string> codigos = new List<string>();

        public F_Alocacoes()
        {
            InitializeComponent();
            this.Visible = false;

            foreach (KeyValuePair<string, string> valor in UsuarioLogado.instituicoes)
            {
                instituicao = valor.Key;
                break;
            }
        }

        private void F_Alocacoes_Load(object sender, EventArgs e)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        public void carregarMais()
        {
            btn_carregarMais.Visible = false;
            img_loading.Visible = true;

            verificaSelecionados();

            DataTable dt = new DataTable();

            string texto = string.Empty;

            if(tb_pesquisa.Text.Trim() == "Pesquisar alocação...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            string sql = string.Empty;

            if(situacao == "T") situacao = string.Empty;
            else if (situacao == "N") situacao = "AND al.data_devolucao >= CURDATE()";
            else if(situacao == "A") situacao = "AND al.data_devolucao < CURDATE()";

            if(tipoPesquisa == "TI")
            {
                if(tipo == "T"){
					sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao WHERE l.titulo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
                else if(tipo == "A")
                {
					sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE l.titulo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
                else if (tipo == "P"){
					sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE l.titulo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
                else
                {
					sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario WHERE l.titulo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
            }
            else
            {
                if (tipo == "T")
                {
                    sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao WHERE l.tombo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
                else if (tipo == "A")
                {
                    sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE l.tombo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
                else if (tipo == "P")
                {
                    sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE l.tombo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
                else
                {
                    sql = "SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario WHERE l.tombo LIKE '%" + texto + "%' " + situacao + " AND e.id_instituicao = " + instituicao + " ORDER BY al.id_locacao DESC LIMIT " + dgv_alocacoes.Rows.Count + ", 10";
                }
            }

            dt = BCO.Dql(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Capa

                byte[] imagem = (byte[])(dt.Rows[i].ItemArray[3]);

                MemoryStream ms = new MemoryStream(imagem);

                //Dados Restantes

                string id = dt.Rows[i].ItemArray[0].ToString();
                string tombo = dt.Rows[i].ItemArray[1].ToString();
                string titulo = dt.Rows[i].ItemArray[2].ToString();
                string idUser = dt.Rows[i].ItemArray[4].ToString();
                string cpfUser = string.Empty;
                string nomeUser = string.Empty;
                string tipoUsuario = string.Empty;
                string dataAlocacao = Convert.ToDateTime(dt.Rows[i].ItemArray[5]).ToString("dd/MM/yyyy");
                string dataDevolucao = Convert.ToDateTime(dt.Rows[i].ItemArray[6]).ToString("dd/MM/yyyy");

                //Buscando dados do usuário

                DataTable data = new DataTable();

                data = BCO.Dql("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM aluno WHERE id_usuario_aluno = " + idUser + " LIMIT 1");

                if(data.Rows.Count > 0)
                {
                    cpfUser = data.Rows[0].ItemArray[0].ToString();
                    nomeUser = data.Rows[0].ItemArray[1].ToString();
                    tipoUsuario = "Aluno";
                }
                else
                {
                    data = BCO.Dql("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM professor WHERE id_usuario_professor = " + idUser + " LIMIT 1");

                    if (data.Rows.Count > 0)
                    {
                        cpfUser = data.Rows[0].ItemArray[0].ToString();
                        nomeUser = data.Rows[0].ItemArray[1].ToString();
                        tipoUsuario = "Professor";
                    }
                    else
                    {
                        data = BCO.Dql("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM funcionario WHERE id_usuario_funcionario = " + idUser + " LIMIT 1");

                        if (data.Rows.Count > 0)
                        {
                            cpfUser = data.Rows[0].ItemArray[0].ToString();
                            nomeUser = data.Rows[0].ItemArray[1].ToString();
                            tipoUsuario = "Funcionário";
                        }
                    }
                }

                //Adicionado itens ao dataGridView

                bool checado = (codigos.IndexOf(id) == -1) ? false : true;

                if (DateTime.Compare(DateTime.Today, Convert.ToDateTime(dt.Rows[i].ItemArray[6])) > 0)
                {
                    dgv_alocacoes.Rows.Add(id, checado, tombo, System.Drawing.Image.FromStream(ms), titulo, cpfUser, nomeUser, tipoUsuario, dataAlocacao, dataDevolucao, Properties.Resources.vermelho);
                }
                else
                {
                    dgv_alocacoes.Rows.Add(id, checado, tombo, System.Drawing.Image.FromStream(ms), titulo, cpfUser, nomeUser, tipoUsuario, dataAlocacao, dataDevolucao, Properties.Resources.Verde);
                }
            }

            panel5.Height = (60 * dgv_alocacoes.Rows.Count) + 50;

            btn_carregarMais.Visible = true;
            img_loading.Visible = false;
        }

        private void verificaSelecionados()
        {
            for (int i = 0; i < dgv_alocacoes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv_alocacoes.Rows[i].Cells[1].Value.ToString()))
                {
                    if (codigos.IndexOf(dgv_alocacoes.Rows[i].Cells[0].Value.ToString()) == -1)
                    {
                        codigos.Add(dgv_alocacoes.Rows[i].Cells[0].Value.ToString());
                    }
                }
                else
                {
                    if (codigos.IndexOf(dgv_alocacoes.Rows[i].Cells[0].Value.ToString()) != -1)
                    {
                        codigos.RemoveAt(codigos.IndexOf(dgv_alocacoes.Rows[i].Cells[0].Value.ToString()));
                    }
                }
            }
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar alocação...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar alocação...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void btn_alocacao_Click(object sender, EventArgs e)
        {
            F_CadAlocacao c = new F_CadAlocacao();

            c.ShowDialog();
        }

        // Função para excluir e editar

        private void dgv_alocacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_alocacoes.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_alocacoes.Rows[e.RowIndex].Cells[0].Value.ToString(); //Código da alocação selecionada

                if (e.ColumnIndex == 11) //Deletar Livro
                {
                    F_PegarSenhaAlocacao f = new F_PegarSenhaAlocacao(this, codigo);
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 12) //Editar dados
                {
                    F_EditaAlocacao f = new F_EditaAlocacao(this, codigo);
                    f.ShowDialog();
                }
            }
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                verificaSelecionados();

                dgv_alocacoes.Rows.Clear();

                carregarMais();
            }
        }

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            F_DefineFiltroAlocacao f = new F_DefineFiltroAlocacao(this);

            f.ShowDialog();
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            verificaSelecionados();

            if (codigos.Count > 0)
            {
                F_RelatorioAlocacao f = new F_RelatorioAlocacao(codigos);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione pelo menos uma alocação para emitir o relatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
