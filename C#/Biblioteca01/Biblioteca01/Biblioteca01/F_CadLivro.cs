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
    public partial class F_CadLivro : Form
    {
        public F_CadLivro()
        {
            InitializeComponent();
        }

        private void btn_cadastro_genero_Click(object sender, EventArgs e)
        {
            F_CadGenero f_CadGenero = new F_CadGenero();
            f_CadGenero.ShowDialog();
        }

        private void F_CadLivro_Load(object sender, EventArgs e)
        {
            string vqueryGenero = "select * from genero order by id_genero";
            cb_genero.Items.Clear();
            cb_genero.DataSource = BCO.Dql(vqueryGenero);
            cb_genero.DisplayMember = "id_genero";


            string vqueryAutor = "select * from autor order by id_autor";
            cb_autor.Items.Clear();
            cb_autor.DataSource = BCO.Dql(vqueryAutor);
            cb_autor.DisplayMember = "id_autor";

            string vqueryEditora = "select * from editora order by id_editora";
            cb_editora.Items.Clear();
            cb_editora.DataSource = BCO.Dql(vqueryEditora);
            cb_editora.DisplayMember = "id_editora";

            string vqueryInstituicao = "select * from instituicao order by cod_instituicao";
            cb_id_instituicao.Items.Clear();
            cb_id_instituicao.DataSource = BCO.Dql(vqueryInstituicao);
            cb_id_instituicao.DisplayMember = "cod_instituicao";
        }

        private void btn_cadastro_autor_Click(object sender, EventArgs e)
        {
            F_CadAutor f_CadAutor = new F_CadAutor();
            f_CadAutor.ShowDialog();
        }

        private void btn_cadastro_editora_Click(object sender, EventArgs e)
        {
            F_CadEditora f_CadEditora = new F_CadEditora();
            f_CadEditora.ShowDialog();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            
            Livro livro = new Livro();

            if (nud_tombo.Text == "")
            {
                MessageBox.Show("Digite o Tombo !");
                nud_tombo.Focus();
                return;
            }
            else if ((Convert.ToInt32(nud_tombo.Text) >= nud_tombo.Maximum))
            {
                MessageBox.Show("Tombo inválido !");
                nud_tombo.Focus();
                return;
            }
            livro.tombo = Convert.ToInt32(Math.Round(nud_tombo.Value, 0));

            if (txt_titulo.Text == "")
            {
                MessageBox.Show("Digite o título !");
                txt_titulo.Focus();
                return;
            }
            livro.titulo = txt_titulo.Text;

            livro.ano_publicacao = Convert.ToDateTime(dtp_ano_publicacao.Value).ToString("yyy/MM/dd");
            livro.volume = Convert.ToInt32(Math.Round(nud_volume.Value, 0));
            livro.edicao = Convert.ToInt32(Math.Round(nud_edicao.Value, 0));
            livro.insercao = Convert.ToDateTime(dtp_insercao.Value).ToString("yyy/MM/dd");

            if (txt_isbn.Text == "")
            {
                MessageBox.Show("Digite o isbn !");
                txt_isbn.Focus();
                return;
            }
            livro.isbn = txt_isbn.Text;

            if (cb_idioma.Text == "")
            {
                MessageBox.Show("Digite o idioma !");
                cb_idioma.Focus();
                return;
            }
            livro.idioma = cb_idioma.Text;

            if (cb_editora.Text == "")
            {
                MessageBox.Show("Digite o código da editora !");
                cb_editora.Focus();
                return;
            }
            livro.editora_id_editora = Convert.ToInt32(cb_editora.Text);

            if (cb_genero.Text == "")
            {
                MessageBox.Show("Digite o código do gênero !");
                cb_genero.Focus();
                return;
            }
            livro.genero_id_genero = Convert.ToInt32(cb_genero.Text);

            if (cb_autor.Text == "")
            {
                MessageBox.Show("Digite o código do autor !");
                cb_autor.Focus();
                return;
            }
            livro.autor_id_autor =Convert.ToInt32(cb_autor.Text);

            livro.nome_colaboradores = txt_colaboradores.Text;
            livro.colaborador_id_colaborador = Convert.ToInt32(nud_tombo.Text);

            if (cb_editora.Text == "")
            {
                MessageBox.Show("Digite código editora !");
                cb_editora.Focus();
                return;
            }
            livro.nome_editora = cb_editora.Text;

            if (nud_exemplares.Text == "")
            {
                MessageBox.Show("Digite quantidade de exemplares !");
                nud_exemplares.Focus();
                return;
            }
            livro.quantidade = Convert.ToInt32(Math.Round(nud_exemplares.Value, 0)); ;
            livro.livro_tombo_exemplares = Convert.ToInt32(Math.Round(nud_tombo.Value, 0));

            if (cb_id_instituicao.Text == "")
            {
                MessageBox.Show("Digite a instituição !");
                cb_id_instituicao.Focus();
                return;
            }

            livro.id_instituicao = Convert.ToInt32(cb_id_instituicao.Text);

            BCO.cad_livro(livro);
         
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();

            if (nud_tombo.Text != "")
            {
                livro.tombo = Convert.ToInt32(nud_tombo.Text);
                BCO.excluir_livro(livro);
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro();

            if (nud_tombo.Text != "" && txt_titulo.Text != "" && dtp_ano_publicacao.Text != "" && nud_exemplares.Text != "" && dtp_insercao.Text != "" && txt_isbn.Text != "" && cb_idioma.Text != "" && cb_editora.Text != "" && cb_genero.Text != "" && cb_autor.Text != "")           
            {
                // modificação no livro inteiro
                livro.tombo = Convert.ToInt32(Math.Round(nud_tombo.Value, 0));
                livro.titulo = txt_titulo.Text;
                livro.ano_publicacao = Convert.ToDateTime(dtp_ano_publicacao.Value).ToString("yyy/MM/dd");//dtp_ano_publicacao.Value; 
                livro.volume = Convert.ToInt32(Math.Round(nud_volume.Value, 0));
                livro.edicao = Convert.ToInt32(Math.Round(nud_edicao.Value, 0));
                livro.insercao = Convert.ToDateTime(dtp_insercao.Value).ToString("yyy/MM/dd");//dtp_insercao.Value;
                livro.isbn = txt_isbn.Text;
                livro.idioma = cb_idioma.Text;
                livro.editora_id_editora = Convert.ToInt32(cb_editora.Text);
                livro.genero_id_genero = Convert.ToInt32(cb_genero.Text);
                livro.autor_id_autor = Convert.ToInt32(cb_autor.Text);     
                livro.quantidade = Convert.ToInt32(Math.Round(nud_exemplares.Value, 0)); ;
                livro.livro_tombo_exemplares = Convert.ToInt32(Math.Round(nud_tombo.Value, 0));

                BCO.alterar_Livro(livro);
            }
            
        }
    }
}
