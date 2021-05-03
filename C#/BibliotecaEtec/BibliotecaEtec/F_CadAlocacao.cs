using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca01;

namespace BibliotecaEtec
{
    public partial class F_CadAlocacao : Form
    {
        //Lista de livros selecionados

        public List<string> cod_livros = new List<string>();

        //Fim da declaração da lista

        public F_CadAlocacao()
        {
            InitializeComponent();

            //Adicionando dados ao combo box tipo usuário

            Dictionary<string, string> tipoUsuario = new Dictionary<string, string>();

            tipoUsuario.Add("A", "Aluno");
            tipoUsuario.Add("P", "Professor");
            tipoUsuario.Add("F", "Funcionário");

            cb_tipoUsuario.DataSource = new BindingSource(tipoUsuario, null);
            cb_tipoUsuario.DisplayMember = "Value";
            cb_tipoUsuario.ValueMember = "Key";
        }

        private void btn_adicionarLivros_Click(object sender, EventArgs e)
        {
            F_SelecionarLivro f = new F_SelecionarLivro(this);
            f.ShowDialog();
        }

        private void list_livros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list_livros.SelectedIndex >= 0)
            {
                cod_livros.RemoveAt(list_livros.SelectedIndex);
                list_livros.Items.RemoveAt(list_livros.SelectedIndex);
            }
        }

        private void cb_tipoUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_tipoUsuario.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                if(cb_tipoUsuario.SelectedValue.ToString() != "F")
                {
                    tb_rmCpf.Mask = string.Empty;
                    lb_titulo.Text = "RM:";
                    lb_aviso.Text = "Digite o RM";
                }
                else
                {
                    tb_rmCpf.Mask = "000.000.000-00";
                    lb_titulo.Text = "CPF:";
                    lb_aviso.Text = "Digite o CPF";
                }
            }
        }

        private void btn_alocar_Click(object sender, EventArgs e)
        {
            //Verificando se tudo está cadastrado corretamente

            bool verifica = true;

            if(list_livros.Items.Count== 0)
            {
                verifica = false;
                lb_livro.Visible = true;
            }

            if (tb_rmCpf.Text.Trim().Length == 0)
            {
                verifica = false;
                lb_aviso.Visible = true;
            }

            //Cadastrando alocação

            if (verifica)
            {
                Alocacao alocacao = new Alocacao();

                alocacao.data_alocacao = Convert.ToDateTime(dtp_alocacao.Value).ToString("yyyy-MM-dd");
                alocacao.data_devolucao = Convert.ToDateTime(dtp_devolucao.Value).ToString("yyyy-MM-dd");
                alocacao.livros = cod_livros;
                alocacao.usuario = tb_rmCpf.Text.Trim();
                alocacao.tipoUsuario = cb_tipoUsuario.SelectedValue.ToString();

                BCO.cad_alocacao(alocacao);
            }
        }

        private void list_livros_Enter(object sender, EventArgs e)
        {
            lb_livro.Visible = false;
        }

        private void tb_rmCpf_TextChanged(object sender, EventArgs e)
        {
            lb_aviso.Visible = false;
        }
    }
}
