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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }
        private void TelaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tb_senha_Enter(object sender, EventArgs e)
        {
            if (tb_rm.Text.Trim() == "Senha")
            {
                tb_rm.Clear();
                tb_rm.ForeColor = Color.White;
            }

        }

        private void tb_senha_Leave(object sender, EventArgs e)
        {
            if (tb_senha.Text.Trim().Length == 0)
            {
                tb_senha.PasswordChar = '\0';
                tb_senha.Text = "Senha";
                tb_senha.ForeColor = Color.Gray;
            }
        }

        private void btn_visualizar_Click(object sender, EventArgs e)
        {
            //   if (btn_visualizar.IconChar == FontAwesome.Sharp.IconChar.EyeSlash)
            //   {
            //       tb_senha.PasswordChar = '\0';
            //       btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            //   }
            //   else
            //   {
            //       if (tb_senha.Text.Trim() != "Senha")
            //       {
            //           tb_senha.PasswordChar = '*';
            //       }
            //
            //       btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            //   }

        }

        private void tb_rm_Enter(object sender, EventArgs e)
        {
            if (tb_rm.Text.Trim() == "RM")
            {
                tb_rm.Clear();
                tb_rm.ForeColor = Color.White;
            }
        }

        private void tb_rm_Leave(object sender, EventArgs e)
        {
            if (tb_rm.Text.Trim().Length == 0)
            {
                tb_rm.PasswordChar = '\0';
                tb_rm.Text = "RM";
                tb_rm.ForeColor = Color.Gray;
            }
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {

        }

        private void tb_rm_TextChanged(object sender, EventArgs e)
        {
            lb_rm.Visible = false;
            //barra_rm.Visible = false;
        }

        private void tb_senha_TextChanged(object sender, EventArgs e)
        {
            lb_senha.Visible = false;
            //barra_senha.Visible = false;
        }

        private void lb_esqueciSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //F_EsqueceSenha f = new F_EsqueceSenha();
            //f.ShowDialog();
        }
    }
}
