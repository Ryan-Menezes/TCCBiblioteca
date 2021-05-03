using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MySql.Data;
using MySql.Data.MySqlClient;
using Biblioteca01;

namespace BibliotecaEtec
{
    public partial class F_SelecionaGenero : Form
    {
        F_CadLivro formulario = null;
        F_CadLivroPDF formularioPDF = null;
        F_EditaLivro formularioE = null;
        F_EditaLivroPDF formularioEP = null;

        public F_SelecionaGenero(F_CadLivro f, F_CadLivroPDF fp, F_EditaLivro fe, F_EditaLivroPDF fep)
        {
            InitializeComponent();

            this.formulario = f;
            this.formularioPDF = fp;
            this.formularioE = fe;
            this.formularioEP = fep;
        }

        private void F_SelecionaGenero_Load(object sender, EventArgs e)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(p);

            carregarMais();
        }

        private void carregarMais()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = BCO.Dql("SELECT * FROM genero ORDER BY nome_genero LIMIT " + dgv_genero.Rows.Count + ", 10");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i].ItemArray[0].ToString();
                    string nome = dt.Rows[i].ItemArray[1].ToString();

                    dgv_genero.Rows.Add(id, nome);
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao carregar mais genêros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panel5.Height = (50 * dgv_genero.Rows.Count) + 50;
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregarMais();
        }

        private void dgv_genero_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = dgv_genero.Rows[dgv_genero.SelectedRows[0].Index].Cells[0].Value.ToString();
            string nome = dgv_genero.Rows[dgv_genero.SelectedRows[0].Index].Cells[1].Value.ToString();

            if(formulario != null)
            {
                if (formulario.generos.IndexOf(id) == -1)
                {
                    formulario.generos.Add(id);
                    formulario.list_generos.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este genêro já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(formularioPDF != null)
            {
                if (formularioPDF.generos.IndexOf(id) == -1)
                {
                    formularioPDF.generos.Add(id);
                    formularioPDF.list_generos.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este genêro já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (formularioE != null)
            {
                if (formularioE.generos.IndexOf(id) == -1)
                {
                    formularioE.generos.Add(id);
                    formularioE.list_generos.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este genêro já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (formularioEP != null)
            {
                if (formularioEP.generos.IndexOf(id) == -1)
                {
                    formularioEP.generos.Add(id);
                    formularioEP.list_generos.Items.Add(nome);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este genêro já foi adicionado na lista, Não é possivel adicioná-lo novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
