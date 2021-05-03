using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Drawing.Drawing2D;

namespace BibliotecaEtec
{
    public partial class TelaPrincipal : Form
    {
        //Lista que irá conter os formulários

        List<Form> formularios = new List<Form>();
        List<Panel> bordas = new List<Panel>();

        //Variavel que guarda o indice do formulario selecionado, travez do menu

        private int selecionado = 0;

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            //Arredondando Imagem

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, img_perfil.Width, img_perfil.Height);
            img_perfil.Region = new Region(gp);

            //Inicializando formulários

            this.formularios.Add(new Inicio());
            this.formularios.Add(new F_DadosPessoais());
            this.formularios.Add(new F_Livros());
            this.formularios.Add(new F_Alunos());
            this.formularios.Add(new F_Professores());
            this.formularios.Add(new F_Funcionarios());
            this.formularios.Add(new F_CursosInstituicao());
            this.formularios.Add(new F_Alocacoes());

            this.p_principal.Visible = false;

            for (int i = 0; i < formularios.Count; i++)
            {
                this.formularios[i].TopLevel = false;
                this.formularios[i].Dock = DockStyle.Fill;
                this.p_principal.Controls.Add(this.formularios[i]);
                this.formularios[i].Show();
                this.formularios[i].Visible = false;
            }

            this.p_principal.Visible = true;

            //Inicializando bordas do menu

            this.bordas.Add(panel6);
            this.bordas.Add(panel8);
            this.bordas.Add(panel12);
            this.bordas.Add(panel20);
            this.bordas.Add(panel18);
            this.bordas.Add(panel16);
            this.bordas.Add(panel21);
            this.bordas.Add(panel22);
            this.bordas.Add(panel24);

            //Formulário que será aberto primeiro

            this.selecionado = 0;
            this.bordas[this.selecionado].Visible = true;
            this.formularios[this.selecionado].Visible = true;
        }

        private void limparPanel()
        {
            for (int i = 0; i < formularios.Count; i++)
            {
                this.formularios[i].Visible = false;
            }
        }

        //Efeito hover no menu

        private void enter(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            int indice = 0;

            try
            {
                indice = int.Parse(btn.Tag.ToString());
            }
            catch
            {
                indice = 0;
            }
            finally
            {
                this.bordas[indice].Visible = true;
            }
        }

        private void leave(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            int indice = 0;

            try
            {
                indice = int.Parse(btn.Tag.ToString());
            }
            catch
            {
                indice = 0;
            }
            finally
            {
                if (indice != this.selecionado)
                    this.bordas[indice].Visible = false;
            }
        }

        //Eventos para abrir formularios

        private void menuClick(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            int indice = 0;

            try
            {
                indice = int.Parse(btn.Tag.ToString());
            }
            catch
            {
                indice = 0;
            }
            finally
            {
                if (!formularios[indice].Visible) //Verificando se o formulário já está aberto
                {
                    this.limparPanel();
                    this.selecionado = indice;
                    this.bordas[indice].Visible = true;
                    this.formularios[indice].Visible = true;
                }
            }
        }

        //Função para esconder as bordas do menu

        private void EscondeBordas(object sender, EventArgs e)
        {
            for (int i = 0; i < bordas.Count; i++)
            {
                if (i != this.selecionado)
                {
                    this.bordas[i].Visible = false;
                }
            }
        }

        //Função para fechar o formulario

        private void TelaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            //Resetando usuário

            UsuarioLogado.nomeCompleto = string.Empty;
            UsuarioLogado.cpf = string.Empty;
            UsuarioLogado.rm = string.Empty;
            UsuarioLogado.senha = string.Empty;
            UsuarioLogado.codUsuario = string.Empty;
            UsuarioLogado.instituicoes.Clear();

            //Abrindo formulário de login

            this.Close();
            Globais.tela = new TelaPrincipal();
            Globais.logado = false;
            Globais.TelaLogin.Visible = true;
        }
    }
}