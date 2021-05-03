using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    public partial class F_PegarSenhaTurma : Form
    {
        F_CursosInstituicao formulario = null;
        string codigo = string.Empty;

        public F_PegarSenhaTurma(F_CursosInstituicao f, string codigo)
        {
            InitializeComponent();

            this.codigo = codigo;
            this.formulario = f;
        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (tb_senha.Text.Trim().Length > 0)
            {
                //Criptografando senha digitada

                string senha = string.Empty;

                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(tb_senha.Text));

                foreach (byte b in hash)
                {
                    senha += b.ToString("x2");
                }

                //Verificando senha

                if (senha == UsuarioLogado.senha)
                {
                    DataTable dt = BCO.Dql("SELECT * FROM curso_usuario WHERE curso_id_curso = " + codigo + " LIMIT 1");

                    if(dt.Rows.Count == 0)
                    {
                        BCO.Dml("DELETE FROM curso WHERE id_curso = " + codigo + " LIMIT 1", "Turma deletada com sucesso", "Turma não deletada, Ocorreu um erro na operação de exclusão");

                        formulario.dgv_cursosInstituicao.Rows.Clear();
                        formulario.carregarMais();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Esta turma está associada há diversos alunos, portanto não é possivel deletá-la!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Senha inválida, não foi possivel deletar essa turma", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                lb_senha.Visible = true;
            }
        }

        private void tb_senha_TextChanged(object sender, EventArgs e)
        {
            lb_senha.Visible = false;
        }
    }
}
