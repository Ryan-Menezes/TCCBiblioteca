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
    public partial class F_Login : Form
    {
        TelaPrincipal telaPrincipal;
        DataTable dt = new DataTable();

        public F_Login()
        {
            InitializeComponent();
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {
            string rm = txt_rm.Text;
            string senha = txt_senha.Text;
            string instituicao = cb_instituicao.Text;

            if (rm == "")
            {
                MessageBox.Show("Erro - Rm não informado");
                txt_rm.Focus();
                return;
            }
            if (senha == "")
            {
                MessageBox.Show("Erro - Senha não informada");
                txt_senha.Focus();
                return;
            }


            TelaPrincipal telprin = new TelaPrincipal();   // instanciei aqui pra testar se abria o form!
            telprin.ShowDialog();


            /* if (instituicao == "")
             {
                 MessageBox.Show("Erro - Instituição não informada");
                 cb_instituicao.Focus();
                 return;
             }*/

            string sql = "select * from usuario where rm_usuario='" + rm + "' and senha='" + senha + "'";
            dt = BCO.verificacao_de_acesso(sql);

            if (dt.Rows.Count == 1)
            {
                telaPrincipal.lb_nome_usuario.Text = dt.Rows[1].Field<string>("senha");
            }
            else
            {
                MessageBox.Show("Usuario não encontrado");
            }
            //dt = BCO.verificacao_de_acesso(rm, senha);

        }
    }
}
