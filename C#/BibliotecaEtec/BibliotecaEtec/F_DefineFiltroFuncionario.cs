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
    public partial class F_DefineFiltroFuncionario : Form
    {
        F_Funcionarios formulario = null;

        public F_DefineFiltroFuncionario(F_Funcionarios f)
        {
            InitializeComponent();

            formulario = f;

            Dictionary<string, string> pesquisa = new Dictionary<string, string>();
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
        }

        private void btn_defineFiltro_Click(object sender, EventArgs e)
        {
            formulario.tipoPesquisa = cb_pesquisa.SelectedValue.ToString();
            formulario.status = cb_status.SelectedValue.ToString();
            formulario.sexo = cb_sexo.SelectedValue.ToString();
            formulario.instituicao = cb_instituicao.SelectedValue.ToString();

            formulario.dgv_funcionarios.Rows.Clear();
            formulario.carregarMais();

            this.Close();
        }
    }
}
