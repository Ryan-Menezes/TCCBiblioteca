using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios.NET;
using System.Security.Cryptography;
using System.IO;
using Biblioteca01;

namespace BibliotecaEtec
{
    public partial class F_CadAlunos : Form
    {
        //Lista de cursos selecionados

        public List<string> cod_cursos = new List<string>();
        public string imagemPerfil = string.Empty;

        //Fim da declaração da lista

        //Estruturas que irão conter os text box/masked text box dos formulários

        public struct InputsTextBox
        {
            public TextBox input;
            public Label label;
        }

        public struct InputsMaskedTextBox
        {
            public MaskedTextBox input;
            public Label label;
        }

        //Instanciação das estruturas acima

        InputsTextBox[] inputsTextBox = new InputsTextBox[6];
        InputsMaskedTextBox[] inputsMaskedTextBox = new InputsMaskedTextBox[3];

        public F_CadAlunos()
        {
            InitializeComponent();

            for (int i = 0; i < inputsTextBox.Length; i++)
            {
                inputsTextBox[i] = new InputsTextBox();
            }

            for (int i = 0; i < inputsMaskedTextBox.Length; i++)
            {
                inputsMaskedTextBox[i] = new InputsMaskedTextBox();
            }

            //Textbox

            inputsTextBox[0].input = tb_nome;
            inputsTextBox[0].label = lb_nome;

            inputsTextBox[1].input = tb_sobrenome;
            inputsTextBox[1].label = lb_sobrenome;

            inputsTextBox[2].input = tb_email;
            inputsTextBox[2].label = lb_email;

            inputsTextBox[3].input = tb_logradouro;
            inputsTextBox[3].label = lb_logradouro;

            inputsTextBox[4].input = tb_bairro;
            inputsTextBox[4].label = lb_bairro;

            inputsTextBox[5].input = tb_cidade;
            inputsTextBox[5].label = lb_cidade;

            //MaskedTextBox

            inputsMaskedTextBox[0].input = tb_cpf;
            inputsMaskedTextBox[0].label = lb_cpf;

            inputsMaskedTextBox[1].input = tb_celular;
            inputsMaskedTextBox[1].label = lb_celular;

            inputsMaskedTextBox[2].input = tb_cep;
            inputsMaskedTextBox[2].label = lb_cep;

            //Inciando o combo box sexo

            Dictionary<string, string> sexos = new Dictionary<string, string>();

            sexos.Add("M", "Masculino");
            sexos.Add("F", "Feminino");
            sexos.Add("P", "Personalizado");

            cb_sexo.DataSource = new BindingSource(sexos, null);
            cb_sexo.DisplayMember = "Value";
            cb_sexo.ValueMember = "Key";
        }

        //Metodo que obtem a imagem de perfil

        private void img_perfil_Click(object sender, EventArgs e)
        {
            DialogResult res = pegarImagem.ShowDialog();

            if (res == DialogResult.OK)
            {
                Bitmap img = new Bitmap(pegarImagem.FileName);
                img_perfil.Image = img;
                imagemPerfil = pegarImagem.FileName;
            }
            else
            {
                img_perfil.Image = Properties.Resources.anonimo;
                imagemPerfil = string.Empty;
            }
        }

        //Metodo que abrirá a lista de cursos para serem selecionados

        private void btn_adicionarCurso_Click(object sender, EventArgs e)
        {
            F_SelecionarCurso f = new F_SelecionarCurso(this, 1);
            f.ShowDialog();
        }

        //Metodo para remover item da lista de cursos

