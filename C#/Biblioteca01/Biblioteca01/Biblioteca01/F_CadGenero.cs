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
    public partial class F_CadGenero : Form
    {
        public F_CadGenero()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();

            if (txt_genero.Text == "")
            {
                MessageBox.Show("Digite o nome do gênero!");
                txt_genero.Focus();
                return;
            }
            livro.nome_genero = txt_genero.Text;
            BCO.cad_genero(livro);
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();
            livro.nome_genero = txt_genero.Text;
            BCO.excluir_genero(livro);
        }
    }
}
