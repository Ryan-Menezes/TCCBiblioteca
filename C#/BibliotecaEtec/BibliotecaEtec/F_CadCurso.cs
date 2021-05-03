using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEtec;

namespace BibliotecaEtec
{
    public partial class F_CadCurso : Form
    {
        public List<string> turmas = new List<string>();
        public List<string> periodos = new List<string>();
        public List<string> moduloSeries = new List<string>();

        public F_CadCurso()
        {
            InitializeComponent();

            //Preenchendo cb_instituicao

            cb_instituicao.DataSource = new BindingSource(UsuarioLogado.instituicoes, null);
            cb_instituicao.DisplayMember = "Value";
            cb_instituicao.ValueMember = "Key";

            //Preenchendo cb_tipo

            Dictionary<string, string> tipo = new Dictionary<string, string>();
            tipo.Add("EM", "Ensino Médio(EM)");
            tipo.Add("ETIM", "Ensino técnico integrado ao médio(ETIM)");
            tipo.Add("MOD", "Módular(MOD)");
            tipo.Add("NOV", "Novotec(NOV)");

            cb_tipo.DataSource = new BindingSource(tipo, null);
            cb_tipo.DisplayMember = "Value";
            cb_tipo.ValueMember = "Key";
        }

        private void btn_adicionarTurmas_Click(object sender, EventArgs e)
        {
            F_AdicionaTurma f = new F_AdicionaTurma(this);
            f.ShowDialog();
        }

        private void list_turmas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list_turmas.SelectedIndex >= 0)
            {
                turmas.RemoveAt(list_turmas.SelectedIndex);
                periodos.RemoveAt(list_turmas.SelectedIndex);
                moduloSeries.RemoveAt(list_turmas.SelectedIndex);
                list_turmas.Items.RemoveAt(list_turmas.SelectedIndex);
            }
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            bool verifica = true;

            if(list_turmas.Items.Count == 0)
            {
                lb_turmas.Visible = true;
                verifica = false;
            }

            if (tb_nome.Text.Trim().Length == 0)
            {
                lb_nome.Visible = true;
                verifica = false;
            }

            if (verifica) 
            {
                Curso curso = new Curso();

                curso.nome_curso = tb_nome.Text.ToString();
                curso.modulo_series = moduloSeries;
                curso.turmas = turmas;
                curso.periodos = periodos;
                curso.tipo = cb_tipo.SelectedValue.ToString();
                curso.id_instituicao = cb_instituicao.SelectedValue.ToString();

                BCO.cad_curso(curso);
            }
        }

        private void tb_nome_TextChanged(object sender, EventArgs e)
        {
            lb_nome.Visible = false;
        }

        private void list_turmas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_turmas.Visible = false;
        }
    }
}
