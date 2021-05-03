using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using BibliotecaEtec;
using System.Net;

namespace Biblioteca01
{
    class BCO
    {
        public static MySqlConnection conexaoBCO()
        {
            MySqlConnection con = new MySqlConnection("SERVER = localhost; DATABASE = bdbibliotecaetec; UID = root; PWD =;");
            con.Open();
            return con;
        }

        public static DataTable Dql(string sql)
        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = sql;
                da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                da.Fill(dt);
                conBCO.Close();
                return dt;
            }
            catch
            {
                return dt;
            }
        }

        public static void Dml(string sql, string msgHit = null, string msgErro = null)
        {
            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conBCO.Close();

                if (msgHit != null)
                {
                    MessageBox.Show(msgHit, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                if (msgErro != null)
                {
                    MessageBox.Show(msgErro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static bool cad_livro(Livro livro)
        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();

            try
            {
                //Verificando se exeiste algum livro cadastrado com o tombo informado

                cmd.CommandText = "SELECT * FROM livro WHERE tombo = '" + livro.tombo + "' LIMIT 1";
                da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                da.Fill(dt);

                if(dt.Rows.Count == 0)
                {
                    //Cadastrando livro

                    cmd.CommandText = "INSERT INTO livro (tombo, titulo, ano_publicacao, volume, edicao, insercao, isbn, idioma, img_livro, pdf_livro) VALUES (@tombo, @titulo, @data, @volume, @edicao, CURDATE(), @isbn, @idioma, @img, @pdf)";

                    cmd.Parameters.AddWithValue("@tombo", livro.tombo);
                    cmd.Parameters.AddWithValue("@titulo", livro.titulo);
                    cmd.Parameters.AddWithValue("@data", livro.ano_publicacao);
                    cmd.Parameters.AddWithValue("@volume", livro.volume);
                    cmd.Parameters.AddWithValue("@edicao", livro.edicao);
                    cmd.Parameters.AddWithValue("@isbn", livro.isbn);
                    cmd.Parameters.AddWithValue("@idioma", livro.idioma);
                    cmd.Parameters.AddWithValue("@img", livro.img_livro);
                    cmd.Parameters.AddWithValue("@pdf", livro.pdf);
                    cmd.ExecuteNonQuery();

                    //Codigo do livro inserido

                    string codLivro = cmd.LastInsertedId.ToString();

                    //Fazendo o upload do pdf

                    if (livro.pdf.Length > 0 && livro.pdfCaminho.Length > 0)
                    {
                        WebClient client = new WebClient();

                        client.UploadFile(Globais.url + "CSharpPHP/UploadPDF.php?a=" + livro.pdf + "&cod=" + codLivro, livro.pdfCaminho);
                    }

                    //Cadastrando generos

                    foreach (string genero in livro.generos)
                    {
                        cmd.CommandText = "INSERT INTO genero_livro (id_genero_tombo, id_livro_tombo) VALUES (" + genero + ", " + codLivro + ")";
                        cmd.ExecuteNonQuery();
                    }

                    //Cadastrando autores

                    foreach (string autor in livro.autores)
                    {
                        cmd.CommandText = "INSERT INTO autor_livro (id_autor_tombo, id_livro_tombo) VALUES (" + autor + ", " + codLivro + ")";
                        cmd.ExecuteNonQuery();
                    }

                    //Verificando se o livro é pdf

                    if (livro.tombo != null && livro.exemplares != null && livro.isbn != null && livro.editoras != null && livro.instituicao != null)
                    {
                        //Cadastrando exemplares

                        cmd.CommandText = "INSERT INTO exemplares (quantidade, livro_tombo_exemplares, id_instituicao) VALUES (@qtde, @livro, @instituicao)";

                        cmd.Parameters.AddWithValue("@qtde", livro.exemplares);
                        cmd.Parameters.AddWithValue("@livro", codLivro);
                        cmd.Parameters.AddWithValue("@instituicao", livro.instituicao);
                        cmd.ExecuteNonQuery();

                        //Cadastrando editoras

                        foreach (string editora in livro.editoras)
                        {
                            cmd.CommandText = "INSERT INTO editora_livro (id_editora, cod_livro) VALUES (" + editora + ", " + codLivro + ")";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    conBCO.Close();

                    MessageBox.Show("Livro cadastrado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
                else
                {
                    conBCO.Close();

                    MessageBox.Show("Já existe um livro cadastrado com este tombo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }
            catch
            {
                conBCO.Close();
                MessageBox.Show("Não foi possivel finalizar o cadastro, Ocorreu um erro no cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public static void cad_alocacao(Alocacao alocacao)
        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();

            try
            {
                //Buscando usuário

                if(alocacao.tipoUsuario == "A")
                {
                    cmd.CommandText = String.Format("SELECT u.id_usuario FROM usuario AS u LEFT JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE a.rm_aluno = '{0}' LIMIT 1", alocacao.usuario);
                    da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                    da.Fill(dt);
                }
                else if (alocacao.tipoUsuario == "P")
                {
                    cmd.CommandText = String.Format("SELECT u.id_usuario FROM usuario AS u LEFT JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE p.rm_professor = '{0}' LIMIT 1", alocacao.usuario);
                    da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                    da.Fill(dt);
                }
                else
                {
                    cmd.CommandText = String.Format("SELECT u.id_usuario FROM usuario AS u INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario WHERE f.cpf = '{0}' LIMIT 1", alocacao.usuario);
                    da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                    da.Fill(dt);
                }

                //Verificando se o usuário indicado existe

                if(dt.Rows.Count > 0)
                {
                    string codUsuario = dt.Rows[0].ItemArray[0].ToString();

                    foreach (string codigo in alocacao.livros)
                    {
                        cmd.CommandText = String.Format("SELECT * FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro WHERE e.id_exemplares = {0} AND (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) > 0 LIMIT 1", codigo);
                        da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                        da.Fill(dt);

                        if(dt.Rows.Count > 0)
                        {
                            cmd.CommandText = String.Format("INSERT INTO locacao (data_locacao, data_devolucao, notificado, id_usuario_locacao, id_usuarioAdimin_locacao, id_exemplares) VALUES ('{0}', '{1}', FALSE, '{2}', '{3}', '{4}')", alocacao.data_alocacao, alocacao.data_devolucao, codUsuario, UsuarioLogado.codUsuario, codigo);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Livro(s) alocado(s) com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(alocacao.tipoUsuario == "A")
                    {
                        MessageBox.Show("Não foi possivel localizar nenhum aluno com este RM", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(alocacao.tipoUsuario == "P")
                    {
                        MessageBox.Show("Não foi possivel localizar nenhum professor com este RM", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel localizar nenhum funcionário com este CPF", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                conBCO.Close();
            }
            catch
            {
                MessageBox.Show("Não foi possivel alocar este(s) livro(s), Ocorreu um erro na operação de alocar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                conBCO.Close();
            }
        }

        public static void cad_curso(Curso curso)
        {
            MySqlConnection conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();

            try
            {
                for(int i = 0; i < curso.turmas.Count; i++)
                {
                    cmd.CommandText = String.Format("INSERT INTO curso (nome_curso, modulo_serie, periodo, turma, tipo, id_instituicao_curso) VALUES ('{0}', {1}, '{2}', '{3}', '{4}', {5})", curso.nome_curso, curso.modulo_series[i], curso.periodos[i], curso.turmas[i], curso.tipo, curso.id_instituicao);

                    cmd.ExecuteNonQuery();
                }
                

                MessageBox.Show("Curso cadastrado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBCO.Close();
            }
            catch
            {
                MessageBox.Show("Curso não cadastrado, Ocorreu um erro na operação de cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBCO.Close();
            }
        }

        public static void cad_funcionario(Funcionario funcionario) // cadastramento do autor
        {
            var conBCO = conexaoBCO();
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var cmd = conBCO.CreateCommand();

            try
            {
                //Pesquisando cpf

                dt.Rows.Clear();
                cmd.CommandText = "SELECT * FROM funcionario AS f WHERE f.cpf = " + funcionario.cpf + " LIMIT 1";

                da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    //Cadastrando um novo usuário

                    cmd.CommandText = "INSERT INTO usuario (senha, nivel_acesso, status_usuario) VALUES (@senha, 'U', 'D')";
                    cmd.Parameters.AddWithValue("@senha", funcionario.senha);
                    cmd.ExecuteNonQuery();

                    string codigoUsuario = cmd.LastInsertedId.ToString(); //Último id inserido no banco de dados

                    //Cadastrando aluno

                    if (funcionario.sexo != "P")
                    {
                        cmd.CommandText = "INSERT INTO funcionario (cpf, nome, sobrenome, sexo, data_cadastro, img_funcionario, id_usuario_funcionario) VALUES (@cpf, @nome, @sobrenome, @sexo, CURDATE(), @img_funcionario, @id)";

                        cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
                        cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                        cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                        cmd.Parameters.AddWithValue("@sexo", funcionario.sexo);
                        cmd.Parameters.AddWithValue("@img_funcionario", funcionario.imgFuncionario);
                        cmd.Parameters.AddWithValue("@id", codigoUsuario);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO funcionario (cpf, nome, sobrenome, sexo, data_cadastro, img_funcionario, id_usuario_funcionario) VALUES (@cpf, @nome, @sobrenome, NULL, CURDATE(), @img_funcionario, @id)";

                        cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
                        cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                        cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                        cmd.Parameters.AddWithValue("@img_funcionario", funcionario.imgFuncionario);
                        cmd.Parameters.AddWithValue("@id", codigoUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    //Cadastrando endereço do aluno

                    cmd.CommandText = "INSERT INTO endereco_funcionario (cep, logradouro, numero, bairro, cidade, complemento, cpf_funcionario_endereco) VALUES (@cep, @logradouro, @numero, @bairro, @cidade, @complemento, @cpf_end)";

                    cmd.Parameters.AddWithValue("@cep", funcionario.cep);
                    cmd.Parameters.AddWithValue("@logradouro", funcionario.logradouro);
                    cmd.Parameters.AddWithValue("@numero", funcionario.numero);
                    cmd.Parameters.AddWithValue("@bairro", funcionario.bairro);
                    cmd.Parameters.AddWithValue("@cidade", funcionario.cidade);
                    cmd.Parameters.AddWithValue("@complemento", funcionario.complemento);
                    cmd.Parameters.AddWithValue("@cpf_end", funcionario.cpf);
                    cmd.ExecuteNonQuery();

                    //Cadastrando contato do aluno

                    cmd.CommandText = "INSERT INTO contato_funcionario (telefone, celular, email, cpf_funcionario) VALUES (@telefone, @celular, @email, @cpf_cont)";

                    cmd.Parameters.AddWithValue("@telefone", funcionario.telefone);
                    cmd.Parameters.AddWithValue("@celular", funcionario.celular);
                    cmd.Parameters.AddWithValue("@email", funcionario.email);
                    cmd.Parameters.AddWithValue("@cpf_cont", funcionario.cpf);
                    cmd.ExecuteNonQuery();

                    //Cadastrando cursos do aluno

                    for (int i = 0; i < funcionario.instituicoes.Count; i++)
                    {
                        cmd.CommandText = "INSERT INTO instituicao_usuario (situacao, id_usuario, id_instituicao) VALUES (NULL, " + codigoUsuario + ", " + funcionario.instituicoes[i] + ")";

                        cmd.ExecuteNonQuery();
                    }

                    //Enviando uma mensagem de boas vindas para este usuario que acabou de ser cadastrado!

                    cmd.CommandText = "INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES ('Saudações', 'Seja bem vindo ao sistema da biblioteca, aqui além de você poder consultar os livros de sua ETEC, você também terá acesso a consulta de diversos livros de outras ETECs(caso essas ETECs estejam incluidas no sistema)', 'N', CURDATE(), " + codigoUsuario + ", " + UsuarioLogado.codUsuario + ")";

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("funcionário cadastrado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Já existe um funcionário cadastrado com este CPF", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                conBCO.Close();
            }
            catch
            {
                MessageBox.Show("funcionário não cadastrado!, Ocorreu um erro no cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conBCO.Close();
            }
        }

        public static void cad_aluno(Aluno aluno)
        {
            var conBCO = conexaoBCO();
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var cmd = conBCO.CreateCommand();

            try
            {
                //Pesquisando se o rm cadastrado existe

                cmd.CommandText = "SELECT * FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE a.rm_aluno = " + aluno.rm_aluno + " LIMIT 1";

                da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    //Cadastrando um novo usuário

                    cmd.CommandText = "INSERT INTO usuario (senha, nivel_acesso, status_usuario) VALUES (@senha, 'U', 'D')";
                    cmd.Parameters.AddWithValue("@senha", aluno.senha);
                    cmd.ExecuteNonQuery();

                    string codigoUsuario = cmd.LastInsertedId.ToString(); //Último id inserido no banco de dados

                    //Cadastrando aluno
                    if (aluno.sexo != "P")
                    {
                        cmd.CommandText = "INSERT INTO aluno (rm_aluno, nome, sobrenome, cpf, sexo, data_cadastro, img_aluno, id_usuario_aluno) VALUES (@rm, @nome, @sobrenome, @cpf, @sexo, CURDATE(), @img_aluno, @id)";

                        cmd.Parameters.AddWithValue("@rm", aluno.rm_aluno);
                        cmd.Parameters.AddWithValue("@nome", aluno.nome);
                        cmd.Parameters.AddWithValue("@sobrenome", aluno.sobrenome);
                        cmd.Parameters.AddWithValue("@cpf", aluno.cpf);
                        cmd.Parameters.AddWithValue("@sexo", aluno.sexo);
                        cmd.Parameters.AddWithValue("@img_aluno", aluno.imgAluno);
                        cmd.Parameters.AddWithValue("@id", codigoUsuario);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO aluno (rm_aluno, nome, sobrenome, cpf, sexo, data_cadastro, img_aluno, id_usuario_aluno) VALUES (@rm, @nome, @sobrenome, @cpf, NULL, CURDATE(), @img_aluno, @id)";

                        cmd.Parameters.AddWithValue("@rm", aluno.rm_aluno);
                        cmd.Parameters.AddWithValue("@nome", aluno.nome);
                        cmd.Parameters.AddWithValue("@sobrenome", aluno.sobrenome);
                        cmd.Parameters.AddWithValue("@cpf", aluno.cpf);
                        cmd.Parameters.AddWithValue("@img_aluno", aluno.imgAluno);
                        cmd.Parameters.AddWithValue("@id", codigoUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    //Cadastrando endereço do aluno

                    cmd.CommandText = "INSERT INTO endereco_aluno (cep, logradouro, numero, bairro, cidade, complemento, rm_aluno_endereco) VALUES (@cep, @logradouro, @numero, @bairro, @cidade, @complemento, @rm_end)";

                    cmd.Parameters.AddWithValue("@cep", aluno.cep);
                    cmd.Parameters.AddWithValue("@logradouro", aluno.logradouro);
                    cmd.Parameters.AddWithValue("@numero", aluno.numero);
                    cmd.Parameters.AddWithValue("@bairro", aluno.bairro);
                    cmd.Parameters.AddWithValue("@cidade", aluno.cidade);
                    cmd.Parameters.AddWithValue("@complemento", aluno.complemento);
                    cmd.Parameters.AddWithValue("@rm_end", aluno.rm_aluno);
                    cmd.ExecuteNonQuery();

                    //Cadastrando contato do aluno

                    cmd.CommandText = "INSERT INTO contato_aluno (telefone, celular, email, rm_aluno_contato) VALUES (@telefone, @celular, @email, @rm_cont)";

                    cmd.Parameters.AddWithValue("@telefone", aluno.telefone);
                    cmd.Parameters.AddWithValue("@celular", aluno.celular);
                    cmd.Parameters.AddWithValue("@email", aluno.email);
                    cmd.Parameters.AddWithValue("@rm_cont", aluno.rm_aluno);
                    cmd.ExecuteNonQuery();

                    //Cadastrando cursos do aluno

                    foreach (string codigo in aluno.cursos)
                    {
                        cmd.CommandText = "INSERT INTO curso_usuario (usuario_id_usuario, curso_id_curso) VALUES (" + codigoUsuario + ", " + codigo + ")";

                        cmd.ExecuteNonQuery();
                    }

                    //Enviando uma mensagem de boas vindas para este usuario que acabou de ser cadastrado!

                    cmd.CommandText = "INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES ('Saudações', 'Seja bem vindo ao sistema da biblioteca, aqui além de você poder consultar os livros de sua ETEC, você também terá acesso a consulta de diversos livros de outras ETECs(caso essas ETECs estejam incluidas no sistema)', 'N', CURDATE(), " + codigoUsuario + ", " + UsuarioLogado.codUsuario + ")";

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Aluno cadastrado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Já existe um aluno cadastrado com este RM", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                conBCO.Close();
            }
            catch
            {
                MessageBox.Show("Aluno não cadastrado!, Ocorreu um erro no cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conBCO.Close();
            }
        }

        public static void cad_professor(Professor professor)
        {
            var conBCO = conexaoBCO();
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var cmd = conBCO.CreateCommand();

            try
            {
                //Pesquisando se o rm cadastrado existe

                cmd.CommandText = "SELECT * FROM usuario AS u INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE p.rm_professor = " + professor.rm_professor + " LIMIT 1";

                da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    //Pesquisando cpf

                    dt.Rows.Clear();
                    cmd.CommandText = "SELECT * FROM professor AS p WHERE p.cpf = " + professor.cpf + " LIMIT 1";

                    da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        //Cadastrando um novo usuário

                        cmd.CommandText = "INSERT INTO usuario (senha, nivel_acesso, status_usuario) VALUES (@senha, 'U', 'D')";
                        cmd.Parameters.AddWithValue("@senha", professor.senha);
                        cmd.ExecuteNonQuery();

                        string codigoUsuario = cmd.LastInsertedId.ToString(); //Último id inserido no banco de dados

                        //Cadastrando aluno
                        
                        if(professor.sexo != "P")
                        {
                            cmd.CommandText = "INSERT INTO professor (rm_professor, nome, sobrenome, cpf, sexo, data_cadastro, img_professor, id_usuario_professor, sede) VALUES (@rm, @nome, @sobrenome, @cpf, @sexo, CURDATE(), @img_professor, @id, @sede)";

                            cmd.Parameters.AddWithValue("@rm", professor.rm_professor);
                            cmd.Parameters.AddWithValue("@nome", professor.nome);
                            cmd.Parameters.AddWithValue("@sobrenome", professor.sobrenome);
                            cmd.Parameters.AddWithValue("@cpf", professor.cpf);
                            cmd.Parameters.AddWithValue("@sexo", professor.sexo);
                            cmd.Parameters.AddWithValue("@img_professor", professor.imgProfessor);
                            cmd.Parameters.AddWithValue("@id", codigoUsuario);
                            cmd.Parameters.AddWithValue("@sede", professor.sede);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "INSERT INTO professor (rm_professor, nome, sobrenome, cpf, sexo, data_cadastro, img_professor, id_usuario_professor, sede) VALUES (@rm, @nome, @sobrenome, @cpf, NULL, CURDATE(), @img_professor, @id, @sede)";

                            cmd.Parameters.AddWithValue("@rm", professor.rm_professor);
                            cmd.Parameters.AddWithValue("@nome", professor.nome);
                            cmd.Parameters.AddWithValue("@sobrenome", professor.sobrenome);
                            cmd.Parameters.AddWithValue("@cpf", professor.cpf);
                            cmd.Parameters.AddWithValue("@img_professor", professor.imgProfessor);
                            cmd.Parameters.AddWithValue("@id", codigoUsuario);
                            cmd.Parameters.AddWithValue("@sede", professor.sede);
                            cmd.ExecuteNonQuery();
                        }

                        //Cadastrando endereço do aluno

                        cmd.CommandText = "INSERT INTO endereco_professor (cep, logradouro, numero, bairro, cidade, complemento, rm_professor_endereco) VALUES (@cep, @logradouro, @numero, @bairro, @cidade, @complemento, @rm_end)";

                        cmd.Parameters.AddWithValue("@cep", professor.cep);
                        cmd.Parameters.AddWithValue("@logradouro", professor.logradouro);
                        cmd.Parameters.AddWithValue("@numero", professor.numero);
                        cmd.Parameters.AddWithValue("@bairro", professor.bairro);
                        cmd.Parameters.AddWithValue("@cidade", professor.cidade);
                        cmd.Parameters.AddWithValue("@complemento", professor.complemento);
                        cmd.Parameters.AddWithValue("@rm_end", professor.rm_professor);
                        cmd.ExecuteNonQuery();

                        //Cadastrando contato do aluno

                        cmd.CommandText = "INSERT INTO contato_professor (telefone, celular, email, rm_professor_contato) VALUES (@telefone, @celular, @email, @rm_cont)";

                        cmd.Parameters.AddWithValue("@telefone", professor.telefone);
                        cmd.Parameters.AddWithValue("@celular", professor.celular);
                        cmd.Parameters.AddWithValue("@email", professor.email);
                        cmd.Parameters.AddWithValue("@rm_cont", professor.rm_professor);
                        cmd.ExecuteNonQuery();

                        //Cadastrando cursos do aluno

                        for (int i = 0; i < professor.instituicoes.Count; i++)
                        {
                            cmd.CommandText = "INSERT INTO instituicao_usuario (situacao, id_usuario, id_instituicao) VALUES ('" + professor.situacoes[i] + "', " + codigoUsuario + ", " + professor.instituicoes[i] + ")";

                            cmd.ExecuteNonQuery();
                        }

                        //Enviando uma mensagem de boas vindas para este usuario que acabou de ser cadastrado!

                        cmd.CommandText = "INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES ('Saudações', 'Seja bem vindo ao sistema da biblioteca, aqui além de você poder consultar os livros de sua ETEC, você também terá acesso a consulta de diversos livros de outras ETECs(caso essas ETECs estejam incluidas no sistema)', 'N', CURDATE(), " + codigoUsuario + ", " + UsuarioLogado.codUsuario + ")";

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Professor cadastrado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Já existe um professor cadastrado com este CPF", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Já existe um professor cadastrado com este RM", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                conBCO.Close();
            }
            catch
            {
                MessageBox.Show("Professor não cadastrado!, Ocorreu um erro no cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conBCO.Close();
            }
        }
    }
}
