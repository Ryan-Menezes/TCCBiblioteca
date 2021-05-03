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
    public partial class F_CadFuncionario : Form
    {
        public F_CadFuncionario()
        {
            InitializeComponent();
        }
       
        private void btn_cadastrar_Click_1(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            // tabela usuario 
            if (nud_rm_funcionario.Text == "")
            {
                MessageBox.Show("Digite o Rm do Professor!");
                nud_rm_funcionario.Focus();
                return;
            }
            else if ((Convert.ToInt32(nud_rm_funcionario.Text) >= nud_rm_funcionario.Maximum))
            {
                MessageBox.Show("Rm inválido !");
                nud_rm_funcionario.Focus();
                return;
            }
            funcionario.rm_usuario = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0)); ;

            if (txt_senha_usuario.Text == "")
            {
                MessageBox.Show("Digite a senha!");
                txt_senha_usuario.Focus();
                return;
            }
            funcionario.senha = txt_senha_usuario.Text;

            if (cb_nivel_acesso.Text == "")
            {
                MessageBox.Show("Digite o nivel de acesso!");
                cb_nivel_acesso.Focus();
                return;
            }
            funcionario.nivel_acesso = cb_nivel_acesso.Text;

            if (cb_status.Text == "")
            {
                MessageBox.Show("Digite o status !");
                cb_status.Focus();
                return;
            }
            funcionario.status_usuario = cb_status.Text;
            // fim usuario 

            // tabela funcionario
            funcionario.rm_funcionario = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0));

            if (txt_cpf_funcionario.Text == "")
            {
                MessageBox.Show("Digite o cpf !");
                txt_cpf_funcionario.Focus();
                return;
            }
            else if (txt_cpf_funcionario.TextLength != 11)
            {
                MessageBox.Show("cpf inválido - falta número ou tem muitos números!");
                txt_cpf_funcionario.Focus();
                return;
            }
            funcionario.cpf = txt_cpf_funcionario.Text;

            if (txt_nome_funcionario.Text == "")
            {
                MessageBox.Show("Digite nome do(a) Funcionário(a)!");
                txt_nome_funcionario.Focus();
                return;
            }
            funcionario.nome = txt_nome_funcionario.Text;

            if (txt_sobrenome_funcionario.Text == "")
            {
                MessageBox.Show("Digite sobrenome do(a) Funcionário(a)!");
                txt_sobrenome_funcionario.Focus();
                return;
            }
            funcionario.sobrenome = txt_sobrenome_funcionario.Text;

            if (cb_sexo_funcionario.Text == "")
            {
                MessageBox.Show("Digite o sexo do(a) Funcionário(a)!");
                cb_sexo_funcionario.Focus();
                return;
            }
            funcionario.sexo = cb_sexo_funcionario.Text;

            funcionario.data_cadastro = Convert.ToDateTime(dtp_cadastro_funcionario.Value).ToString("yyy/MM/dd");
            funcionario.rm_usuario_funcionario = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0));
            // fim funcionario

            // tabela endereco_funcionario
            if (txt_cep_funcionario.Text == "")
            {
                MessageBox.Show("Digite o cep do(a) aluno(a)!");
                txt_cep_funcionario.Focus();
                return;
            }
            else if (txt_cep_funcionario.TextLength != 8)
            {
                MessageBox.Show("cep inválido - falta número ou tem muitos números!");
                txt_cep_funcionario.Focus();
                return;
            }
            funcionario.cep = txt_cep_funcionario.Text;

            if (txt_logradouro_funcionario.Text == "")
            {
                MessageBox.Show("Digite o logradouro !");
                txt_logradouro_funcionario.Focus();
                return;
            }
            funcionario.logradouro = txt_logradouro_funcionario.Text;


            if (txt_numero_residencia_funcionario.Text == "")
            {
                MessageBox.Show("Digite nº da residência !");
                txt_numero_residencia_funcionario.Focus();
                return;
            }
            funcionario.numero = txt_numero_residencia_funcionario.Text;

            if (txt_bairro_funcionario.Text == "")
            {
                MessageBox.Show("Digite o bairro !");
                txt_bairro_funcionario.Focus();
                return;
            }
            funcionario.bairro = txt_bairro_funcionario.Text;

            if (cb_cidade_funcionario.Text == "")
            {
                MessageBox.Show("Digite a cidade !");
                cb_cidade_funcionario.Focus();
                return;
            }
            funcionario.cidade = cb_cidade_funcionario.Text;

            funcionario.complemento = txt_complemento_funcionario.Text;
            funcionario.rm_funcionario_endereco = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0));
            funcionario.rm_usuario_endereco = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0));
            // fim endereco_funcionario

            //tabela contato_funcionario
            funcionario.telefone = txt_telefone_funcionario.Text;

            if (txt_celular_funcionario.Text == "")
            {
                MessageBox.Show("Digite o número de celular !");
                txt_celular_funcionario.Focus();
                return;
            }
            else if (txt_celular_funcionario.TextLength != 11)
            {
                MessageBox.Show("Celular inválido - falta número ou tem muitos números!  !");
                txt_celular_funcionario.Focus();
                return;
            }        
            funcionario.celular = txt_celular_funcionario.Text;


            if (txt_email_funcionario.Text == "")
            {
                MessageBox.Show("Digite o E-mail !");
                txt_email_funcionario.Focus();
                return;
            }
            funcionario.email = txt_email_funcionario.Text;
            funcionario.rm_funcionario_contato = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0));
            funcionario.rm_usuario_contato = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0));
            // fim contato_funcionario

            // tabela instituição
            if (cb_cod_instituicao.Text == "")
            {
                MessageBox.Show("Digite o código da Instituiçãol !");
                cb_cod_instituicao.Focus();
                return;
            }
            funcionario.cod_instituicao = Convert.ToInt32(cb_cod_instituicao.Text);

            if (cb_situacao.Text == "")
            {
                MessageBox.Show("Digite a situação !");
                cb_situacao.Focus();
                return;
            }
            funcionario.situacao = cb_situacao.Text;
            funcionario.rm_usuario_instituicao = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0)); // obtém do atriubuto rm
            
            // fim instituição

            BCO.cad_funcionario(funcionario);
        }

        private void F_CadFuncionario_Load(object sender, EventArgs e)
        {
            string vqueryInstituicao = "select * from instituicao order by cod_instituicao";
            cb_cod_instituicao.Items.Clear();
            cb_cod_instituicao.DataSource = BCO.Dql(vqueryInstituicao);
            cb_cod_instituicao.DisplayMember = "cod_instituicao";
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            if (nud_rm_funcionario.Text != "")
            {
                funcionario.rm_usuario = Convert.ToInt32(Math.Round(nud_rm_funcionario.Value, 0));
                funcionario.senha = txt_senha_usuario.Text;
                funcionario.status_usuario = cb_status.Text;

                funcionario.nome= txt_nome_funcionario.Text ;
                funcionario.sobrenome = txt_sobrenome_funcionario.Text;
                funcionario.cpf = txt_cpf_funcionario.Text;
                funcionario.sexo = cb_sexo_funcionario.Text;
                funcionario.data_cadastro = Convert.ToDateTime(dtp_cadastro_funcionario.Value).ToString("yyy/MM/dd");

                funcionario.cod_instituicao = Convert.ToInt32(cb_cod_instituicao.Text);
                funcionario.situacao = cb_situacao.Text;

                funcionario.cep = txt_cep_funcionario.Text;
                funcionario.logradouro = txt_logradouro_funcionario.Text;
                funcionario.numero = txt_numero_residencia_funcionario.Text;
                funcionario.bairro = txt_bairro_funcionario.Text;
                funcionario.cidade = cb_cidade_funcionario.Text;
                funcionario.complemento = txt_complemento_funcionario.Text;

                funcionario.telefone = txt_telefone_funcionario.Text;
                funcionario.celular = txt_celular_funcionario.Text;
                funcionario.email = txt_email_funcionario.Text;

                BCO.alterar_Funcionario(funcionario);
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            if (nud_rm_funcionario.Text != "")
            {
                funcionario.rm_usuario = Convert.ToInt32(nud_rm_funcionario.Text);
                BCO.excluir_funcionario(funcionario);
            }
        }
    }
}
