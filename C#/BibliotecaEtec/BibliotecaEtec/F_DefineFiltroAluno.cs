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
    public partial class F_DefineFiltroAluno : Form
    {
        F_Alunos formulario = null;

        public F_DefineFiltroAluno(F_Alunos f)
        {
            InitializeComponent();

            formulario = f;

            Dictionary<string, string> pesquisa = new Dictionary<string, string>();
            pesquisa.Add("R", "RM");
            pesquisa.Add("C", "CPF");
            pesquisa.Add("N", "Nome");

            //Preenchendo combo box pesquisa

            cb_pesquisa.DataSource = new BindingSource(pesquisa, null);
            cb_pesquisa.DisplayMember = "Value";
            cb_pesquisa.ValueMember = "Key";

            //Preenchendo combo box status

            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("T", "Todos");
            status.Add("B", "Bloqueado");
            status.Add("D", "Desbloqueado");

            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";

            //Preenchendo combo box sexo

            Dictionary<string, string> sexo = new Dictionary<string, string>();
            sexo.Add("T", "Todos");
            sexo.Add("M", "Masculino");
            sexo.Add("F", "Feminino");
            sexo.Add("O", "Outros");

            cb_sexo.DataSource = new BindingSource(sexo, null);
            cb_sexo.DisplayMember = "Value";
            cb_sexo.ValueMember = "Key";

            //Preenchendo combo box instituições

            cb_instituicao.DataSource = new BindingSource(UsuarioLogado.instituicoes, null);
            cb_instituicao.DisplayMember = "Value";
            cb_instituicao.ValueMember = "Key";

            //Preenchendo combo box turmas

            MySqlConnection conexao = BCO.conexaoBCO();
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var cmd = conexao.CreateCommand();

            string instituicao = string.Empty;

            foreach (KeyValuePair<string, string> valor in UsuarioLogado.instituicoes)
            {
                instituicao = valor.Key;
                break;
            }

            try
            {
                cmd.CommandText = String.Format("SELECT id_curso, CONCAT(nome_curso, CONCAT(' - ', CONCAT(modulo_serie, CONCAT('º Módulo/Série ', CONCAT(turma, CONCAT(' | ', CASE periodo WHEN 'M' THEN 'Manhã' WHEN 'T' THEN 'Tarde' WHEN 'N' THEN 'Noite' ELSE 'Integral' END)))))) AS turma FROM curso WHERE id_instituicao_curso = {0} ORDER BY nome_curso", instituicao);
                da = new MySqlDataAdapter(cmd.CommandText, conexao);
                da.Fill(dt);

                Dictionary<string, string> turmas = new Dictionary<string, string>();
                turmas.Add("T", "Todas");

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    turmas.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString());
                }

                cb_turma.DataSource = new BindingSource(turmas, null);
                cb_turma.DisplayMember = "Value";
                cb_turma.ValueMember = "Key";
            }
            catch {}
        }

        private void btn_defineFiltro_Click(object sender, EventArgs e)
        {
            formulario.tipoPesquisa = cb_pesquisa.SelectedValue.ToString();
            formulario.status = cb_status.SelectedValue.ToString();
            formulario.sexo = cb_sexo.SelectedValue.ToString();
            formulario.instituicao = cb_instituicao.SelectedValue.ToString();
            formulario.turma = cb_turma.SelectedValue.ToString();

            formulario.dgv_alunos.Rows.Clear();
            formulario.carregarMais();

            this.Close();
        }

        private void cb_instituicao_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_instituicao.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                MySqlConnection conexao = BCO.conexaoBCO();
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();
                var cmd = conexao.CreateCommand();

                string instituicao = cb_instituicao.SelectedValue.ToString();

                try
                {
                    cmd.CommandText = String.Format("SELECT id_curso, CONCAT(nome_curso, CONCAT(' - ', CONCAT(modulo_serie, CONCAT('º Módulo/Série ', CONCAT(turma, CONCAT(' | ', CASE periodo WHEN 'M' THEN 'Manhã' WHEN 'T' THEN 'Tarde' WHEN 'N' THEN 'Noite' ELSE 'Integral' END)))))) AS turma FROM curso WHERE id_instituicao_curso = {0} ORDER BY nome_curso", instituicao);
                    da = new MySqlDataAdapter(cmd.CommandText, conexao);
                    da.Fill(dt);

                    Dictionary<string, string> turmas = new Dictionary<string, string>();
                    turmas.Add("T", "Todas");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        turmas.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString());
                    }

                    cb_turma.DataSource = new BindingSource(turmas, null);
                    cb_turma.DisplayMember = "Value";
                    cb_turma.ValueMember = "Key";
                }
                catch { }
            }
        }
    }
}
