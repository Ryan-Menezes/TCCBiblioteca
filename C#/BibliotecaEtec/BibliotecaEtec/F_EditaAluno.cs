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
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BibliotecaEtec
{
    public partial class F_EditaAluno : Form
    {
        //Lista de cursos selecionados

        public List<string> cod_cursos = new List<string>();
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

        private string rm = string.Empty;
        private string codigoUser = string.Empty;
        private F_Alunos formulario = null;

        public F_EditaAluno(string rm, F_Alunos f)
        {
            InitializeComponent();

            this.rm = rm;
            this.formulario = f;

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

            //Buscando dados do aluno

            DataTable dt = BCO.Dql("SELECT * FROM aluno AS a INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno INNER JOIN endereco_aluno AS e ON e.rm_aluno_endereco = a.rm_aluno INNER JOIN usuario AS u ON u.id_usuario = a.id_usuario_aluno WHERE rm_aluno = " + this.rm + " LIMIT 1");

            if (dt.Rows.Count > 0)
            {
                this.codigoUser = dt.Rows[0].Field<Int32>("id_usuario_aluno").ToString();

                imgCarregado = dt.Rows[0].Field<byte[]>("img_aluno");

                img_perfil.Image = System.Drawing.Image.FromStream(new MemoryStream(imgCarregado));
                tb_rm.Value = Convert.ToDecimal(rm);
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

                //Buscando os cursos

                dt = BCO.Dql("SELECT id_curso, nome_curso, modulo_serie, CASE periodo WHEN 'M' THEN 'Manhã' WHEN 'T' THEN 'Tarde' WHEN 'N' THEN 'Noite' ELSE 'Integral' END, turma FROM curso AS c INNER JOIN curso_usuario AS ca ON ca.curso_id_curso = c.id_curso WHERE ca.usuario_id_usuario = " + this.codigoUser);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cod_cursos.Add(dt.Rows[i].ItemArray[0].ToString());
                    list_cursos.Items.Add(dt.Rows[i].ItemArray[1].ToString() + " - Módulo/Série: " + dt.Rows[i].ItemArray[2].ToString() + " - Periodo: " + dt.Rows[i].ItemArray[3].ToString() + " - Turma: " + dt.Rows[i].ItemArray[4].ToString());
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
            F_SelecionarCurso f = new F_SelecionarCurso(this, 2);
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

        private void btn_edita_Click(object sender, EventArgs e)
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
                        DataTable dt = BCO.Dql("SELECT * FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE a.rm_aluno = " + tb_rm.Value.ToString() + " LIMIT 1");

                        if ((dt.Rows.Count == 1 && rm == tb_rm.Value.ToString()) || dt.Rows.Count == 0)
                        {
                            //Editando endereço

                            cmd.CommandText = "UPDATE endereco_aluno SET cep = @cep, logradouro = @logradouro, numero = @numero, bairro = @bairro, cidade = @cidade, complemento = @complemento WHERE rm_aluno_endereco = @rmE LIMIT 1";
                            cmd.Parameters.AddWithValue("@cep", tb_cep.Text.Trim());
                            cmd.Parameters.AddWithValue("@logradouro", tb_logradouro.Text.Trim());
                            cmd.Parameters.AddWithValue("@numero", tb_numero.Text.Trim());
                            cmd.Parameters.AddWithValue("@bairro", tb_bairro.Text.Trim());
                            cmd.Parameters.AddWithValue("@cidade", tb_cidade.Text.Trim());
                            cmd.Parameters.AddWithValue("@complemento", tb_complemento.Text.Trim());
                            cmd.Parameters.AddWithValue("@rmE", rm);
                            cmd.ExecuteNonQuery();

                            //Editando contato

                            cmd.CommandText = "UPDATE contato_aluno SET telefone = @telefone, celular = @celular, email = @email WHERE rm_aluno_contato = @rmC LIMIT 1";
                            cmd.Parameters.AddWithValue("@telefone", tb_telefone.Text.Trim());
                            cmd.Parameters.AddWithValue("@celular", tb_celular.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@rmC", rm);
                            cmd.ExecuteNonQuery();

                            //Convertendo imagem em binario e editando usuário

                            if (imagemPerfil.Length > 0)
                            {
                                FileStream fs = new FileStream(imagemPerfil, FileMode.Open, FileAccess.Read);

                                BinaryReader br = new BinaryReader(fs);

                                byte[] img = br.ReadBytes((int)fs.Length);

                                cmd.CommandText = "UPDATE aluno SET rm_aluno = @rmU, nome = @nome, sobrenome = @sobrenome, cpf = @cpf, sexo = @sexo, img_aluno = @imagem WHERE id_usuario_aluno = @id LIMIT 1";
                                cmd.Parameters.AddWithValue("@rmU", tb_rm.Value.ToString());
                                cmd.Parameters.AddWithValue("@nome", tb_nome.Text.Trim());
                                cmd.Parameters.AddWithValue("@sobrenome", tb_sobrenome.Text.Trim());
                                cmd.Parameters.AddWithValue("@cpf", tb_cpf.Text.Trim());
                                cmd.Parameters.AddWithValue("@sexo", (cb_sexo.SelectedValue.ToString() != "P" ? cb_sexo.SelectedValue.ToString() : null));
                                cmd.Parameters.AddWithValue("@imagem", img);
                                cmd.Parameters.AddWithValue("@id", codigoUser);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = "UPDATE aluno SET rm_aluno = @rmU, nome = @nome, sobrenome = @sobrenome, cpf = @cpf, sexo = @sexo WHERE id_usuario_aluno = @id LIMIT 1";
                                cmd.Parameters.AddWithValue("@rmU", tb_rm.Value.ToString());
                                cmd.Parameters.AddWithValue("@nome", tb_nome.Text.Trim());
                                cmd.Parameters.AddWithValue("@sobrenome", tb_sobrenome.Text.Trim());
                                cmd.Parameters.AddWithValue("@cpf", tb_cpf.Text.Trim());
                                cmd.Parameters.AddWithValue("@sexo", (cb_sexo.SelectedValue.ToString() != "P" ? cb_sexo.SelectedValue.ToString() : null));
                                cmd.Parameters.AddWithValue("@id", codigoUser);
                                cmd.ExecuteNonQuery();
                            }

                            //Editando cursos

                            BCO.Dml("DELETE FROM curso_usuario WHERE usuario_id_usuario = " + codigoUser);

                            for(int i = 0; i < cod_cursos.Count; i++)
                            {
                                BCO.Dml("INSERT INTO curso_usuario (usuario_id_usuario, curso_id_curso) VALUES (" + codigoUser + ", " + cod_cursos[i] + ")");
                            }

                            //Editando usuário

                            cmd.CommandText = "UPDATE usuario SET status_usuario = @status WHERE id_usuario = @idU LIMIT 1";
                            cmd.Parameters.AddWithValue("@status", cb_status.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@idU", codigoUser);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Aluno editado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                            formulario.dgv_alunos.Rows.Clear();
                            formulario.carregarMais();
                        }
                        else
                        {
                            MessageBox.Show("Já existe um aluno cadastrado com este RM", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possivel editar este aluno!, Ocorreu um erro na edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
