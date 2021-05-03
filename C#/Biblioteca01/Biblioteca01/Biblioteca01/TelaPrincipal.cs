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
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
           // F_Login f_Login = new F_Login(this);
           // f_Login.ShowDialog();
            //TelaLogin telaLogin = new TelaLogin();
           // telaLogin.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_livros_Click(object sender, EventArgs e)
        {
            F_Livro f_Livro = new F_Livro();
            f_Livro.ShowDialog();
        }

        private void btn_funcionario_Click(object sender, EventArgs e)
        {
            F_Funcionario f_Funcionario = new F_Funcionario();
            f_Funcionario.ShowDialog();
        }

        private void btn_alunos_Click(object sender, EventArgs e)
        {
            F_Aluno f_Aluno = new F_Aluno();
            f_Aluno.ShowDialog();
        }

        private void btn_professores_Click(object sender, EventArgs e)
        {
            F_Professor f_Professor = new F_Professor();
            f_Professor.ShowDialog();
        }


        private void btn_locacoes_Click(object sender, EventArgs e)
        {
            F_Alocacao f_Alocacao = new F_Alocacao();
            f_Alocacao.ShowDialog();
        }

        private void btn_cursos_Click_1(object sender, EventArgs e)
        {
            F_Cursos f_Cursos = new F_Cursos();
            f_Cursos.ShowDialog();
        }
    }
}
