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
    public partial class F_CadAluno : Form
    {
        public F_CadAluno()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            // tabela usuario

            if (nud_rm_aluno.Text == "")
            {
                MessageBox.Show("Digite o Rm !");
                nud_rm_aluno.Focus();
                return;
            } 
            else if ((Convert.ToInt32(nud_rm_aluno.Text) >= nud_rm_aluno.Maximum)) 
            {
                MessageBox.Show("Rm inválido !");
                nud_rm_aluno.Focus();
                return;
            }
            aluno.rm_usuario = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));

            if (txt_senha_usuario.Text == "")
            {
                MessageBox.Show("Digite a senha !");
                txt_senha_usuario.Focus();
                return;
            }
            aluno.senha = txt_senha_usuario.Text;

            if (cb_nivel_acesso.Text == "")
            {
                MessageBox.Show("Digite o nivel de acesso!");
                cb_nivel_acesso.Focus();
                return;
            }
            aluno.nivel_acesso = cb_nivel_acesso.Text;

            if (cb_status.Text == "")
            {
                MessageBox.Show("Digite o status !");
                cb_status.Focus();
                return;
            }
            aluno.status_usuario = cb_status.Text;
            // fim tabela usuario

            // tabela aluno
           
            aluno.rm_aluno = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));

            if (txt_nome_aluno.Text == "")
            {
                MessageBox.Show("Digite o nome do(a) aluno(a)!");
                txt_nome_aluno.Focus();
                return;
            }
            aluno.nome = txt_nome_aluno.Text;

            if (txt_sobrenome_aluno.Text == "")
            {
                MessageBox.Show("Digite o sobrenome do(a) aluno(a)!");
                txt_sobrenome_aluno.Focus();
                return;
            }
            aluno.sobrenome = txt_sobrenome_aluno.Text;

            if (txt_cpf_aluno.Text == "")
            {
                MessageBox.Show("Digite o cpf !");
                txt_cpf_aluno.Focus();
                return;        
            }        
            else if (txt_cpf_aluno.TextLength != 11)
            {
                MessageBox.Show("cpf inválido - falta número ou tem muitos números!");
                txt_cpf_aluno.Focus();
                return;
            }
            aluno.cpf = txt_cpf_aluno.Text;


            if (cb_sexo_aluno.Text == "")
            {
                MessageBox.Show("Digite o sexo !");
                cb_sexo_aluno.Focus();
                return;
            }
            aluno.sexo = cb_sexo_aluno.Text;

            aluno.data_cadastro = Convert.ToDateTime(dtp_cadastro_aluno.Value).ToString("yyy/MM/dd");
            aluno.rm_usuario_aluno = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));

            // tabela endereco_aluno

            if (txt_cep_aluno.Text == "")
            {
                MessageBox.Show("Digite o cep do(a) aluno(a)!");
                txt_cep_aluno.Focus();
                return;
            }
            else if (txt_cep_aluno.TextLength != 8)
            {
                MessageBox.Show("cep inválido - falta número ou tem muitos números!");
                txt_cep_aluno.Focus();
                return;
            }
            aluno.cep = txt_cep_aluno.Text;

            if (txt_logradouro_aluno.Text == "")
            {
                MessageBox.Show("Digite o logradouro !");
                txt_logradouro_aluno.Focus();
                return;
            }
            aluno.logradouro = txt_logradouro_aluno.Text;

            if (txt_numero_residencia_aluno.Text == "")
            {
                MessageBox.Show("Digite o número da residência !");
                txt_numero_residencia_aluno.Focus();
                return;
            }
            aluno.numero = txt_numero_residencia_aluno.Text;

            if (txt_bairro_aluno.Text == "")
            {
                MessageBox.Show("Digite o bairro !");
                txt_bairro_aluno.Focus();
                return;
            }
            aluno.bairro = txt_bairro_aluno.Text;


            if (cb_cidade_aluno.Text == "")
            {
                MessageBox.Show("Digite a cidade !");
                cb_cidade_aluno.Focus();
                return;
            }
            aluno.cidade = cb_cidade_aluno.Text;

            aluno.complemento = txt_complemento_aluno.Text;
            aluno.rm_aluno_endereco = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));
            aluno.rm_usuario_endereco = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));

            // tabela contato_aluno
            aluno.telefone = txt_telefone_aluno.Text;

            if (txt_celular_aluno.TextLength != 11)
            {
                MessageBox.Show("Celular inválido - falta número ou tem muitos números!  !");
                txt_celular_aluno.Focus();
                return;
            }
             if (txt_celular_aluno.Text == "")
            {
                MessageBox.Show("Digite o número de celular !");
                txt_celular_aluno.Focus();
                return;
            }
            aluno.celular = txt_celular_aluno.Text;

            if (txt_email_aluno.Text == "")
            {
                MessageBox.Show("Digite o E-mail !");
                txt_email_aluno.Focus();
                return;
            }
            aluno.email = txt_email_aluno.Text;

            aluno.rm_aluno_contato = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));
            aluno.rm_usuario_contato = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));

            // tabela instituicao_usuario
            if (cb_cod_instituicao.Text == "")
            {
                MessageBox.Show("Digite a instituição do aluno !");
                cb_cod_instituicao.Focus();
                return;
            }
            aluno.cod_instituicao = Convert.ToInt32(cb_cod_instituicao.Text);
            aluno.rm_usuario_instituicao = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));

            // tabela curso_usuario
            aluno.usuario_id_usuario = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));

            if (cb_curso.Text == "")
            {
                MessageBox.Show("Digite o curso do aluno !");
                cb_curso.Focus();
                return;
            }
            aluno.curso_id_curso = Convert.ToInt32(cb_curso.Text);

            BCO.cad_aluno(aluno);
           
        }

        private void F_CadAluno_Load(object sender, EventArgs e)
        {
            string vqueryInstituicao = "select * from instituicao order by cod_instituicao";
            cb_cod_instituicao.Items.Clear();
            cb_cod_instituicao.DataSource = BCO.Dql(vqueryInstituicao);
            cb_cod_instituicao.DisplayMember = "cod_instituicao";

            string vqueryCurso = "select * from curso order by cod_curso";
            cb_curso.Items.Clear();
            cb_curso.DataSource = BCO.Dql(vqueryCurso);
            cb_curso.DisplayMember = "cod_curso";
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            if (nud_rm_aluno.Text != "" && nud_rm_aluno.Value > 0)
            {
                aluno.rm_usuario = Convert.ToInt32(Math.Round(nud_rm_aluno.Value, 0));
                aluno.senha = txt_senha_usuario.Text;
                aluno.status_usuario = cb_status.Text;

                aluno.nome = txt_nome_aluno.Text;
                aluno.sobrenome = txt_sobrenome_aluno.Text;
                aluno.cpf = txt_cpf_aluno.Text;
                aluno.sexo = cb_sexo_aluno.Text;
                aluno.data_cadastro = Convert.ToDateTime(dtp_cadastro_aluno.Value).ToString("yyy/MM/dd");

                aluno.cod_instituicao = Convert.ToInt32(cb_cod_instituicao.Text);
                aluno.curso_id_curso = Convert.ToInt32(cb_curso.Text);

                aluno.cep = txt_cep_aluno.Text;
                aluno.logradouro = txt_logradouro_aluno.Text;
                aluno.numero = txt_numero_residencia_aluno.Text;
                aluno.bairro = txt_bairro_aluno.Text;
                aluno.cidade = cb_cidade_aluno.Text;
                aluno.complemento = txt_complemento_aluno.Text;

                aluno.telefone = txt_telefone_aluno.Text;
                aluno.celular = txt_celular_aluno.Text;
                aluno.email = txt_email_aluno.Text;

                BCO.alterar_Aluno(aluno);
            }
            else
            {
                MessageBox.Show("Erro - digite o Rm do Aluno!");
                nud_rm_aluno.Focus();
                return;
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            if (nud_rm_aluno.Text != "")
            {
                aluno.rm_usuario = Convert.ToInt32(nud_rm_aluno.Text);
                BCO.excluir_aluno(aluno);
            }
        }
    }
}
