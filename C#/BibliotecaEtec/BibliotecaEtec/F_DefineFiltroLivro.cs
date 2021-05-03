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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BibliotecaEtec
{
    public partial class F_DefineFiltroLivro : Form
    {
        F_Livros formulario = null;

        public F_DefineFiltroLivro(F_Livros f)
        {
            InitializeComponent();

            formulario = f;

            Dictionary<string, string> pesquisa = new Dictionary<string, string>();
            pesquisa.Add("TI", "Titulo");
            pesquisa.Add("TO", "Tombo");
            pesquisa.Add("I", "ISBN");

            //Preenchendo combo box pesquisa

            cb_pesquisa.DataSource = new BindingSource(pesquisa, null);
            cb_pesquisa.DisplayMember = "Value";
            cb_pesquisa.ValueMember = "Key";
            
            //Preenchendo combo box instituições

            cb_instituicao.DataSource = new BindingSource(UsuarioLogado.instituicoes, null);
            cb_instituicao.DisplayMember = "Value";
            cb_instituicao.ValueMember = "Key";

            //Preenchendo combo box generos

            Dictionary<string, string> generos = new Dictionary<string, string>();
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            MySqlConnection conexao = BCO.conexaoBCO();
            var cmd = conexao.CreateCommand();
            cmd.CommandText = "SELECT * FROM genero";

            da = new MySqlDataAdapter(cmd.CommandText, conexao);
            da.Fill(dt);

            generos.Add("T", "Todos");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i].ItemArray[0].ToString();
                string nome = dt.Rows[i].ItemArray[1].ToString();

                generos.Add(id, nome);
            }

            cb_genero.DataSource = new BindingSource(generos, null);
            cb_genero.DisplayMember = "Value";
            cb_genero.ValueMember = "Key";

            conexao.Close();
        }

        private void btn_defineFiltro_Click(object sender, EventArgs e)
        {
            formulario.tipoPesquisa = cb_pesquisa.SelectedValue.ToString();
            formulario.genero = cb_genero.SelectedValue.ToString();
            formulario.instituicao = cb_instituicao.SelectedValue.ToString();

            formulario.dgv_livros.Rows.Clear();
            formulario.carregarMais();

            this.Close();
        }
    }
}
