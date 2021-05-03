using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca01
{
    public partial class F_CadCursos : Form
    {
        public F_CadCursos()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();

            if (nud_cod_curso.Text == "")
            {
                MessageBox.Show("Digite o código do curso !");
                nud_cod_curso.Focus();
                return;
            }
            else if ((Convert.ToInt32(nud_cod_curso.Text) >= nud_cod_curso.Maximum))
            {
                MessageBox.Show("Curso inválido !");
                nud_cod_curso.Focus();
                return;
            }
            curso.cod_curso = Convert.ToInt32(Math.Round(nud_cod_curso.Value, 0));

            if (txt_nome_curso.Text == "")
            {
                MessageBox.Show("Digite o nome do curso !");
                txt_nome_curso.Focus();
                return;
            }
            curso.nome_curso = txt_nome_curso.Text;

            if (cb_quantidade_modulos.Text == "")
            {
                MessageBox.Show("Digite a quantidade de módulos !");
                cb_quantidade_modulos.Focus();
                return;
            }
            curso.modulo_serie = cb_quantidade_modulos.Text;

            if (cb_periodo.Text == "")
            {
                MessageBox.Show("Digite o périodo das aulas !");
                cb_periodo.Focus();
                return;
            }
            curso.periodo = cb_periodo.Text;

            if (txt_nome_turma.Text == "")
            {
                MessageBox.Show("Digite o nome da turma !");
                txt_nome_turma.Focus();
                return;
            }
            curso.turma = txt_nome_turma.Text;

            if (txt_tipo_curso.Text == "")
            {
                MessageBox.Show("Digite o tipo do curso !");
                txt_tipo_curso.Focus();
                return;
            }
            curso.tipo = txt_tipo_curso.Text;

            if (cb_cod_instituicao.Text == "")
            {
                MessageBox.Show("Digite o código da instituição !");
                cb_cod_instituicao.Focus();
                return;
            }
            curso.id_instituicao_curso = Convert.ToInt32(cb_cod_instituicao.Text);

            BCO.cad_curso(curso);
        }

        private void F_CadCursos_Load(object sender, EventArgs e)
        {
            string vqueryInstituicao = "select * from instituicao order by cod_instituicao";
            cb_cod_instituicao.Items.Clear();
            cb_cod_instituicao.DataSource = BCO.Dql(vqueryInstituicao);
            cb_cod_instituicao.DisplayMember = "cod_instituicao";
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            // Aluno aluno = new Aluno();
            Curso curso = new Curso();

            if (nud_cod_curso.Text != "")
            {
                curso.cod_curso = Convert.ToInt32(nud_cod_curso.Text);
                BCO.excluir_curso(curso);
            }
        }
    }
}
