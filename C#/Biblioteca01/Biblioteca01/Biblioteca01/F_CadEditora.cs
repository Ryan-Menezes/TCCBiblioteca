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
    public partial class F_CadEditora : Form
    {
        public F_CadEditora()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();
            if (txt_nome_editora.Text == "")
            {
                MessageBox.Show("Digite o nome da editora !");
                txt_nome_editora.Focus();
                return;
            }
            livro.nome_editora = txt_nome_editora.Text;

            if (txt_cnpj_editora.Text == "")
            {
                MessageBox.Show("Digite o cnpj !");
                txt_cnpj_editora.Focus();
                return;
            }
            livro.cnpj = txt_cnpj_editora.Text;
            BCO.cad_editora(livro);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();          
            livro.nome_editora = txt_nome_editora.Text;
            BCO.cad_editora(livro);
        }

        private void F_CadEditora_Load(object sender, EventArgs e)
        {
            dgv_editora.DataSource = BCO.mostrar_editora();
            dgv_editora.Columns[0].Width = 100;
        }
    }
}
