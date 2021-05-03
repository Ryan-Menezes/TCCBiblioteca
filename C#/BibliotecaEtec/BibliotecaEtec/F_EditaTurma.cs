using Biblioteca01;
using MySql.Data.MySqlClient;
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
    public partial class F_EditaTurma : Form
    {
        F_CursosInstituicao formulario = null;
        string codigo = string.Empty;

        public F_EditaTurma(F_CursosInstituicao f, string codigo)
        {
            InitializeComponent();

            this.codigo = codigo;
            this.formulario = f;

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

            //Preenchendo cb_periodo

            Dictionary<string, string> periodos = new Dictionary<string, string>();
            periodos.Add("M", "Manhã");
            periodos.Add("T", "Tarde");
            periodos.Add("N", "Noite");
            periodos.Add("I", "integral");

            cb_periodo.DataSource = new BindingSource(periodos, null);
            cb_periodo.DisplayMember = "Value";
            cb_periodo.ValueMember = "Key";

            //Buscando dados da turma

            DataTable dt = BCO.Dql("SELECT * FROM curso WHERE id_curso = " + codigo + " LIMIT 1");

            if(dt.Rows.Count > 0) 
            {
                tb_nome.Text = dt.Rows[0].ItemArray[1].ToString();
                tb_moduloSerie.Value = Convert.ToDecimal(dt.Rows[0].ItemArray[2].ToString());
                cb_periodo.SelectedValue = dt.Rows[0].ItemArray[3].ToString();
                tb_turma.Text = dt.Rows[0].ItemArray[4].ToString();
                cb_tipo.SelectedValue = dt.Rows[0].ItemArray[5].ToString();
                cb_instituicao.SelectedValue = dt.Rows[0].ItemArray[6].ToString();
            }
            else
            {
                this.Close();
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            bool verifica = true;

            if(tb_nome.Text.Trim().Length == 0)
            {
                lb_nome.Visible = true;
                verifica = false;
            }

            if (tb_turma.Text.Trim().Length == 0)
            {
                tb_turma.Visible = true;
                verifica = false;
            }

            if (verifica)
            {
                MySqlConnection conexao = BCO.conexaoBCO();
                var cmd = conexao.CreateCommand();

                try
                {
                    cmd.CommandText = "UPDATE curso SET nome_curso = @nome, modulo_serie = @modulo, periodo = @periodo, turma = @turma, tipo = @tipo, id_instituicao_curso = @id WHERE id_curso = @idCurso LIMIT 1";
                    cmd.Parameters.AddWithValue("@nome", tb_nome.Text.Trim());
                    cmd.Parameters.AddWithValue("@modulo", tb_moduloSerie.Value.ToString());
                    cmd.Parameters.AddWithValue("@periodo", cb_periodo.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@turma", tb_turma.Text.Trim());
                    cmd.Parameters.AddWithValue("@tipo", cb_tipo.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@id", cb_instituicao.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@idCurso", codigo);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Turma editada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    formulario.dgv_cursosInstituicao.Rows.Clear();
                    formulario.carregarMais();
                }
                catch{
                    MessageBox.Show("Turma não editada, Ocorreu um erro na operação de edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
