using Biblioteca01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    public partial class F_EditaAlocacao : Form
    {
        F_Alocacoes formulario = null;
        string codigo = string.Empty;

        public F_EditaAlocacao(F_Alocacoes f, string codigo)
        {
            InitializeComponent();

            this.formulario = f;
            this.codigo = codigo;

            //Buscando dados da alocação

            DataTable dt = BCO.Dql("SELECT al.data_devolucao, al.id_usuario_locacao, al.id_usuarioAdimin_locacao, l.titulo, l.img_livro, i.nome_instituicao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro As l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao WHERE id_locacao = " + this.codigo + " LIMIT 1");

            if (dt.Rows.Count > 0)
            {
                byte[] capa = (byte[])dt.Rows[0].ItemArray[4];

                this.img_livro.Image = System.Drawing.Image.FromStream(new MemoryStream(capa));
                this.lb_titulo.Text = dt.Rows[0].ItemArray[3].ToString();
                this.lb_instituicao.Text = dt.Rows[0].ItemArray[5].ToString();

                dtp_dataDevolucao.Value = Convert.ToDateTime(dt.Rows[0].ItemArray[0].ToString());

                string id_usuario = dt.Rows[0].ItemArray[1].ToString();
                string id_admin = dt.Rows[0].ItemArray[2].ToString();

                //Buscando o usuário

                dt = BCO.Dql("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_aluno FROM aluno WHERE id_usuario_aluno = " + id_usuario + " LIMIT 1");

                if(dt.Rows.Count > 0)
                {
                    lb_nomeUser.Text = dt.Rows[0].ItemArray[0].ToString();
                    lb_cpfUser.Text = dt.Rows[0].ItemArray[1].ToString();
                    this.img_perfilUser.Image = System.Drawing.Image.FromStream(new MemoryStream((byte[])dt.Rows[0].ItemArray[2]));
                }
                else
                {
                    dt = BCO.Dql("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_professor FROM professor WHERE id_usuario_professor = " + id_usuario + " LIMIT 1");

                    if (dt.Rows.Count > 0)
                    {
                        lb_nomeUser.Text = dt.Rows[0].ItemArray[0].ToString();
                        lb_cpfUser.Text = dt.Rows[0].ItemArray[1].ToString();
                        this.img_perfilUser.Image = System.Drawing.Image.FromStream(new MemoryStream((byte[])dt.Rows[0].ItemArray[2]));
                    }
                    else
                    {
                        dt = BCO.Dql("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_funcionario FROM funcionario WHERE id_usuario_funcionario = " + id_usuario + " LIMIT 1");

                        if (dt.Rows.Count > 0)
                        {
                            lb_nomeUser.Text = dt.Rows[0].ItemArray[0].ToString();
                            lb_cpfUser.Text = dt.Rows[0].ItemArray[1].ToString();
                            this.img_perfilUser.Image = System.Drawing.Image.FromStream(new MemoryStream((byte[])dt.Rows[0].ItemArray[2]));
                        }
                    }
                }

                //Buscando o administrador

                dt = BCO.Dql("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_aluno FROM aluno WHERE id_usuario_aluno = " + id_admin + " LIMIT 1");

                if (dt.Rows.Count > 0)
                {
                    lb_nomeAdmin.Text = dt.Rows[0].ItemArray[0].ToString();
                    lb_cpfAdmin.Text = dt.Rows[0].ItemArray[1].ToString();
                    this.img_perfilAdmin.Image = System.Drawing.Image.FromStream(new MemoryStream((byte[])dt.Rows[0].ItemArray[2]));
                }
                else
                {
                    dt = BCO.Dql("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_professor FROM professor WHERE id_usuario_professor = " + id_admin + " LIMIT 1");

                    if (dt.Rows.Count > 0)
                    {
                        lb_nomeAdmin.Text = dt.Rows[0].ItemArray[0].ToString();
                        lb_cpfAdmin.Text = dt.Rows[0].ItemArray[1].ToString();
                        this.img_perfilAdmin.Image = System.Drawing.Image.FromStream(new MemoryStream((byte[])dt.Rows[0].ItemArray[2]));
                    }
                    else
                    {
                        dt = BCO.Dql("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_funcionario FROM funcionario WHERE id_usuario_funcionario = " + id_admin + " LIMIT 1");

                        if (dt.Rows.Count > 0)
                        {
                            lb_nomeAdmin.Text = dt.Rows[0].ItemArray[0].ToString();
                            lb_cpfAdmin.Text = dt.Rows[0].ItemArray[1].ToString();
                            this.img_perfilAdmin.Image = System.Drawing.Image.FromStream(new MemoryStream((byte[])dt.Rows[0].ItemArray[2]));
                        }
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            BCO.Dml("UPDATE locacao SET data_devolucao = '" + Convert.ToDateTime(dtp_dataDevolucao.Value).ToString("yyyy-MM-dd") + "', notificado = FALSE WHERE id_locacao = " + this.codigo + " LIMIT 1", "Alocação editada com sucessso", "Não foi possivel editar esta alocação, Ocorreu um erro na operação de edição");

            formulario.dgv_alocacoes.Rows.Clear();
            formulario.carregarMais();
        }
    }
}
