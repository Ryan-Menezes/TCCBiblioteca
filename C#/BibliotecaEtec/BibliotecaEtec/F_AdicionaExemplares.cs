using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    public partial class F_AdicionaExemplares : Form
    {
        public List<string> editoras = new List<string>();
        public string tombo = null;
        public string isbn = null;

        public F_AdicionaExemplares()
        {
            InitializeComponent();

            //Carregando instituições

            cb_instituicao.DataSource = new BindingSource(UsuarioLogado.instituicoes, null);
            cb_instituicao.DisplayMember = "Value";
            cb_instituicao.ValueMember = "Key";
        }

        private void list_editora_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list_editora.SelectedIndex >= 0)
            {
                editoras.RemoveAt(list_editora.SelectedIndex);
                list_editora.Items.RemoveAt(list_editora.SelectedIndex);
            }
        }

        private void btn_editora_Click(object sender, EventArgs e)
        {
            F_SelecionaEditora f = new F_SelecionaEditora(null, this, null);
            f.ShowDialog();
        }

        private void btn_pegaLivro_Click(object sender, EventArgs e)
        {
            F_SelecionaLivroAdiciona f = new F_SelecionaLivroAdiciona(this);
            f.ShowDialog();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            bool verifica = true;

            if(tb_livro.Text.Trim().Length == 0)
            {
                lb_livro.Visible = true;
                verifica = false;
            }

            if(tombo != null)
            {
                if (list_editora.Items.Count == 0)
                {
                    lb_editora.Visible = true;
                    verifica = false;
                }
            }

            if (verifica)
            {
                DataTable dt = BCO.Dql("SELECT * FROM exemplares WHERE livro_tombo_exemplares = " + tb_livro.Tag.ToString() + " AND id_instituicao = " + cb_instituicao.SelectedValue.ToString() + " LIMIT 1");

                if(dt.Rows.Count == 0)
                {
                    bool tomboExiste = true;

                    //Verificando tombo

                    if(tombo == null)
                    {
                        dt = BCO.Dql("SELECT * FROM livro WHERE tombo = " + tombo + " LIMIT 1");

                        if(dt.Rows.Count > 0)
                        {
                            tomboExiste = false;
                        }
                    }

                    //Adicionando os exemplares

                    if (tomboExiste)
                    {
                        //Adicionando as editoras

                        if (editoras.Count > 0)
                        {
                            for (int i = 0; i < editoras.Count; i++)
                            {
                                dt = BCO.Dql("SELECT * FROM editora_livro WHERE id_editora = " + editoras[i] + " AND cod_livro = '" + editoras[i] + "' LIMIT 1");

                                if (dt.Rows.Count == 0)
                                {
                                    BCO.Dml("INSERT INTO editora_livro (id_editora, cod_livro) VALUES (" + editoras[i] + ", " + tb_livro.Tag.ToString() + ")");
                                }
                            }
                        }

                        //Atualizando tombo

                        if (tombo != null && isbn != null)
                        {
                            BCO.Dml("UPDATE livro SET tombo = '" + tombo + "', isbn = '" + isbn + "' WHERE cod_livro = " + tb_livro.Tag.ToString() + " LIMIT 1");
                        }

                        //Adicionando os exemplares

                        BCO.Dml("INSERT INTO exemplares (quantidade, livro_tombo_exemplares, id_instituicao)  VALUES ('" + tb_exemplares.Value.ToString() + "', " + tb_livro.Tag.ToString() + ", " + cb_instituicao.SelectedValue.ToString() + ")", "Exemplares adicionados com sucesso!", "Não foi possivel adicionar os exemplares, Ocorreu um erro no processo");

                        tb_livro.Clear();
                        tb_livro.Tag = string.Empty;
                        tb_exemplares.Value = tb_exemplares.Minimum;
                        tombo = null;
                        isbn = null;
                        list_editora.Items.Clear();
                        editoras.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Já existe um livro cadastrado com este tombo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Este livro já está cadastrado nessa instituição!" , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tb_livro_TextChanged(object sender, EventArgs e)
        {
            lb_livro.Visible = false;
        }

        private void list_editora_Enter(object sender, EventArgs e)
        {
            lb_editora.Visible = false;
        }
    }
}
