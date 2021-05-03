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
    public partial class F_DefineFiltroAlocacao : Form
    {
        F_Alocacoes formulario = null;

        public F_DefineFiltroAlocacao(F_Alocacoes f)
        {
            InitializeComponent();

            formulario = f;

            //Preenchendo combo box pesquisa

            Dictionary<string, string> pesquisa = new Dictionary<string, string>();
            pesquisa.Add("TI", "Titulo do Livro");
            pesquisa.Add("TO", "Tombo do Livro");

            cb_pesquisa.DataSource = new BindingSource(pesquisa, null);
            cb_pesquisa.DisplayMember = "Value";
            cb_pesquisa.ValueMember = "Key";

            //Preenchendo combo box status

            Dictionary<string, string> situacao = new Dictionary<string, string>();
            situacao.Add("T", "Todas");
            situacao.Add("N", "Normal");
            situacao.Add("A", "Atrasado");

            cb_situacao.DataSource = new BindingSource(situacao, null);
            cb_situacao.DisplayMember = "Value";
            cb_situacao.ValueMember = "Key";

            //Preenchendo combo box sexo

            Dictionary<string, string> tipo = new Dictionary<string, string>();
            tipo.Add("T", "Todos");
            tipo.Add("A", "Aluno");
            tipo.Add("P", "Professor");
            tipo.Add("F", "Funcionário");

            cb_tipo.DataSource = new BindingSource(tipo, null);
            cb_tipo.DisplayMember = "Value";
            cb_tipo.ValueMember = "Key";

            //Preenchendo combo box instituições

            cb_instituicao.DataSource = new BindingSource(UsuarioLogado.instituicoes, null);
            cb_instituicao.DisplayMember = "Value";
            cb_instituicao.ValueMember = "Key";
        }

        private void btn_defineFiltro_Click(object sender, EventArgs e)
        {
            formulario.tipoPesquisa = cb_pesquisa.SelectedValue.ToString();
            formulario.situacao = cb_situacao.SelectedValue.ToString();
            formulario.tipo = cb_tipo.SelectedValue.ToString();
            formulario.instituicao = cb_instituicao.SelectedValue.ToString();

            formulario.dgv_alocacoes.Rows.Clear();
            formulario.carregarMais();
            this.Close();
        }
    }
}
