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
    public partial class F_Funcionarios : Form
    {
        public string tipoPesquisa = "N";
        public string status = "T";
        public string sexo = "T";
        public string instituicao = null;

        List<string> codigos = new List<string>();

        public F_Funcionarios()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void F_Funcionarios_Load(object sender, EventArgs e)
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
            for (int i = 0; i < dgv_funcionarios.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv_funcionarios.Rows[i].Cells[1].Value.ToString()))
                {
                    if (codigos.IndexOf(dgv_funcionarios.Rows[i].Cells[4].Value.ToString()) == -1)
                    {
                        codigos.Add(dgv_funcionarios.Rows[i].Cells[4].Value.ToString());
                    }
                }
                else
                {
                    if (codigos.IndexOf(dgv_funcionarios.Rows[i].Cells[4].Value.ToString()) != -1)
                    {
                        codigos.RemoveAt(codigos.IndexOf(dgv_funcionarios.Rows[i].Cells[4].Value.ToString()));
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

            if (tb_pesquisa.Text.Trim() == "Pesquisar funcionário...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            status = (status != "T") ? status : string.Empty;

            if (sexo == "O") sexo = " AND f.sexo IS NULL";
            else if (sexo == "T") sexo = string.Empty;
            else if(sexo == "M" || sexo == "F") sexo  = " AND f.sexo = '" + sexo + "'";

            string sql = string.Empty;

            if (tipoPesquisa == "C")
            {
                sql = "SELECT CONCAT(f.nome, CONCAT(' ', f.sobrenome)), f.cpf, CASE f.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', f.data_cadastro, f.img_funcionario, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', f.id_usuario_funcionario FROM funcionario AS f INNER JOIN usuario AS u ON f.id_usuario_funcionario = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = u.id_usuario WHERE f.cpf LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%'" + sexo + " AND i.id_instituicao = " + instituicao + " GROUP BY f.cpf ORDER BY CONCAT(f.nome, CONCAT(' ', f.sobrenome)) LIMIT " + dgv_funcionarios.Rows.Count + ", 10";
            }
            else
            {
                sql = "SELECT CONCAT(f.nome, CONCAT(' ', f.sobrenome)), f.cpf, CASE f.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', f.data_cadastro, f.img_funcionario, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', f.id_usuario_funcionario FROM funcionario AS f INNER JOIN usuario AS u ON f.id_usuario_funcionario = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = u.id_usuario WHERE CONCAT(f.nome, CONCAT(' ', f.sobrenome)) LIKE '%" + texto + "%' AND u.status_usuario LIKE '%" + status + "%'" + sexo + " AND i.id_instituicao = " + instituicao + " GROUP BY f.cpf ORDER BY CONCAT(f.nome, CONCAT(' ', f.sobrenome)) LIMIT " + dgv_funcionarios.Rows.Count + ", 10";
            }

            DataTable dt = BCO.Dql(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Capa

                byte[] imagem = (byte[])(dt.Rows[i].ItemArray[4]);

                MemoryStream ms = new MemoryStream(imagem);

                //Dados Restantes

                string nome = dt.Rows[i].ItemArray[0].ToString();
                string cpf = dt.Rows[i].ItemArray[1].ToString();
                string sexo = dt.Rows[i].ItemArray[2].ToString();
                string dataCadastro = Convert.ToDateTime(dt.Rows[i].ItemArray[3]).ToString("dd/MM/yyyy");
                string status = dt.Rows[i].ItemArray[5].ToString();
                string codigoUsuario = dt.Rows[i].ItemArray[6].ToString();

                //Adicionando itens ao data grid view

                bool checado = (codigos.IndexOf(cpf) == -1) ? false : true;

                dgv_funcionarios.Rows.Add(codigoUsuario, checado, System.Drawing.Image.FromStream(ms), nome, cpf, dataCadastro, sexo, status);
            }

            panel5.Height = (40 * dgv_funcionarios.Rows.Count) + 50;

            btn_carregarMais.Visible = true;
            img_loading.Visible = false;
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar funcionário...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar funcionário...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            F_CadFuncionario c = new F_CadFuncionario();

            c.ShowDialog();
        }

        private void dgv_funcionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_funcionarios.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_funcionarios.Rows[e.RowIndex].Cells[0].Value.ToString(); // Codigo do usuário selecionado

                if (e.ColumnIndex == 8) //Emitir Mensagem
                {
                    F_EnviaMensagem f = new F_EnviaMensagem(codigo, "F");
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 9) //Deletar Aluno
                {
                    F_PegarSenhaUsuario f = new F_PegarSenhaUsuario(null, null, this, codigo, instituicao);
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 10) //Editar dados
                {
                    F_EditaFuncionario f = new F_EditaFuncionario(dgv_funcionarios.Rows[e.RowIndex].Cells[4].Value.ToString(), this);
                    f.ShowDialog();
                }
            }
        }

        private void btn_filtro_Click(object sender, EventArgs e)
        {
            F_DefineFiltroFuncionario f = new F_DefineFiltroFuncionario(this);
            f.ShowDialog();
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                verificaSelecionados();

                dgv_funcionarios.Rows.Clear();

                carregarMais();
            }
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            verificaSelecionados();

            if (codigos.Count > 0)
            {
                F_RelatorioFuncionario f = new F_RelatorioFuncionario(codigos);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione pelo menos um funcionário para emitir o relatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
