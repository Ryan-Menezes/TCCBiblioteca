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
    public partial class F_DadosPessoais : Form
    {
        public F_DadosPessoais()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void btn_alteraSenha_Click(object sender, EventArgs e)
        {
            F_AlteraSenha f = new F_AlteraSenha();
            f.ShowDialog();
        }

        private void F_DadosPessoais_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = BCO.Dql(String.Format("SELECT * FROM professor AS p INNER JOIN contato_professor AS c ON c.rm_professor_contato = p.rm_professor INNER JOIN endereco_professor AS e ON e.rm_professor_endereco = p.rm_professor INNER JOIN instituicao AS i ON i.id_instituicao = p.sede WHERE p.id_usuario_professor = {0} LIMIT 1", UsuarioLogado.codUsuario));

            lb_nome.Text = dt.Rows[0].Field<string>("nome") + " " + dt.Rows[0].Field<string>("sobrenome");
            lb_rm.Text = "RM: " + dt.Rows[0].Field<Int32>("rm_professor").ToString();
            lb_cpf.Text = "CPF: " + dt.Rows[0].Field<string>("cpf");
            lb_sexo.Text = "Sexo: " + dt.Rows[0].Field<string>("sexo");
            lb_data.Text = "Data de Cadastro: " + dt.Rows[0].Field<DateTime>("data_cadastro").ToString("dd/MM/yyyy");
            lb_sede.Text = "Sede: " + dt.Rows[0].Field<string>("nome_instituicao");
            lb_telefone.Text = "Telefone: " + dt.Rows[0].Field<string>("telefone");
            lb_celular.Text = "Celular: " + dt.Rows[0].Field<string>("celular");
            lb_email.Text = "E-Mail: " + dt.Rows[0].Field<string>("email");
            lb_cep.Text = "CEP: " + dt.Rows[0].Field<string>("cep");
            lb_logradouro.Text = "Logradouro: " + dt.Rows[0].Field<string>("logradouro");
            lb_numero.Text = "Número: " + dt.Rows[0].Field<Int32>("numero").ToString();
            lb_bairro.Text = "Bairro: " + dt.Rows[0].Field<string>("bairro");
            lb_cidade.Text = "Cidade: " + dt.Rows[0].Field<string>("cidade");
            lb_complemento.Text = "Complemento: " + dt.Rows[0].Field<string>("complemento");

            //Carregando instituições do usuário

            dt.Rows.Clear();
            dt = BCO.Dql(String.Format("SELECT i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = {0}", UsuarioLogado.codUsuario));

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                lb_instituicoes.Text = "- " + dt.Rows[i].Field<string>("nome_instituicao") + "\n";
            }
        }
    }
}
