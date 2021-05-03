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
using MySql.Data;
using MySql.Data.MySqlClient;
using Biblioteca01;

namespace BibliotecaEtec
{
    public partial class F_SelecionarCurso : Form
    {
        private Form form;
        private int tipo;

        public F_SelecionarCurso(Form f, int t)
        {
            InitializeComponent();

            this.form = f;
            this.tipo = t;
        }

        private void F_SelecionarCurso_Load(object sender, EventArgs e)
        {
            //Carregando instituições

            DataTable dt = new DataTable();

            dt = BCO.Dql("SELECT id_instituicao, nome_instituicao FROM instituicao");

            if (dt.Rows.Count > 0)
            {
                cb_instituicao.DataSource = dt;
                cb_instituicao.DisplayMember = "nome_instituicao";
                cb_instituicao.ValueMember = "id_instituicao";
            }

            //Arredondando imagem

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        private void carregarMais()
        {
            string id_instituicao = cb_instituicao.SelectedValue.ToString();
            string texto = string.Empty;

            if (tb_pesquisa.Text.Trim() == "Pesquisar curso...")
            {
                texto = string.Empty;
            }
            else
            {
                texto = tb_pesquisa.Text.Trim();
            }

            //Carregando cursos

            DataTable dt = new DataTable();

            try
            {
                dt = BCO.Dql("SELECT id_curso, nome_curso, modulo_serie, CASE periodo WHEN 'M' THEN 'Manhã' WHEN 'T' THEN 'Tarde' WHEN 'N' THEN 'Noite' ELSE 'Integral' END, turma FROM curso WHERE nome_curso LIKE '%" + texto + "%' AND id_instituicao_curso = " + id_instituicao + " ORDER BY nome_curso LIMIT " + dgv_curso.Rows.Count + ", 10");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i].ItemArray[0].ToString();
                    string nomeCurso = dt.Rows[i].ItemArray[1].ToString();
                    string moduloSerie = dt.Rows[i].ItemArray[2].ToString();
                    string periodo = dt.Rows[i].ItemArray[3].ToString();
                    string turma = dt.Rows[i].ItemArray[4].ToString();

                    dgv_curso.Rows.Add(id, nomeCurso, moduloSerie, periodo, turma);
                }
            }
            catch { }

            panel5.Height = (50 * dgv_curso.Rows.Count) + 50;
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

        private void dgv_editora_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (this.tipo == 1)
                {
                    F_CadAlunos fa;

                    string codigoCurso = dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[0].Value.ToString();

                    fa = (F_CadAlunos)form;

                    if (fa.cod_cursos.IndexOf(codigoCurso) == -1)
                    {
                        fa.cod_cursos.Add(codigoCurso);
                        fa.list_cursos.Items.Add(dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[1].Value.ToString() + " - Módulo/Série: " + dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[2].Value.ToString() + " - Periodo: " + dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[3].Value.ToString() + " - Turma: " + dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[4].Value.ToString());

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Já foi adicionado este curso na lista, Não é possivel adicionar novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    F_EditaAluno fa;

                    string codigoCurso = dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[0].Value.ToString();

                    fa = (F_EditaAluno)form;

                    if (fa.cod_cursos.IndexOf(codigoCurso) == -1)
                    {
                        fa.cod_cursos.Add(codigoCurso);
                        fa.list_cursos.Items.Add(dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[1].Value.ToString() + " - Módulo/Série: " + dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[2].Value.ToString() + " - Periodo: " + dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[3].Value.ToString() + " - Turma: " + dgv_curso.Rows[dgv_curso.SelectedRows[0].Index].Cells[4].Value.ToString());

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Já foi adicionado este curso na lista, Não é possivel adicionar novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void tb_pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgv_curso.Rows.Clear();

                carregarMais();
            }
        }

        private void cb_instituicao_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_instituicao.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                dgv_curso.Rows.Clear();

                carregarMais();
            }
        }
    }
}
