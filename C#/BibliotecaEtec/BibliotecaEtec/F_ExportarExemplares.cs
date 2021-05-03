using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BibliotecaEtec
{
    public partial class F_ExportarExemplares : Form
    {
        F_Livros formulario = null;
        string codigoL = string.Empty;
        string codigoE = string.Empty;

        public F_ExportarExemplares(F_Livros f, string codigoL, string codigoE)
        {
            InitializeComponent();

            this.formulario = f;
            this.codigoL = codigoL;
            this.codigoE = codigoE;

            //Buscando dados do livro

            DataTable dt = BCO.Dql("SELECT l.titulo, l.img_livro, e.quantidade, e.id_instituicao FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro WHERE l.cod_livro = " + codigoL + " AND e.id_exemplares = " + codigoE + " AND l.tombo IS NOT NULL LIMIT 1");

            if(dt.Rows.Count > 0)
            {
                byte[] capa = (byte[])dt.Rows[0].ItemArray[1];

                this.img_livro.Image = System.Drawing.Image.FromStream(new MemoryStream(capa));
                this.lb_titulo.Text = dt.Rows[0].ItemArray[0].ToString();
                this.lb_exemplares.Text = dt.Rows[0].ItemArray[2].ToString();

                string id_instituicao = dt.Rows[0].ItemArray[3].ToString();
                string maximo = dt.Rows[0].ItemArray[2].ToString();

                //Carregando as instituições

                dt = BCO.Dql("SELECT id_instituicao, nome_instituicao FROM instituicao WHERE id_instituicao != " + id_instituicao);

                cb_instituicao.DataSource = new BindingSource(dt, null);
                cb_instituicao.DisplayMember = "nome_instituicao";
                cb_instituicao.ValueMember = "id_instituicao";

                //Definindo max e min de exemplares

                tb_exemplares.Maximum = Convert.ToDecimal(maximo);
                lb_exemplares.Text = (tb_exemplares.Maximum - tb_exemplares.Value).ToString();
            }
            else
            {
                this.Close();
            }
        }

        private void atualizaExemplares(object sender, EventArgs e)
        {
            lb_exemplares.Text = (tb_exemplares.Maximum - tb_exemplares.Value).ToString();
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            int ExemplaresRestantes = int.Parse(tb_exemplares.Maximum.ToString()) - int.Parse(tb_exemplares.Value.ToString());

            if(ExemplaresRestantes == 0)
            {
                DialogResult res = MessageBox.Show("Você realmente deseja exportar todos os exemplares deste livro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(res == DialogResult.No)
                {
                    return;
                }
            }

            DataTable dt = BCO.Dql("SELECT id_exemplares, quantidade FROM exemplares WHERE livro_tombo_exemplares = " + codigoL + " AND id_instituicao = " + cb_instituicao.SelectedValue.ToString() + " LIMIT 1");

            //Descontando valor

            if(ExemplaresRestantes > 0)
            {
                BCO.Dml("UPDATE exemplares SET quantidade = " + ExemplaresRestantes.ToString() + " WHERE id_exemplares = " + codigoE + " LIMIT 1");
            }
            else
            {
                BCO.Dml("DELETE FROM exemplares WHERE id_exemplares = " + codigoE + " LIMIT 1");
            }

            //Adicionando os exemplares

            if(dt.Rows.Count == 0)
            {
                BCO.Dml("INSERT INTO exemplares (quantidade, livro_tombo_exemplares, id_instituicao)  VALUES (" + tb_exemplares.Value.ToString() + ", " + codigoL + ", " + cb_instituicao.SelectedValue.ToString() + ")", "Exemplares exportados com sucesso!", "Não foi possivel exportar os exemplares, Ocorreu um erro no processo");
            }
            else
            {
                BCO.Dml("UPDATE exemplares SET quantidade = " + (int.Parse(dt.Rows[0].ItemArray[1].ToString()) + int.Parse(tb_exemplares.Value.ToString())).ToString() + " WHERE id_exemplares = " + dt.Rows[0].ItemArray[0].ToString() + " LIMIT 1", "Exemplares exportados com sucesso!", "Não foi possivel exportar os exemplares, Ocorreu um erro no processo");
            }

            formulario.dgv_livros.Rows.Clear();
            formulario.carregarMais();

            if(ExemplaresRestantes == 0)
            {
                this.Close();
            }
            else
            {
                tb_exemplares.Maximum = Convert.ToDecimal(ExemplaresRestantes);
                tb_exemplares.Value = 1;
                lb_exemplares.Text = (tb_exemplares.Maximum - tb_exemplares.Value).ToString();
            }
        }
    }
}
