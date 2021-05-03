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
    public partial class F_CadAutor : Form
    {
        public F_CadAutor()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();
            if (txt_nome_autor.Text == "")
            {
                MessageBox.Show("Digite o nome do autor !");
                txt_nome_autor.Focus();
                return;
            }
            livro.nome_autor = txt_nome_autor.Text;

            if (cb_nacionalidade_autor.Text == "")
            {
                MessageBox.Show("Digite a nacionalidade do autor !");
                cb_nacionalidade_autor.Focus();
                return;
            }
            livro.nacionalidade_autor = cb_nacionalidade_autor.Text;
            BCO.cad_autor(livro);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();
            livro.nome_autor = txt_nome_autor.Text;
            BCO.excluir_autor(livro);
        }

        private void F_CadAutor_Load(object sender, EventArgs e)
        {
            dgv_autor.DataSource = BCO.mostrar_autor();
            dgv_autor.Columns[0].Width = 50;
            dgv_autor.Columns[1].Width = 190;
            dgv_autor.Columns[2].Width = 120;
        }
    }
}
