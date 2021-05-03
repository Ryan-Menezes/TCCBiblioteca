using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Drawing.Drawing2D;
using MySql.Data;
using MySql.Data.MySqlClient;
using Biblioteca01;
using Correios.NET;

namespace BibliotecaEtec
{
    public partial class F_EditaFuncionario : Form
    {
        //Lista de cursos selecionados

        public List<string> cod_instituicoes = new List<string>();
        public string imagemPerfil = string.Empty;
        public byte[] imgCarregado = null;

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
        private string cpf = string.Empty;
        private string codigoUser = string.Empty;
        private F_Funcionarios formulario = null;

        public F_EditaFuncionario(string cpf, F_Funcionarios p)
        {
            InitializeComponent();

            this.cpf = cpf;
            this.formulario = p;

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

            //Inciando o combo box status

            Dictionary<string, string> status = new Dictionary<string, string>();

            status.Add("B", "Bloqueado");
            status.Add("D", "Desbloqueado");

            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";

            //Buscando dados do funcionário

            DataTable dt = BCO.Dql("SELECT * FROM funcionario AS f INNER JOIN contato_funcionario AS c ON c.cpf_funcionario = f.cpf INNER JOIN usuario AS u ON u.id_usuario = f.id_usuario_funcionario INNER JOIN endereco_funcionario AS e ON e.cpf_funcionario_endereco = f.cpf WHERE f.cpf = " + this.cpf + " LIMIT 1");

            if (dt.Rows.Count > 0)
            {
                this.codigoUser = dt.Rows[0].Field<Int32>("id_usuario_funcionario").ToString();
                this.cpf = dt.Rows[0].Field<string>("cpf");

                imgCarregado = dt.Rows[0].Field<byte[]>("img_funcionario");

                img_perfil.Image = System.Drawing.Image.FromStream(new MemoryStream(imgCarregado));
                tb_nome.Text = dt.Rows[0].Field<string>("nome");
                tb_sobrenome.Text = dt.Rows[0].Field<string>("sobrenome");
                tb_cpf.Text = dt.Rows[0].Field<string>("cpf");
                cb_status.SelectedValue = dt.Rows[0].Field<string>("status_usuario");
                cb_sexo.SelectedValue = (dt.Rows[0].Field<string>("sexo") != null ? dt.Rows[0].Field<string>("sexo") : "P");
                tb_cep.Text = dt.Rows[0].Field<string>("cep");
                tb_logradouro.Text = dt.Rows[0].Field<string>("logradouro");
                tb_bairro.Text = dt.Rows[0].Field<string>("bairro");
                tb_numero.Value = Convert.ToDecimal(dt.Rows[0].Field<Int32>("numero"));
                tb_cidade.Text = dt.Rows[0].Field<string>("cidade");
                tb_complemento.Text = dt.Rows[0].Field<string>("complemento");
                tb_telefone.Text = dt.Rows[0].Field<string>("telefone");
                tb_celular.Text = dt.Rows[0].Field<string>("celular");
                tb_email.Text = dt.Rows[0].Field<string>("email");

                //Buscando as instituições

                dt = BCO.Dql("SELECT i.id_instituicao, i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = " + this.codigoUser);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cod_instituicoes.Add(dt.Rows[i].ItemArray[0].ToString());
                    list_instituicao.Items.Add(dt.Rows[i].ItemArray[1].ToString());
                }
            }
            else
            {
                this.Close();
            }
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
                img_perfil.Image = System.Drawing.Image.FromStream(new MemoryStream(imgCarregado));
                imagemPerfil = string.Empty;
            }
        }

        //Metodo que abrirá a lista de cursos para serem selecionados

        private void btn_adicionarCurso_Click(object sender, EventArgs e)
        {
            F_SelecionaInstituicao f = new F_SelecionaInstituicao(null, null, null, this);
            f.ShowDialog();
        }

        //Metodo para remover item da lista de cursos

        private void list_cursos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list_instituicao.SelectedIndex >= 0)
            {
                cod_instituicoes.RemoveAt(list_instituicao.SelectedIndex);
                list_instituicao.Items.RemoveAt(list_instituicao.SelectedIndex);
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

        //Metodo que iniciará o cadastro

        private void btn_editar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = BCO.conexaoBCO();
            var cmd = conexao.CreateCommand();

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
                    try
                    {
                        //Buscando cpf

                        DataTable dtcpf = BCO.Dql("SELECT * FROM funcionario WHERE cpf = " + tb_cpf.Text.Trim() + " LIMIT 1");

                        if ((dtcpf.Rows.Count == 1 && cpf == tb_cpf.Text.Trim()) || dtcpf.Rows.Count == 0)
                        {
                            //Editando endereço

                            cmd.CommandText = "UPDATE endereco_funcionario SET cep = @cep, logradouro = @logradouro, numero = @numero, bairro = @bairro, cidade = @cidade, complemento = @complemento WHERE cpf_funcionario_endereco = @cpfE LIMIT 1";
                            cmd.Parameters.AddWithValue("@cep", tb_cep.Text.Trim());
                            cmd.Parameters.AddWithValue("@logradouro", tb_logradouro.Text.Trim());
                            cmd.Parameters.AddWithValue("@numero", tb_numero.Text.Trim());
                            cmd.Parameters.AddWithValue("@bairro", tb_bairro.Text.Trim());
                            cmd.Parameters.AddWithValue("@cidade", tb_cidade.Text.Trim());
                            cmd.Parameters.AddWithValue("@complemento", tb_complemento.Text.Trim());
                            cmd.Parameters.AddWithValue("@cpfE", cpf);
                            cmd.ExecuteNonQuery();

                            //Editando contato

                            cmd.CommandText = "UPDATE contato_funcionario SET telefone = @telefone, celular = @celular, email = @email WHERE cpf_funcionario = @cpfC LIMIT 1";
                            cmd.Parameters.AddWithValue("@telefone", tb_telefone.Text.Trim());
                            cmd.Parameters.AddWithValue("@celular", tb_celular.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@cpfC", cpf);
                            cmd.ExecuteNonQuery();

                            //Convertendo imagem em binario e editando usuário

                            if (imagemPerfil.Length > 0)
                            {
                                FileStream fs = new FileStream(imagemPerfil, FileMode.Open, FileAccess.Read);

                                BinaryReader br = new BinaryReader(fs);

                                byte[] img = br.ReadBytes((int)fs.Length);

                                cmd.CommandText = "UPDATE funcionario SET cpf = @cpf, nome = @nome, sobrenome = @sobrenome, sexo = @sexo, img_funcionario = @imagem WHERE id_usuario_funcionario = @id LIMIT 1";
                                cmd.Parameters.AddWithValue("@cpf", tb_cpf.Text.Trim());
                                cmd.Parameters.AddWithValue("@nome", tb_nome.Text.Trim());
                                cmd.Parameters.AddWithValue("@sobrenome", tb_sobrenome.Text.Trim());
                                cmd.Parameters.AddWithValue("@sexo", cb_sexo.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@imagem", img);
                                cmd.Parameters.AddWithValue("@id", codigoUser);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = "UPDATE funcionario SET cpf = @cpf, nome = @nome, sobrenome = @sobrenome, sexo = @sexo WHERE id_usuario_funcionario = @id LIMIT 1";
                                cmd.Parameters.AddWithValue("@cpf", tb_cpf.Text.Trim());
                                cmd.Parameters.AddWithValue("@nome", tb_nome.Text.Trim());
                                cmd.Parameters.AddWithValue("@sobrenome", tb_sobrenome.Text.Trim());
                                cmd.Parameters.AddWithValue("@sexo", (cb_sexo.SelectedValue.ToString() != "P" ? cb_sexo.SelectedValue.ToString() : null));
                                cmd.Parameters.AddWithValue("@id", codigoUser);
                                cmd.ExecuteNonQuery();
                            }

                            //Editando instituições

                            BCO.Dml("DELETE FROM instituicao_usuario WHERE id_usuario = " + codigoUser);

                            for (int i = 0; i < cod_instituicoes.Count; i++)
                            {
                                BCO.Dml("INSERT INTO instituicao_usuario (situacao, id_usuario, id_instituicao) VALUES (NULL, " + codigoUser + ", " + cod_instituicoes[i] + ")");
                            }

                            //Editando usuário

                            cmd.CommandText = "UPDATE usuario SET status_usuario = @status WHERE id_usuario = @idU LIMIT 1";
                            cmd.Parameters.AddWithValue("@status", cb_status.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@idU", codigoUser);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Funcionário editado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Recarregar imagem preview

                            if (this.imagemPerfil.Length > 0)
                            {
                                if (File.Exists(this.imagemPerfil))
                                {
                                    FileStream fs = new FileStream(this.imagemPerfil, FileMode.Open, FileAccess.Read);
                                    BinaryReader br = new BinaryReader(fs);
                                    this.imgCarregado = br.ReadBytes((int)fs.Length);
                                }
                            }

                            this.imagemPerfil = string.Empty;
                            formulario.dgv_funcionarios.Rows.Clear();
                            formulario.carregarMais();
                        }
                        else
                        {
                            MessageBox.Show("Já existe um funcionário cadastrado com este CPF", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possivel editar este funcionário!, Ocorreu um erro na edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

                if (list_instituicao.Items.Count == 0)
                {
                    lb_instituicao.Visible = true;
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

        private void list_instituicoes_Enter(object sender, EventArgs e)
        {
            lb_instituicao.Visible = false;
        }
    }
}