        private void list_cursos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list_cursos.SelectedIndex >= 0)
            {
                cod_cursos.RemoveAt(list_cursos.SelectedIndex);
                list_cursos.Items.RemoveAt(list_cursos.SelectedIndex);
            }
        }

        //Metodo que chamará outro Metodo para buscar o CEP

        private void tb_cep_Leave(object sender, EventArgs e)
        {
            if (tb_cep.Text.Trim().Length == 8)
            {
                procuraEnderecoCEP();
            }
        }

        //Metodo para obter o endereço do usuário

        private void procuraEnderecoCEP()
        {
            try
            {
                var endereco = new Services().GetAddresses(tb_cep.Text);

                foreach (var address in endereco)
                {
                    if (address.State == "SP")
                    {
                        this.tb_logradouro.Text = address.Street;
                        this.tb_bairro.Text = address.District;
                        this.tb_cidade.Text = address.City;
                    }
                    else
                    {
                        this.tb_logradouro.Clear();
                        this.tb_bairro.Clear();
                        this.tb_cidade.Clear();
                    }
                }
            }
            catch
            {
                this.tb_logradouro.Clear();
                this.tb_bairro.Clear();
                this.tb_cidade.Clear();
            }
        }


        //Metodo que iniciará o cadastro em um backgroundWorker

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                //Verficando se os arquivos existem

                if (!File.Exists(this.imagemPerfil))
                {
                    this.imagemPerfil = string.Empty;
                }

                //Verificando tamanho da imagem

                long tamanho = (this.imagemPerfil.Length > 0) ? new System.IO.FileInfo(this.imagemPerfil).Length : 1;

                if (tamanho <= 1048576)
                {
                    Aluno aluno = new Aluno();

                    //Criptografando senha

                    string senha = string.Empty;

                    MD5 md5 = MD5.Create();

                    byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(tb_cpf.Text.Trim()));

                    foreach (byte h in hash)
                    {
                        senha += h.ToString("x2");
                    }

                    aluno.senha = senha;

                    //Convertendo imagem em binario

                    if (imagemPerfil.Length > 0)
                    {
                        FileStream fs = new FileStream(imagemPerfil, FileMode.Open, FileAccess.Read);

                        BinaryReader br = new BinaryReader(fs);

                        byte[] img = br.ReadBytes((int)fs.Length);

                        aluno.imgAluno = img;
                    }
                    else
                    {
                        FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Imagens\\anonimo.png", FileMode.Open, FileAccess.Read);

                        BinaryReader br = new BinaryReader(fs);

                        byte[] img = br.ReadBytes((int)fs.Length);

                        aluno.imgAluno = img;
                    }

                    aluno.rm_aluno = tb_rm.Value.ToString();
                    aluno.nome = tb_nome.Text.Trim();
                    aluno.sobrenome = tb_sobrenome.Text.Trim();
                    aluno.cpf = tb_cpf.Text.Trim();
                    aluno.sexo = cb_sexo.SelectedValue.ToString();
                    aluno.cep = tb_cep.Text.Trim();
                    aluno.logradouro = tb_logradouro.Text.Trim();
                    aluno.bairro = tb_bairro.Text.Trim();
                    aluno.numero = tb_numero.Value.ToString();
                    aluno.cidade = tb_cidade.Text.Trim();
                    aluno.complemento = tb_complemento.Text.Trim();
                    aluno.telefone = tb_telefone.Text.Trim();
                    aluno.celular = tb_celular.Text.Trim();
                    aluno.email = tb_email.Text.Trim();
                    aluno.cursos = cod_cursos;

                    BCO.cad_aluno(aluno);
                }
                else
                {
                    MessageBox.Show("A imagem selecionada é muito grande!, selecione outra imagem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //O Metodo abaixo verifica se os campos estão preenchidos corretamente

        private bool verificaCampos()
        {
            bool verifica = true;

            try
            {
                //Verificando text box

                for (int i = 0; i < inputsTextBox.Length; i++)
                {
                    if (inputsTextBox[i].input.Text.Trim().Length == 0)
                    {
                        inputsTextBox[i].label.Visible = true;
                        verifica = false;
                    }
                }

                //Verificando MaskedTextBox

                for (int i = 0; i < inputsMaskedTextBox.Length; i++)
                {
                    if (inputsMaskedTextBox[i].input.Text.Trim().Length != int.Parse(inputsMaskedTextBox[i].input.Tag.ToString()))
                    {
                        inputsMaskedTextBox[i].label.Visible = true;
                        verifica = false;
                    }
                }

                //Verificando Lista de cursos

                if (list_cursos.Items.Count == 0)
                {
                    lb_curso.Visible = true;
                    verifica = false;
                }
            }
            catch
            {
                verifica = false;
            }

            return verifica;
        }

        //Metodos que limpam as mensagens de aviso do formulário

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            for (int i = 0; i < inputsTextBox.Length; i++)
            {
                if (tb == inputsTextBox[i].input)
                {
                    inputsTextBox[i].label.Visible = false;
                }
            }
        }

        private void maskedTextBox_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox tb = (MaskedTextBox)sender;

            for (int i = 0; i < inputsMaskedTextBox.Length; i++)
            {
                if (tb == inputsMaskedTextBox[i].input)
                {
                    inputsMaskedTextBox[i].label.Visible = false;
                }
            }
        }

        private void list_cursos_Enter(object sender, EventArgs e)
        {
            lb_curso.Visible = false;
        }
    }
}
