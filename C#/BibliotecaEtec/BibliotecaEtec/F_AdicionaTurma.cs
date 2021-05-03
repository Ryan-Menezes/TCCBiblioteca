using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    public partial class F_AdicionaTurma : Form
    {
        F_CadCurso formulario = null;

        public F_AdicionaTurma(F_CadCurso f)
        {
            InitializeComponent();

            formulario = f;

            //Preenchendo cb_periodo

            Dictionary<string, string> periodos = new Dictionary<string, string>();
            periodos.Add("M", "Manhã");
            periodos.Add("T", "Tarde");
            periodos.Add("N", "Noite");
            periodos.Add("I", "integral");

            cb_periodo.DataSource = new BindingSource(periodos, null);
            cb_periodo.DisplayMember = "Value";
            cb_periodo.ValueMember = "Key";
        }

        private void btn_adiciona_Click(object sender, EventArgs e)
        {
            if(tb_turma.Text.Trim().Length > 0)
            {
                bool verifica = true;

                for(int i = 0; i < formulario.turmas.Count; i++)
                {
                    if (formulario.moduloSeries[i] == tb_moduloSerie.Value.ToString() && formulario.turmas[i] == tb_turma.Text.Trim().ToUpper())
                    {
                        verifica = false;
                    }
                }

                if (verifica)
                {
                    formulario.turmas.Add(tb_turma.Text.Trim().ToUpper());
                    formulario.periodos.Add(cb_periodo.SelectedValue.ToString());
                    formulario.moduloSeries.Add(tb_moduloSerie.Value.ToString());

                    formulario.list_turmas.Items.Add(tb_moduloSerie.Value.ToString() + "º Módulo/Série - Turma: " + tb_turma.Text.Trim().ToUpper() + " - Periodo: " + cb_periodo.Text);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Já existe uma turma como essa na lista, não é possível adicioná-la novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                lb_turma.Visible = true;
            }
        }

        private void tb_turma_KeyUp(object sender, KeyEventArgs e)
        {
            tb_turma.Text = tb_turma.Text.ToUpper();
        }
    }
}
