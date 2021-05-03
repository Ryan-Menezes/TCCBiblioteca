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
    public partial class F_PegaTomboIsbn : Form
    {
        F_AdicionaExemplares formulario;
        string codigo = string.Empty;
        string texto = string.Empty;

        public F_PegaTomboIsbn(F_AdicionaExemplares f, string codigo, string texto)
        {
            InitializeComponent();
            this.formulario = f;
            this.codigo = codigo;
            this.texto = texto;
        }

        private void btn_cadastra_Click(object sender, EventArgs e)
        {
            bool verifica = true;

            if (txt_tombo.Text.Trim().Length == 0)
            {
                lb_tombo.Visible = true;
                verifica = false;
            }

            if (tb_isbn.Text.Trim().Length == 0)
            {
                lb_isbn.Visible = true;
                verifica = false;
            }

            if (verifica)
            {
                this.formulario.tombo = txt_tombo.Text.Trim();
                this.formulario.isbn = tb_isbn.Text.Trim();
                this.formulario.tb_livro.Tag = this.codigo;
                this.formulario.tb_livro.Text = this.texto + " - Tombo: " + txt_tombo.Text.Trim();

                this.Close();
            }
        }

        private void txt_tombo_TextChanged(object sender, EventArgs e)
        {
            lb_tombo.Visible = false;
        }

        private void tb_isbn_TextChanged(object sender, EventArgs e)
        {
            lb_isbn.Visible = false;
        }
    }
}
