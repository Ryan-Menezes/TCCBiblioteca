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
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Biblioteca01;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BibliotecaEtec
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            carregaMais();

            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(0, 0, 40, 40);
            btn_carregarMais.Region = new Region(g);
        }

        private void dgv_avisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv_avisos.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                string codigo = dgv_avisos.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (e.ColumnIndex == 4) //Deletar Mensagem
                {
                    DialogResult res = MessageBox.Show("Você realmente deseja excluir esta mensagem?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (res == DialogResult.Yes)
                    {
                        MySqlConnection conexao = BCO.conexaoBCO();
                        var cmd = conexao.CreateCommand();

                        try
                        {
                            cmd.CommandText = String.Format("DELETE FROM avisos WHERE id_aviso = {0} AND id_usuario_avisos = {1} LIMIT 1", codigo, UsuarioLogado.codUsuario);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Mensagem deletada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conexao.Close();

                            dgv_avisos.Rows.Clear();
                            carregaMais();
                        }
                        catch
                        {
                            MessageBox.Show("Mensagem não deletada, Ocorreu um erro no processo de exclusão!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conexao.Close();
                        }
                    }
                }
                else if (e.ColumnIndex == 5) //Visualizar Mensagem
                {
                    F_Mensagem f = new F_Mensagem(codigo);
                    f.ShowDialog();
                }
            }
        }

        private void btn_carregarMais_Click(object sender, EventArgs e)
        {
            carregaMais();
        }

        private void carregaMais()
        {
            DataTable dt = new DataTable();

            dt = BCO.Dql("SELECT id_aviso, titulo, CASE situacao WHEN 'V' THEN 'Visualizado' ELSE 'Não Visualizado' END, data_envio FROM avisos WHERE id_usuario_avisos = " + UsuarioLogado.codUsuario + " ORDER BY id_aviso DESC LIMIT " + dgv_avisos.Rows.Count + ", 10");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string codigo = dt.Rows[i].ItemArray[0].ToString();
                string titulo = dt.Rows[i].ItemArray[1].ToString();
                string situacao = dt.Rows[i].ItemArray[2].ToString();
                string data_envio = Convert.ToDateTime(dt.Rows[i].ItemArray[3]).ToString("dd/MM/yyyy");

                dgv_avisos.Rows.Add(codigo, data_envio, titulo, situacao);
            }

            panel5.Height = (40 * dgv_avisos.Rows.Count) + 50;
        }

        private void btn_recarrega_Click(object sender, EventArgs e)
        {
            dgv_avisos.Rows.Clear();
            carregaMais();
        }
    }
}
