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
    public partial class F_Professores : Form
    {
        public string tipoPesquisa = "N";
        public string status = "T";
        public string situacao = "T";
        public string sexo = "T";
        public string instituicao = null;

        List<string> codigos = new List<string>();

        public F_Professores()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void F_Professores_Load(object sender, EventArgs e)
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

        private void verificaSelecionados()
        {
            for (int i = 0; i < dgv_professores.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv_professores.Rows[i].Cells[1].Value.ToString()))
                {
                    if (codigos.IndexOf(dgv_professores.Rows[i].Cells[3].Value.ToString()) == -1)
                    {
                        codigos.Add(dgv_professores.Rows[i].Cells[3].Value.ToString());
                    }
                }
                else
                {
                    if (codigos.IndexOf(dgv_professores.Rows[i].Cells[3].Value.ToString()) != -1)
                    {
                        codigos.RemoveAt(codigos.IndexOf(dgv_professores.Rows[i].Cells[3].Value.ToString()));
                    }
                }
            }
        }

        public void carregarMais()
        {
            btn_carregarMais.Visible = false;
            img_loading.Visible = true;

            verificaSelecionados();

            string texto = string.Empty;

            if(tb_pesquisa.Text.Trim() == "Pesquisar professor...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            status = (status != "T") ? status : string.Empty;


            if (situacao == "T") situacao = string.Empty;
            else if (situacao == "D" || situacao == "I") situacao = " AND i.situacao = '" + situacao + "'";

            if (sexo == "O") sexo = " AND p.sexo IS NULL";
            else if (sexo == "T") sexo = string.Empty;
            else if (sexo == "M" || sexo == "F") sexo = " AND p.sexo = '" + sexo + "'";

            string sql = string.Empty;

            if(tipoPesquisa == "R")
            {
                sql = "SELECT p.rm_professor, CONCAT(p.nome, CONCAT(' ', p.sobrenome)), p.cpf, CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', p.data_cadastro, p.img_professor, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', p.id_usuario_professor FROM professor AS p INNER JOIN usuario AS u ON p.id_usuario_professor = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = p.id_usuario_professor WHERE p.rm_professor LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%'" + sexo + " AND i.id_instituicao = " + instituicao + situacao + " GROUP BY p.rm_professor ORDER BY CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIMIT " + dgv_professores.Rows.Count + ", 10";
            }
            else if (tipoPesquisa == "C")
            {
                sql = "SELECT p.rm_professor, CONCAT(p.nome, CONCAT(' ', p.sobrenome)), p.cpf, CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', p.data_cadastro, p.img_professor, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', p.id_usuario_professor FROM professor AS p INNER JOIN usuario AS u ON p.id_usuario_professor = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = p.id_usuario_professor WHERE p.cpf LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%'" + sexo + " AND i.id_instituicao = " + instituicao + situacao + " GROUP BY p.rm_professor ORDER BY CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIMIT " + dgv_professores.Rows.Count + ", 10";
            }
            else
            {
                sql = "SELECT p.rm_professor, CONCAT(p.nome, CONCAT(' ', p.sobrenome)), p.cpf, CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', p.data_cadastro, p.img_professor, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', p.id_usuario_professor FROM professor AS p INNER JOIN usuario AS u ON p.id_usuario_professor = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = p.id_usuario_professor WHERE CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%'" + sexo + " AND i.id_instituicao = " + instituicao + situacao + " GROUP BY p.rm_professor ORDER BY CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIMIT " + dgv_professores.Rows.Count + ", 10";
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

                dgv_professores.Rows.Add(codigoUsuario, checado, System.Drawing.Image.FromStream(ms), rm, nome, cpf, dataCadastro, sexo, status);
            }

            panel5.Height = (40 * dgv_professores.Rows.Count) + 50;

            btn_carregarMais.Visible = true;
            img_loading.Visible = false;
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar professor...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar professor...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            F_CadProfessores c = new F_CadProfessores();

            c.ShowDialog();
        }

        // Função para excluir, editar e emitir mensagem

        private void dgv_professores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_professores.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_professores.Rows[e.RowIndex].Cells[0].Value.ToString(); // Codigo do usuário selecionado

                if (e.ColumnIndex == 9) //Emitir Mensagem
                {
                    F_EnviaMensagem f = new F_EnviaMensagem(codigo, "P");
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 10) //Deletar Professor
                {
                    F_PegarSenhaUsuario f = new F_PegarSenhaUsuario(null, this, null, codigo, instituicao);
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 11) //Editar dados
                {
                    F_EditaProfessor f = new F_EditaProfessor(dgv_professores.Rows[e.RowIndex].Cells[3].Value.ToString(), this);
                    f.ShowDialog();
                }
            }
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                verificaSelecionados();

                dgv_professores.Rows.Clear();

                carregarMais();
            }
        }

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            F_DefineFiltroProfessores f = new F_DefineFiltroProfessores(this);
            f.ShowDialog();
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            verificaSelecionados();

            if (codigos.Count > 0)
            {
                F_RelatorioProfessor f = new F_RelatorioProfessor(codigos);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione pelo menos um professor para emitir o relatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
