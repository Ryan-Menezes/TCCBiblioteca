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
    public partial class F_CursosInstituicao : Form
    {
        string instituicao = string.Empty;

        public F_CursosInstituicao()
        {
            InitializeComponent();

            foreach (KeyValuePair<string, string> valor in UsuarioLogado.instituicoes)
            {
                instituicao = valor.Key;
                break;
            }

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();

            //Preenchendo combo box instituições

            cb_instituicao.DataSource = new BindingSource(UsuarioLogado.instituicoes, null);
            cb_instituicao.DisplayMember = "Value";
            cb_instituicao.ValueMember = "Key";
        }

        public void carregarMais()
        {
            btn_carregarMais.Visible = false;
            img_loading.Visible = true;

            string texto = string.Empty;

            if(tb_pesquisa.Text.Trim() == "Pesquisar curso...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            string sql = "SELECT c.id_curso, c.nome_curso, c.modulo_serie, CASE c.periodo WHEN 'M' THEN 'Manhã' WHEN 'T' THEN 'Tarde' WHEN 'N' THEN 'Noite' ELSE 'Integral' END, c.turma, c.tipo, i.nome_instituicao FROM curso AS c INNER JOIN instituicao AS i ON c.id_instituicao_curso = i.id_instituicao WHERE id_instituicao_curso = " + instituicao + " AND c.nome_curso LIKE '%" + texto + "%' ORDER BY nome_curso LIMIT " + dgv_cursosInstituicao.Rows.Count + ", 10";

            DataTable dt = BCO.Dql(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Dados Restantes

                string codigo = dt.Rows[i].ItemArray[0].ToString();
                string nome = dt.Rows[i].ItemArray[1].ToString();
                string moduloSerie = dt.Rows[i].ItemArray[2].ToString();
                string periodo = dt.Rows[i].ItemArray[3].ToString();
                string turma = dt.Rows[i].ItemArray[4].ToString();
                string tipo = dt.Rows[i].ItemArray[5].ToString();
                string nomeInstituicao = dt.Rows[i].ItemArray[6].ToString();

                //Adicionando itens ao data grid view

                dgv_cursosInstituicao.Rows.Add(codigo, nome, moduloSerie, periodo, turma, tipo, nomeInstituicao);
            }

            panel5.Height = (40 * dgv_cursosInstituicao.Rows.Count) + 50;

            btn_carregarMais.Visible = true;
            img_loading.Visible = false;
        }

        private void tb_pesquisa_Enter(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim() == "Pesquisar curso...")
            {
                tb_pesquisa.Clear();
                tb_pesquisa.ForeColor = Color.White;
            }
        }

        private void tb_pesquisa_Leave(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text.Trim().Length == 0)
            {
                tb_pesquisa.Text = "Pesquisar curso...";
                tb_pesquisa.ForeColor = Color.Gray;
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            F_CadCurso c = new F_CadCurso();

            c.ShowDialog();
        }

        private void cb_instituicao_SelectedValueChanged(object sender, EventArgs e)
        {
            instituicao = cb_instituicao.SelectedValue.ToString();

            dgv_cursosInstituicao.Rows.Clear();

            carregarMais();
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgv_cursosInstituicao.Rows.Clear();

                carregarMais();
            }
        }

        private void dgv_cursosInstituicao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_cursosInstituicao.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_cursosInstituicao.Rows[e.RowIndex].Cells[0].Value.ToString(); //Código da alocação selecionada

                if (e.ColumnIndex == 7) //Deletar Livro
                {
                    F_PegarSenhaTurma f = new F_PegarSenhaTurma(this, codigo);
                    f.ShowDialog();
                }
                else if (e.ColumnIndex == 8) //Editar dados
                {
                    F_EditaTurma f = new F_EditaTurma(this, codigo);
                    f.ShowDialog();
                }
            }
        }
    }
}
