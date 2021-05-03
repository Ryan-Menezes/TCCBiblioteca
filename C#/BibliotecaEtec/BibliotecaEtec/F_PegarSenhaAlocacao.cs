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
    public partial class F_PegarSenhaAlocacao : Form
    {
        private string codigo = string.Empty;
        F_Alocacoes formulario = null;

        public F_PegarSenhaAlocacao(F_Alocacoes f, string codigo)
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
                    BCO.Dml("DELETE FROM locacao WHERE id_locacao = " + codigo + " LIMIT 1", "Alocação finalizada com sucesso", "Alocação não finalizada, Ocorreu um erro na operação para desalocar o livro");

                    formulario.dgv_alocacoes.Rows.Clear();
                    formulario.carregarMais();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Senha inválida, não foi possivel desalocar este livro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
