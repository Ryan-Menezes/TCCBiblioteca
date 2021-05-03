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
    public partial class F_CadProfessor : Form
    {
        public F_CadProfessor()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();

            // tabela usuario

            if (nud_rm_professor.Text == "")
            {
                MessageBox.Show("Digite o Rm !");
                nud_rm_professor.Focus();
                return;
            }
            else if ((Convert.ToInt32(nud_rm_professor.Text) >= nud_rm_professor.Maximum))
            {
                MessageBox.Show("Rm inválido !");
                nud_rm_professor.Focus();
                return;
            }
            professor.rm_usuario = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0));

            if (txt_senha_usuario.Text == "")
            {
                MessageBox.Show("Digite a senha!");
                txt_senha_usuario.Focus();
                return;
            }
            professor.senha = txt_senha_usuario.Text;

            if (cb_nivel_acesso.Text == "")
            {
                MessageBox.Show("Digite o nível de acesso!");
                cb_nivel_acesso.Focus();
                return;
            }
            professor.nivel_acesso = cb_nivel_acesso.Text;

            if (cb_status.Text == "")
            {
                MessageBox.Show("Digite o status !");
                cb_status.Focus();
                return;
            }
            professor.status_usuario = cb_status.Text;
            // fim usuario

            // tabela professor
            professor.rm_professor = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0));

            if (txt_nome_professor.Text == "")
            {
                MessageBox.Show("Digite o nome!");
                txt_nome_professor.Focus();
                return;
            }
            professor.nome = txt_nome_professor.Text ;

            if (txt_sobrenome_professor.Text == "")
            {
                MessageBox.Show("Digite o sobrenome!");
                txt_sobrenome_professor.Focus();
                return;
            }
            professor.sobrenome = txt_sobrenome_professor.Text;

            if (txt_cpf_professor.Text == "")
            {
                MessageBox.Show("Digite o cpf !");
                txt_cpf_professor.Focus();
                return;
            }
            else if (txt_cpf_professor.TextLength != 11)
            {
                MessageBox.Show("cpf inválido - falta número ou tem muitos números!");
                txt_cpf_professor.Focus();
                return;
            }
            professor.cpf = txt_cpf_professor.Text;

            if (cb_sexo_professor.Text == "")
            {
                MessageBox.Show("Digite o sexo!");
                cb_sexo_professor.Focus();
                return;
            }
            professor.sexo = cb_sexo_professor.Text;

            if (cb_sede_professor.Text == "")
            {
                MessageBox.Show("Digite a sede!");
                cb_sede_professor.Focus();
                return;
            }
            professor.sede = Convert.ToInt32(cb_sede_professor.Text);

            professor.data_cadastro = Convert.ToDateTime(dtp_cadastro_professor.Value).ToString("yyy/MM/dd");       
            professor.rm_usuario_professor = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0));
            // fim professor

            // tabela endereco_professor
            if (txt_cep_professor.Text == "")
            {
                MessageBox.Show("Digite o cep !");
                txt_cep_professor.Focus();
                return;
            }
            else if (txt_cep_professor.TextLength != 8)
            {
                MessageBox.Show("cep inválido - falta número ou tem muitos números!");
                txt_cep_professor.Focus();
                return;
            }
            professor.cep = txt_cep_professor.Text;

            if (txt_logradouro_professor.Text == "")
            {
                MessageBox.Show("Digite o logradouro!");
                txt_logradouro_professor.Focus();
                return;
            }
            professor.logradouro = txt_logradouro_professor.Text;

            if (txt_numero_residencia_professor.Text == "")
            {
                MessageBox.Show("Digite nº da residência !");
                txt_numero_residencia_professor.Focus();
                return;
            }
            professor.numero = txt_numero_residencia_professor.Text;

            if (txt_bairro_professor.Text == "")
            {
                MessageBox.Show("Digite o bairro!");
                txt_bairro_professor.Focus();
                return;
            }
            professor.bairro = txt_bairro_professor.Text;

            if (cb_cidade_professor.Text == "")
            {
                MessageBox.Show("Digite a cidade!");
                cb_cidade_professor.Focus();
                return;
            }
            professor.cidade = cb_cidade_professor.Text;

           
            professor.complemento = txt_complemento_professor.Text;
            professor.rm_professor_endereco = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0)); // rm_professor_endereco == nud_rm_professor  
            professor.rm_usuario_endereco = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0));
            // fim endereco_professor


            // tabela contato_professor
            professor.telefone = txt_telefone_professor.Text;

            if (txt_celular_professor.TextLength != 11)
            {
                MessageBox.Show("Celular inválido - falta número ou tem muitos números!  !");
                txt_celular_professor.Focus();
                return;
            }
            if (txt_celular_professor.Text == "")
            {
                MessageBox.Show("Digite o número de celular !");
                txt_celular_professor.Focus();
                return;
            }
            professor.celular = txt_celular_professor.Text;

            if (txt_email_professor.Text == "")
            {
                MessageBox.Show("Digite o E-mail !");
                txt_email_professor.Focus();
                return;
            }
            professor.email = txt_email_professor.Text;
            professor.rm_professor_contato = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0)); // rm_professor_contato == nud_rm_professor
            professor.rm_usuario_contato = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0));
            // fim contato professor

            // tabela instituicao
            if (cb_cod_instituicao.Text == "")
            {
                MessageBox.Show("Digite o código da instituição!");
                cb_cod_instituicao.Focus();
                return;
            }
            professor.cod_instituicao = Convert.ToInt32(cb_cod_instituicao.Text);

            if (cb_situacao.Text == "")
            {
                MessageBox.Show("Digite a situação de professor na Etec!");
                cb_situacao.Focus();
                return;
            }
            professor.situacao = cb_situacao.Text;
            professor.rm_usuario_instituicao = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0)); 
          
            // fim intiuicao

            // tabela curso_usuario
            if (cb_situacao_curso.Text == "")
            {
                MessageBox.Show("Digite a situação no curso!");
                cb_situacao_curso.Focus();
                return;
            }
            professor.situacao_curso = cb_situacao_curso.Text;


            if (cb_curso.Text == "")
            {
                MessageBox.Show("Digite o curso que ministra!");
                cb_curso.Focus();
                return;
            }
            professor.curso_id_curso = Convert.ToInt32(cb_curso.Text);
            professor.usuario_id_usuario = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0));
            
            //fim curso_aluno

            BCO.cad_professor(professor);

        }

        private void F_CadProfessor_Load(object sender, EventArgs e)
        {
            string vqueryInstituicao = "select * from instituicao order by cod_instituicao";
            cb_cod_instituicao.Items.Clear();
            cb_cod_instituicao.DataSource = BCO.Dql(vqueryInstituicao);
            cb_cod_instituicao.DisplayMember = "cod_instituicao";

            string vquerySede = "select * from instituicao order by cod_instituicao";
            cb_sede_professor.Items.Clear();
            cb_sede_professor.DataSource = BCO.Dql(vquerySede);
            cb_sede_professor.DisplayMember = "cod_instituicao";

            string vqueryCurso = "select * from curso order by cod_curso";
            cb_curso.Items.Clear();
            cb_curso.DataSource = BCO.Dql(vqueryCurso);
            cb_curso.DisplayMember = "cod_curso";
            
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();

            if (nud_rm_professor.Text != "")
            {
                professor.rm_usuario = Convert.ToInt32(Math.Round(nud_rm_professor.Value, 0));
                professor.senha = txt_senha_usuario.Text;
                professor.status_usuario = cb_status.Text ;
                professor.nivel_acesso = cb_nivel_acesso.Text;

                professor.cod_instituicao = Convert.ToInt32(cb_cod_instituicao.Text);
                professor.situacao = cb_situacao.Text;
                professor.sede = Convert.ToInt32(cb_sede_professor.Text);

                professor.nome = txt_nome_professor.Text ;
                professor.sobrenome = txt_sobrenome_professor.Text;
                professor.cpf = txt_cpf_professor.Text;
                professor.sexo = cb_sexo_professor.Text;
                professor.data_cadastro = Convert.ToDateTime(dtp_cadastro_professor.Value).ToString("yyy/MM/dd");

                professor.curso_id_curso = Convert.ToInt32(cb_curso.Text);
                professor.situacao_curso = cb_situacao.Text;

                professor.cep = txt_cep_professor.Text;
                professor.logradouro = txt_logradouro_professor.Text;
                professor.numero = txt_numero_residencia_professor.Text;
                professor.bairro = txt_bairro_professor.Text;
                professor.cidade = cb_cidade_professor.Text;
                professor.complemento = txt_complemento_professor.Text;

                professor.telefone = txt_telefone_professor.Text;
                professor.celular = txt_celular_professor.Text;
                professor.email = txt_email_professor.Text;

                BCO.alterar_Professor(professor);
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();

            if (nud_rm_professor.Text != "")
            {
                professor.rm_usuario = Convert.ToInt32(nud_rm_professor.Text);
                BCO.excluir_professor(professor);
            }
        }
    }
}
