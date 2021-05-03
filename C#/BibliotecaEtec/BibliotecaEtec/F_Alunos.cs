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
    public partial class F_Alunos : Form
    {
        public string tipoPesquisa = "N";
        public string status = "T";
        public string sexo = "T";
        public string instituicao = string.Empty;
        public string turma = "T";

        List<string> codigos = new List<string>();

        public F_Alunos()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void F_Alunos_Load(object sender, EventArgs e)
        {
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

        public void carregarMais()
        {
            btn_carregarMais.Visible = false;
            img_loading.Visible = true;

            verificaSelecionados();

            string texto = string.Empty;

            if (tb_pesquisa.Text.Trim() == "Pesquisar aluno...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            status = (status != "T") ? status : string.Empty;

            string turmaString = string.Empty;
            string instituicaoString = " AND cs.id_instituicao_curso = " + instituicao;

            if (turma == "T") turmaString = string.Empty;
            else turmaString = " AND c.curso_id_curso = " + turma;

            if (sexo == "O") sexo = " AND a.sexo IS NULL";
            else if (sexo == "T") sexo = string.Empty;
            else if (sexo == "M" || sexo == "F") sexo = " AND a.sexo = '" + sexo + "'";

            string sql = string.Empty;

            if (tipoPesquisa == "R")
            {
                sql = "SELECT a.rm_aluno, CONCAT(a.nome, CONCAT(' ', a.sobrenome)), a.cpf, CASE a.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', a.data_cadastro, a.img_aluno, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', a.id_usuario_aluno FROM aluno AS a INNER JOIN usuario AS u ON a.id_usuario_aluno = u.id_usuario INNER JOIN curso_usuario AS c ON c.usuario_id_usuario = u.id_usuario INNER JOIN curso AS cs ON cs.id_curso = c.curso_id_curso WHERE a.rm_aluno LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%' " + sexo + turmaString + instituicaoString + " GROUP BY a.rm_aluno ORDER BY CONCAT(a.nome, CONCAT(' ', a.sobrenome)) LIMIT " + dgv_alunos.Rows.Count + ", 10";
            }
            else if (tipoPesquisa == "C")
            {
                sql = "SELECT a.rm_aluno, CONCAT(a.nome, CONCAT(' ', a.sobrenome)), a.cpf, CASE a.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', a.data_cadastro, a.img_aluno, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', a.id_usuario_aluno FROM aluno AS a INNER JOIN usuario AS u ON a.id_usuario_aluno = u.id_usuario INNER JOIN curso_usuario AS c ON c.usuario_id_usuario = u.id_usuario INNER JOIN curso AS cs ON cs.id_curso = c.curso_id_curso WHERE a.cpf LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%' " + sexo + turmaString + instituicaoString + " GROUP BY a.rm_aluno ORDER BY CONCAT(a.nome, CONCAT(' ', a.sobrenome)) LIMIT " + dgv_alunos.Rows.Count + ", 10";
            }
            else
            {
                sql = "SELECT a.rm_aluno, CONCAT(a.nome, CONCAT(' ', a.sobrenome)), a.cpf, CASE a.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', a.data_cadastro, a.img_aluno, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', a.id_usuario_aluno FROM aluno AS a INNER JOIN usuario AS u ON a.id_usuario_aluno = u.id_usuario INNER JOIN curso_usuario AS c ON c.usuario_id_usuario = u.id_usuario INNER JOIN curso AS cs ON cs.id_curso = c.curso_id_curso WHERE CONCAT(a.nome, CONCAT(' ', a.sobrenome)) LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%' " + sexo + turmaString + instituicaoString + " GROUP BY a.rm_aluno ORDER BY CONCAT(a.nome, CONCAT(' ', a.sobrenome)) LIMIT " + dgv_alunos.Rows.Count + ", 10";
            }

            DataTable dt = BCO.Dql(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Capa

                byte[] imagem = (byte[])(dt.Rows[i].ItemArray[5]);

                MemoryStream ms = new MemoryStream(imagem);

                //Dados Restantes

                string rm = dt.Rows[i].ItemArray[0].ToString();
                string nome = dt.Rows[i].ItemArray[1].ToString();
                string cpf = dt.Rows[i].ItemArray[2].ToString();
                string sexo = dt.Rows[i].ItemArray[3].ToString();
                string dataCadastro = Convert.ToDateTime(dt.Rows[i].ItemArray[4]).ToString("dd/MM/yyyy");
                string status = dt.Rows[i].ItemArray[6].ToString();
                string codigoUsuario = dt.Rows[i].ItemArray[7].ToString();

                //Adicionando itens ao data grid view

                bool checado = (codigos.IndexOf(rm) == -1) ? false : true;

                dgv_alunos.Rows.Add(codigoUsuario, checado, System.Drawing.Image.FromStream(ms), rm, nome, cpf, dataCadastro, sexo, status);
            }

            panel5.Height = (40 * dgv_alunos.Rows.Count) + 50;

            btn_carregarMais.Visible = true;
            img_loading.Visible = false;
        }

        private void verificaSelecionados()
        {
            for(int i = 0; i < dgv_alunos.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv_alunos.Rows[i].Cells[1].Value.ToString()))
                {
                    if(codigos.IndexOf(dgv_alunos.Rows[i].Cells[3].Value.ToString()) == -1)
                    {
                        codigos.Add(dgv_alunos.Rows[i].Cells[3].Value.ToString());
                    }
                }
                else
                {
                    if(codigos.IndexOf(dgv_alunos.Rows[i].Cells[3].Value.ToString()) != -1)
                    {
                        codigos.RemoveAt(codigos.IndexOf(dgv_alunos.Rows[i].Cells[3].Value.ToString()));
                    }
                }
            }
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar aluno...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if(tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar aluno...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            F_CadAlunos c = new F_CadAlunos();

            c.ShowDialog();
        }

        // Função para excluir, editar e emitir mensagem

        private void dgv_alunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_alunos.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_alunos.Rows[e.RowIndex].Cells[0].Value.ToString(); // Código do usuário selecionado

                if (e.ColumnIndex == 9) //Emitir Mensagem
                {
                    F_EnviaMensagem f = new F_EnviaMensagem(codigo, "A");
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 10) //Deletar Aluno
                {
                    F_PegarSenhaUsuario f = new F_PegarSenhaUsuario(this, null, null, codigo, instituicao);
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 11) //Editar dados
                {
                    F_EditaAluno f = new F_EditaAluno(dgv_alunos.Rows[e.RowIndex].Cells[3].Value.ToString(), this);
                    f.ShowDialog();
                }
            }
        }

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            F_DefineFiltroAluno f = new F_DefineFiltroAluno(this);
            f.ShowDialog();
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                verificaSelecionados();

                dgv_alunos.Rows.Clear();

                carregarMais();
            }
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            verificaSelecionados();

            if (codigos.Count > 0)
            {
                F_RelatorioAlunos f = new F_RelatorioAlunos(codigos);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione pelo menos um aluno para emitir o relatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
