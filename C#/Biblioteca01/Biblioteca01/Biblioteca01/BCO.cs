using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Biblioteca01
{
    class BCO
    {
        private static MySqlConnection conexaoBCO()
        {
            string strcon = "datasource = localhost; database = bdbibliotecaetec; Uid = root; password = ";
            MySqlConnection con = new MySqlConnection(strcon);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable Dml(string sql, string msgHit = null, string msgErro = null)
        {
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = sql;
                da = new MySqlDataAdapter(cmd.CommandText, conBCO);
                cmd.ExecuteNonQuery();
                conBCO.Close();
                if (msgHit != null)
                {
                    MessageBox.Show(msgHit);
                }

                return dt;
            }
            catch (Exception ex)
            {
                if (msgErro != null)
                {
                    MessageBox.Show(msgErro + "\n" + ex.Message);
                }

                throw ex;
            }
        }

        // CONSULTA PARA ACESSAR O SOFTWARE
        
        
        public static DataTable verificacao_de_acesso(string sql)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
       

        // FIM CONSULTA SOFTWARE


        // CADASTRO GENERO //
        public static bool verificar_genero(Livro livro) // verificação do genero ( caso exista vai denunciar)
        {
            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select nome_genero from genero where nome_genero = '" + livro.nome_genero + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }
                   
        public static void cad_genero(Livro livro) // cadastramento do genero 
        {

            if (verificar_genero(livro))
            {
                MessageBox.Show("Gênero já cadastrado");
                return;
            }
            try
            {
                //conBCO;
                
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into genero (nome_genero) values (@nome_genero)";
                cmd.Parameters.AddWithValue("@nome_genero", livro.nome_genero);
             
                cmd.ExecuteNonQuery();
      

                   /* if (cmd.LastInsertedId != 0)
                        cmd.Parameters.Add(new MySqlParameter("id_genero", cmd.LastInsertedId));
                    // Retorna o id do novo rgistro e convert de Int64 para Int32 (int).
                    var id_genero = Convert.ToInt32(cmd.Parameters["@id_genero"].Value);

                    MessageBox.Show("Id:"+id_genero);*/

                   MessageBox.Show("Gênero inserido com sucesso !");
                conBCO.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Entrar em contato com equipe de suporte");
            }

        }

        public static bool verificicao_de_exclusao_genero(Livro livro) // verificação para exclusão
        {
            bool resposta; 

            try
            {

                if (MessageBox.Show("Você tem certeza que deseja fazer essa exclusão ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }


        }

        public static void excluir_genero(Livro livro)
        {
            if (verificicao_de_exclusao_genero(livro) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete from genero where nome_genero = '" + livro.nome_genero + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Gênero excluido com sucesso !");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }
        // FIM CADASTRO GENERO//


        // AUTOR - CADASTRO, ALTERAÇÃO, EXCLUSÃO
        public static bool verificar_autor(Livro livro) // verificação da existencia do autor ( caso exista vai denunciar)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select nome_autor from autor where nome_autor = '" + livro.nome_autor + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }

        public static void cad_autor(Livro livro) // cadastramento do autor
        {

            if (verificar_autor(livro))
            {
                MessageBox.Show("Autor já cadastrado");
                return;
            }
            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into autor (nome_autor, nacionalidade) values (@nome_autor,@nacionalidade_autor) "; // erro
                cmd.Parameters.AddWithValue("@nome_autor", livro.nome_autor);
                cmd.Parameters.AddWithValue("@nacionalidade_autor", livro.nacionalidade_autor);
                // cmd.Parameters.AddWithValue("@cod_colaborador", autor.colaborador);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Autor inserido com sucesso !");
                conBCO.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }

        }

        public static bool verificicao_de_exclusao_autor(Livro livro) // verificação para exclusão
        {
            bool resposta; 
                                               
            try
            {

                if (MessageBox.Show("Você tem certeza que deseja fazer essa exclusão ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }

        }

        public static void excluir_autor(Livro livro)
        {
            if (verificicao_de_exclusao_autor(livro) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete from autor where nome_autor = '" + livro.nome_autor + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Autor excluído com sucesso !");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }
  
        public static DataTable mostrar_autor()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "  select id_autor as 'id', nome_autor as 'Nome', nacionalidade as 'Nacionalidade' from autor; ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                
            }


        }
        
        // FIM AUTOR


        // EDITORA - CADASTRO, ALTERAÇÃO, EXCLUSÃO
        public static bool verificar_editora(Livro livro) // verificação da existencia do editora ( caso exista vai denunciar)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select nome_editora from editora where nome_editora = '" + livro.nome_editora + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }

        public static void cad_editora(Livro livro) // cadastramento de editora
        {

            if (verificar_editora(livro))
            {
                MessageBox.Show("Editora já cadastrada");
                return;
            }
            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into editora (nome_editora, cnpj) values (@nome_editora,@cnpj) ";
                cmd.Parameters.AddWithValue("@nome_editora", livro.nome_editora);
                cmd.Parameters.AddWithValue("@cnpj", livro.cnpj);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Editora inserida com sucesso !");
                conBCO.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }

        }

        public static bool verificicao_de_exclusao_editora(Livro livro) // verificação para exclusão
        {
            bool resposta; // resposta
                           //  MySqlDataAdapter da = null;
                           //   DataTable dt = new DataTable();
            try
            {

                if (MessageBox.Show("Você tem certeza que deseja fazer essa exclusão ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }


        }

        public static void excluir_editora(Livro livro)
        {
            if (verificicao_de_exclusao_editora(livro) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete from editora where nome_editora = '" + livro.nome_editora + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Editora excluída com sucesso !");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }
        
        public static DataTable mostrar_editora()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "  select nome_editora as 'Nome Editora' from editora; ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }


        }

        // FIM EDITORA


        // LIVRO - CADASTRO, ALTERAÇÃO, EXCLUSÃO
        public static bool verificar_livro(Livro livro) // verificação da existencia do livro ( caso exista vai denunciar)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select tombo from livro where tombo = '" + livro.tombo + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }

        public static void cad_livro(Livro livro)
        {
            if (verificar_livro(livro))
            {
                MessageBox.Show("Livro já cadastrada");
                return;
            }
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into livro (tombo,titulo,ano_publicacao,volume,edicao,insercao,isbn,idioma,editora_id_editora,genero_id_genero,autor_id_autor,colaborador_id_colaborador) " +
                    "values (@tombo,@titulo,@ano_publicacao,@volume,@edicao,@insercao,@isbn,@idioma,@editora_id_editora,@genero_id_genero,@autor_id_autor,@colaborador_id_colaborador)";

                
                cmd.Parameters.AddWithValue("@tombo", livro.tombo);
                cmd.Parameters.AddWithValue("@titulo", livro.titulo);
                cmd.Parameters.AddWithValue("@ano_publicacao", livro.ano_publicacao);
                cmd.Parameters.AddWithValue("@volume", livro.volume);
                cmd.Parameters.AddWithValue("@edicao", livro.edicao);
                cmd.Parameters.AddWithValue("@insercao", livro.insercao);
                cmd.Parameters.AddWithValue("@isbn", livro.isbn);
                cmd.Parameters.AddWithValue("@idioma", livro.idioma);
                cmd.Parameters.AddWithValue("@editora_id_editora", livro.editora_id_editora);
                cmd.Parameters.AddWithValue("@genero_id_genero", livro.genero_id_genero);
                cmd.Parameters.AddWithValue("@autor_id_autor", livro.autor_id_autor);
                cmd.Parameters.AddWithValue("@colaborador_id_colaborador", livro.colaborador_id_colaborador);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into exemplares (quantidade,livro_tombo_exemplares,id_instituicao) " +
                    "values (@quantidade,@livro_tombo_exemplares,@id_instituicao)";

                cmd.Parameters.AddWithValue("@quantidade", livro.quantidade);
                cmd.Parameters.AddWithValue("@livro_tombo_exemplares", livro.livro_tombo_exemplares);
                cmd.Parameters.AddWithValue("@id_instituicao", livro.id_instituicao);
                cmd.ExecuteNonQuery();


                cmd.CommandText = "insert into colaboradores (nomes, id_colaborador) values (@nomes, @id_colaborador)";

                cmd.Parameters.AddWithValue("@nomes", livro.nome_colaboradores);
                cmd.Parameters.AddWithValue("@id_colaborador", livro.colaborador_id_colaborador);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Livro inserido com sucesso");
                conBCO.Close();

                       
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }
        }

        public static bool verificacao_de_certeza_livro(Livro livro) // verificação para exclusão
        {
            bool resposta; // resposta
                           //  MySqlDataAdapter da = null;
                           //   DataTable dt = new DataTable();
            try
            {
                if (MessageBox.Show("Você tem certeza ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }
        }

        public static void excluir_livro(Livro livro)
        {
            if (verificacao_de_certeza_livro(livro) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = "delete livro.*, exemplares.* from livro, exemplares where livro.tombo =  '" + livro.tombo + "' and  exemplares.livro_tombo_exemplares =  '" + livro.tombo + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Livro excluído com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static void alterar_Livro(Livro livro)
        {
            if (verificacao_de_certeza_livro(livro) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = "update livro inner join exemplares on exemplares.livro_tombo_exemplares = livro.tombo  set livro.titulo = '" + livro.titulo + "',livro.ano_publicacao = '" + livro.ano_publicacao + "' ,livro.volume = '" + livro.volume + "', livro.edicao = '" + livro.edicao + "', livro.insercao = '" + livro.insercao + "', livro.isbn = '" + livro.isbn + "', livro.idioma = '" + livro.idioma + "',livro.editora_id_editora = '" + livro.editora_id_editora + "',  livro.genero_id_genero = '" + livro.genero_id_genero + "',  livro.autor_id_autor = '" + livro.autor_id_autor + "', exemplares.quantidade = '" + livro.quantidade + "'   where tombo = '" + livro.tombo + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Livro Alterado com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static DataTable mostrar_livro()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select livro.tombo as 'Tombo', livro.titulo as 'Titulo' ,livro. ano_publicacao as 'Publicacao' ,livro.volume as 'Volume' ,livro.edicao as 'Edicao',livro.insercao as 'Insercao' ,livro.idioma as 'Idioma',genero.nome_genero as 'Genero',autor.nome_autor as 'Autor', editora.nome_editora as 'Editora',colaboradores.nomes from livro left join genero on genero.id_genero = livro.genero_id_genero left join autor on autor.id_autor = livro.autor_id_autor left join editora on editora.id_editora = livro.editora_id_editora left join colaboradores on colaboradores.id_colaborador = livro.colaborador_id_colaborador";                                   
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }


        }

        public static DataTable pesquisar_Tombo(Livro livro)
        {
            //Livro livro = new Livro();
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select livro.tombo as 'Tombo', livro.titulo as 'Titulo' ,livro. ano_publicacao as 'Publicacao' ,livro.volume as 'Volume' ,livro.edicao as 'Edicao',livro.insercao as 'Insercao' ,livro.idioma as 'Idioma',genero.nome_genero as 'Genero',autor.nome_autor as 'Autor', editora.nome_editora as 'Editora',colaboradores.nomes from livro left join genero on genero.id_genero = livro.genero_id_genero left join autor on autor.id_autor = livro.autor_id_autor left join editora on editora.id_editora = livro.editora_id_editora left join colaboradores on colaboradores.id_colaborador = livro.colaborador_id_colaborador where tombo = '" + livro.pesquisa_tombo+"'"; 
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisar_neutra_Livro(Livro livro)
        {
            //Livro livro = new Livro();
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select livro.tombo as 'Tombo', livro.titulo as 'Titulo' ,livro. ano_publicacao as 'Publicacao' ,livro.volume as 'Volume' ,livro.edicao as 'Edicao',livro.insercao as 'Insercao' ,livro.idioma as 'Idioma',genero.nome_genero as 'Genero',autor.nome_autor as 'Autor', editora.nome_editora as 'Editora',colaboradores.nomes from livro left join genero on genero.id_genero = livro.genero_id_genero left join autor on autor.id_autor = livro.autor_id_autor left join editora on editora.id_editora = livro.editora_id_editora left join colaboradores on colaboradores.id_colaborador = livro.colaborador_id_colaborador where titulo = '" + livro.pesquisa_neutra + "' or idioma = '" + livro.pesquisa_neutra + "' or nome_autor = '" + livro.pesquisa_neutra + "' or nome_genero= '" + livro.pesquisa_neutra + "' or nome_editora = '" + livro.pesquisa_neutra + "' or nomes = '" + livro.pesquisa_neutra + "' ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisar_avançada_Livro(Livro livro)
        {
            //Livro livro = new Livro();
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select livro.tombo as 'Tombo', livro.titulo as 'Titulo' ,livro. ano_publicacao as 'Publicacao' ,livro.volume as 'Volume' ,livro.edicao as 'Edicao',livro.insercao as 'Insercao' ,livro.idioma as 'Idioma',genero.nome_genero as 'Genero',autor.nome_autor as 'Autor', editora.nome_editora as 'Editora',colaboradores.nomes from livro left join genero on genero.id_genero = livro.genero_id_genero left join autor on autor.id_autor = livro.autor_id_autor left join editora on editora.id_editora = livro.editora_id_editora left join colaboradores on colaboradores.id_colaborador = livro.colaborador_id_colaborador where  tombo = '" + livro.pesquisa_tombo + "' or titulo = '" + livro.pesquisa_neutra + "' or idioma = '" + livro.pesquisa_neutra + "'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        // FIM LIVRO


        // LOCAÇÃO - CADASTRO, ALTERAÇÃO, EXCLUSÃO 
        public static bool verificar_rm_usuario(Alocacao alocacao) // verificação da rm do usuario( caso exista vai denunciar)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select rm_usuario from usuario where rm_usuario = '" + alocacao.rm_usuario + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }

        public static bool verificar_rm_admin(Alocacao alocacao) // verificação se o rm é permitido cadastrar( caso exista vai denunciar)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select * from usuario where rm_usuario = '" + alocacao.rm_admin + "' and nivel_acesso ='ADMIN' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }

        public static bool verificacao_acesso_usuario(Alocacao alocacao) // verificação caso o status do usuario seja bloqueado ele não pode fazer a alocação
        {
            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = "select * from usuario where rm_usuario = '" + alocacao.rm_usuario + "' and status_usuario ='BLOQUEADO'";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        } 

        public static bool verificar_tombo(Alocacao alocacao) // verificação da existencia do livro ( caso exista vai denunciar)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select livro_tombo_exemplares from exemplares where livro_tombo_exemplares = '" + alocacao.tombo_exemplares + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }  
        
        public static void cad_locacaoes(Alocacao alocacao)
        {
            if (verificar_tombo(alocacao))
            {
                MessageBox.Show("Livro não cadastrado no sistema!");
                return;
            }
            if (verificar_rm_usuario(alocacao))
            {
                MessageBox.Show("Rm não existe");
                return;
            }
            if (verificacao_acesso_usuario(alocacao))
            {
                MessageBox.Show("Usuário bloqueado para fazer locações");
                return;
            }
            if (verificar_rm_admin(alocacao))
            {
                MessageBox.Show("Rm não permitido a fazer cadastros");
                return;
            }
           
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into locacao (data_locacao,data_devolucao,tombo_exemplares,rm_usuario_locacao,rm_usuarioAdimin_locacao,situacao) " +
                    "values (@data_locacao,@data_devolucao,@tombo_exemplares,@rm_usuario_locacao,@rm_usuarioAdimin_locacao,@situacao)";

                cmd.Parameters.AddWithValue("@data_locacao", alocacao.data_locacao);
                cmd.Parameters.AddWithValue("@data_devolucao", alocacao.data_devolucao);
                cmd.Parameters.AddWithValue("@tombo_exemplares", alocacao.tombo_exemplares);
                cmd.Parameters.AddWithValue("@rm_usuario_locacao", alocacao.rm_usuario);
                cmd.Parameters.AddWithValue("@rm_usuarioAdimin_locacao", alocacao.rm_admin);
                cmd.Parameters.AddWithValue("@situacao", alocacao.situacao);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Emprestimo realizado com sucesso");
                conBCO.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void alterar_Locacao(Alocacao alocacao)
        {
            if (verificar_tombo(alocacao))
            {
                MessageBox.Show("Livro não cadastrado no sistema!");
                return;
            }
            if (verificar_rm_usuario(alocacao))
            {
                MessageBox.Show("Rm não existe");
                return;
            }
            if (verificacao_acesso_usuario(alocacao))
            {
                MessageBox.Show("Usuário bloqueado para fazer Alteração");
                return;
            }
            if (verificar_rm_admin(alocacao))
            {
                MessageBox.Show("Rm não permitido a fazer Alteração");
                return;
            }
            if (verificacao_de_certeza_locacao(alocacao) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = "update locacao set data_locacao = '" + alocacao.data_locacao + "' ,data_devolucao = '" + alocacao.data_devolucao + "',rm_usuario_locacao = '" + alocacao.rm_usuario + "',rm_usuarioAdimin_locacao = '" + alocacao.rm_admin + "',situacao = '" + alocacao.situacao + "',tombo_exemplares = '" + alocacao.tombo_exemplares + "' where id_locacao = '" + alocacao.id_locacao + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Locação Alterada com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static bool verificacao_de_certeza_locacao(Alocacao alocacao) // verificação para exclusão
        {
            bool resposta; // resposta
                           //  MySqlDataAdapter da = null;
                           //   DataTable dt = new DataTable();
            try
            {
                if (MessageBox.Show("Você tem certeza ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }
        }

        public static void excluir_locacao(Alocacao alocacao)
        {
            if (verificacao_de_certeza_locacao(alocacao) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete from locacao where id_locacao  = '" + alocacao.id_locacao + "' ";

                    //DEPOIS VERIFICAR SE O COMANDO ACIMA ESTÁ CERTO!!!                  

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Locação excluída com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static DataTable mostrar_locacaoes()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select  locacao.id_locacao as 'Id', locacao.rm_usuario_locacao as 'Rm',aluno.nome as 'Nome',aluno.sobrenome as 'Sobrenome',usuario.status_usuario as 'Status',livro.titulo as 'Titulo',locacao.tombo_exemplares as 'Tombo',locacao.data_locacao as 'Data de Locacao',locacao.situacao as ' Situacao', locacao.data_devolucao as 'Data de Entrega' , locacao.rm_usuarioAdimin_locacao as ' Rm Admin' from locacao  left join usuario on usuario.rm_usuario = locacao.rm_usuario_locacao left join aluno on aluno.rm_usuario_aluno = usuario.rm_usuario left join livro on livro.tombo = locacao.tombo_exemplares ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }


        }

        public static DataTable mostrando_locacoes(string id)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select * from locacao where id_locacao="+id;
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }


        }

        public static DataTable pesquisar_letras_Locacao(Alocacao alocacao)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select  locacao.id_locacao as 'Id', locacao.rm_usuario_locacao as 'Rm',aluno.nome as 'Nome',aluno.sobrenome as 'Sobrenome',usuario.status_usuario as 'Status',livro.titulo as 'Titulo',locacao.tombo_exemplares as 'Tombo',locacao.data_locacao,locacao.situacao as ' Situacao', locacao.data_devolucao as 'Data de Entrega' , locacao.rm_usuarioAdimin_locacao as ' Rm Admin' from locacao  left join usuario on usuario.rm_usuario = locacao.rm_usuario_locacao left join aluno on aluno.rm_usuario_aluno = usuario.rm_usuario left join livro on livro.tombo = locacao.tombo_exemplares where aluno.nome = '" + alocacao.pesquisar_letra + "' or aluno.sobrenome = '" + alocacao.pesquisar_letra + "' or livro.titulo = '" + alocacao.pesquisar_letra + "' or locacao.situacao = '" + alocacao.pesquisar_letra + "'  "; // rm_funcionario= '" + funcionario.pesquisa_rm_Funcionario+ "'
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisar_numeros_Locacao(Alocacao alocacao)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select locacao.id_locacao as 'Id',locacao.rm_usuario_locacao as 'Rm',aluno.nome as 'Nome',aluno.sobrenome as 'Sobrenome',usuario.status_usuario as 'Status',livro.titulo as 'Titulo',locacao.tombo_exemplares as 'Tombo',locacao.data_locacao,locacao.situacao as ' Situacao', locacao.data_devolucao as 'Data de Entrega' , locacao.rm_usuarioAdimin_locacao as ' Rm Admin' from locacao  left join usuario on usuario.rm_usuario = locacao.rm_usuario_locacao left join aluno on aluno.rm_usuario_aluno = usuario.rm_usuario left join livro on livro.tombo = locacao.tombo_exemplares where locacao.id_locacao = '" + alocacao.pesquisar_num + "'or locacao.tombo_exemplares = '" + alocacao.pesquisar_num + "' or locacao.rm_usuario_locacao = '" + alocacao.pesquisar_num + "' or rm_usuarioAdimin_locacao = '" + alocacao.pesquisar_num + "' "; 
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        // FIM LOCAÇÃO

        // CURSO - CADASTRO, ALTERAÇÃO, EXCLUSÃO
        public static bool verificar_curso(Curso curso) // verificação se existe algum curso com o mesmo cod
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select cod_curso from curso where cod_curso = '" + curso.cod_curso+ "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }

        public static void cad_curso(Curso curso)
        {
            if (verificar_curso(curso))
            {
                MessageBox.Show("Curso já cadastrado");
                return;
            }
            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into curso(cod_curso,nome_curso,modulo_serie,periodo,turma,tipo,id_instituicao_curso) " +
                    "values (@cod_curso,@nome_curso,@modulo_serie,@periodo,@turma,@tipo,@id_instituicao_curso) ";

                cmd.Parameters.AddWithValue("@cod_curso", curso.cod_curso);
                cmd.Parameters.AddWithValue("@nome_curso", curso.nome_curso);
                cmd.Parameters.AddWithValue("@modulo_serie", curso.modulo_serie);
                cmd.Parameters.AddWithValue("@periodo", curso.periodo);
                cmd.Parameters.AddWithValue("@turma", curso.turma);
                cmd.Parameters.AddWithValue("@tipo", curso.tipo);
                cmd.Parameters.AddWithValue("@id_instituicao_curso", curso.id_instituicao_curso);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Curso "+curso.cod_curso+" cadastrado com sucesso");
                conBCO.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }
        }

        public static bool verificacao_de_exclusao_curso(Curso curso) // verificação para exclusão
        {
            bool resposta;
            try
            {

                if (MessageBox.Show("Você tem certeza que deseja fazer essa exclusão ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }
        }

        public static void excluir_curso(Curso curso)
        {
            if (verificacao_de_exclusao_curso(curso) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete curso.*, curso_usuario.* from curso,curso_usuario where curso.cod_curso = '" + curso.cod_curso + "' and curso_usuario.curso_id_curso = '" + curso.cod_curso + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Curso excluído com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }                    
            
        }

        public static DataTable mostrar_Cursos()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select nome_curso as 'Curso',modulo_serie as 'Modulos', periodo as 'Periodo',turma as 'Turma', Tipo as 'Tipo', id_instituicao_curso as 'Instituicao', cod_curso as 'Cod Curso' from Curso ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_Cursos(Curso curso)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select nome_curso as 'Curso',modulo_serie as 'Modulos', periodo as 'Periodo',turma as 'Turma', Tipo as 'Tipo', id_instituicao_curso as 'Instituicao', cod_curso as 'Cod Curso' from Curso where cod_curso = '" + curso.pesquisa_curso + "' or id_instituicao_curso = '" + curso.pesquisa_curso + "'"; 
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_neutra_Cursos(Curso curso)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select nome_curso as 'Curso',modulo_serie as 'Modulos', periodo as 'Periodo',turma as 'Turma', Tipo as 'Tipo', id_instituicao_curso as 'Instituicao', cod_curso as 'Cod Curso' from Curso where nome_curso = '" + curso.pesquisa_neutra + "' or periodo = '" + curso.pesquisa_neutra + "' or turma = '" + curso.pesquisa_neutra + "' or tipo = '" + curso.pesquisa_neutra + "' ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_elaborada_Cursos(Curso curso)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select nome_curso as 'Curso',modulo_serie as 'Modulos', periodo as 'Periodo',turma as 'Turma', Tipo as 'Tipo', id_instituicao_curso as 'Intituicao', cod_curso as 'Cod Curso' from Curso where cod_curso = '" + curso.pesquisa_curso + "' or id_instituicao_curso = '" + curso.pesquisa_curso + "' or nome_curso = '" + curso.pesquisa_neutra + "' or periodo = '" + curso.pesquisa_neutra + "' or turma = '" + curso.pesquisa_neutra + "' or tipo = '" + curso.pesquisa_neutra + "' ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        //FIM CURSO


        // FUNCIONARIO - CADASTRO, ALTERAÇÃO, EXCLUSÃO
        public static bool verificar_rm_aluno(Funcionario funcionario)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select rm_funcionario from funcionario where rm_funcionario = '" + funcionario.rm_funcionario + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;

        }

        public static bool verificar_cpf_funcionario(Funcionario funcionario) // verificação da existencia do funcionario ( caso exista vai denunciar)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select cpf from funcionario where cpf = '" + funcionario.cpf + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;
        }

        public static void cad_funcionario(Funcionario funcionario) // cadastramento do autor
        {

            if (verificar_cpf_funcionario(funcionario))
            {
                MessageBox.Show("Funcionario já cadastrado");
                return;
            }
            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into usuario(rm_usuario,senha,nivel_acesso,status_usuario) " +
                  "values (@rm_usuario,@senha,@nivel_acesso,@status_usuario)";

                cmd.Parameters.AddWithValue("@rm_usuario", funcionario.rm_usuario);
                cmd.Parameters.AddWithValue("@senha", funcionario.senha);
                cmd.Parameters.AddWithValue("@nivel_acesso", funcionario.nivel_acesso);
                cmd.Parameters.AddWithValue("@status_usuario", funcionario.status_usuario);
                cmd.ExecuteNonQuery();



                cmd.CommandText = "insert into funcionario (rm_funcionario,cpf,nome,sobrenome,sexo,data_cadastro,rm_usuario_funcionario) " +
                    "values (@rm_funcionario,@cpf,@nome,@sobrenome,@sexo,@data_cadastro,@rm_usuario_funcionario)";

                cmd.Parameters.AddWithValue("@rm_funcionario", funcionario.rm_funcionario);
                cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
                cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                cmd.Parameters.AddWithValue("@sexo", funcionario.sexo);
                cmd.Parameters.AddWithValue("@data_cadastro", funcionario.data_cadastro);
                cmd.Parameters.AddWithValue("@rm_usuario_funcionario", funcionario.rm_usuario_funcionario);
                cmd.ExecuteNonQuery();


                cmd.CommandText = "insert into endereco_funcionario (cep,logradouro,numero,bairro,cidade,complemento,rm_funcionario_endereco,rm_usuario_endereco) " +
                    "values (@cep,@logradouro,@numero,@bairro,@cidade,@complemento,@rm_funcionario_endereco,@rm_usuario_endereco)";

                cmd.Parameters.AddWithValue("@cep", funcionario.cep);
                cmd.Parameters.AddWithValue("@logradouro", funcionario.logradouro);
                cmd.Parameters.AddWithValue("@numero", funcionario.numero);
                cmd.Parameters.AddWithValue("@bairro", funcionario.bairro);
                cmd.Parameters.AddWithValue("@cidade", funcionario.cidade);
                cmd.Parameters.AddWithValue("@complemento", funcionario.complemento);
                cmd.Parameters.AddWithValue("@rm_funcionario_endereco", funcionario.rm_funcionario_endereco);
                cmd.Parameters.AddWithValue("@rm_usuario_endereco", funcionario.rm_usuario_endereco);
                cmd.ExecuteNonQuery();


                cmd.CommandText = "insert into contato_funcionario (telefone,celular,email,rm_funcionario_contato,rm_usuario_contato) " +
                    "values (@telefone,@celular,@email,@rm_funcionario_contato,@rm_usuario_contato)";

                cmd.Parameters.AddWithValue("@telefone", funcionario.telefone);
                cmd.Parameters.AddWithValue("@celular", funcionario.celular);
                cmd.Parameters.AddWithValue("@email", funcionario.email);
                cmd.Parameters.AddWithValue("@rm_funcionario_contato", funcionario.rm_funcionario_contato);
                cmd.Parameters.AddWithValue("@rm_usuario_contato", funcionario.rm_usuario_contato);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into instituicao_usuario (situacao,rm_usuario_instituicao,cod_instituicao) " +
                   "values (@situacao,@rm_usuario_instituicao,@cod_instituicao)";

                // cmd.Parameters.AddWithValue("@id_instituicao_usuario", professor.id_instituicao_usuario);
                cmd.Parameters.AddWithValue("@situacao", funcionario.situacao);
                cmd.Parameters.AddWithValue("@rm_usuario_instituicao", funcionario.rm_usuario_instituicao);
                cmd.Parameters.AddWithValue("@cod_instituicao", funcionario.cod_instituicao);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario inserido com sucesso !");
                conBCO.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }

        }

        public static void alterar_Funcionario(Funcionario funcionario)
        {
            if (verificacao_de_certeza_Funcionario(funcionario) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = "update usuario left join funcionario on funcionario.rm_usuario_funcionario = rm_usuario left join endereco_funcionario on endereco_funcionario.rm_usuario_endereco = rm_usuario left join contato_funcionario on  contato_funcionario.rm_usuario_contato = rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = rm_usuario set usuario.senha = '" + funcionario.senha + "', usuario.status_usuario = '" + funcionario.status_usuario + "', funcionario.nome = '" + funcionario.nome + "', funcionario.sobrenome = '" + funcionario.sobrenome + "', funcionario.cpf = '" + funcionario.cpf + "', funcionario.sexo = '" + funcionario.sexo + "',funcionario.data_cadastro = '" + funcionario.data_cadastro + "',endereco_funcionario.cep = '" + funcionario.cep + "',endereco_funcionario.logradouro = '" + funcionario.logradouro + "',endereco_funcionario.numero = '" + funcionario.numero + "',endereco_funcionario.bairro = '" + funcionario.bairro + "',endereco_funcionario.cidade = '" + funcionario.cidade + "',endereco_funcionario.complemento = '" + funcionario.complemento + "',contato_funcionario.telefone = '" + funcionario.telefone + "',contato_funcionario.celular = '" + funcionario.celular + "',contato_funcionario.email = '" + funcionario.email + "',instituicao_usuario.situacao = '" + funcionario.situacao + "' ,instituicao_usuario.cod_instituicao = '" + funcionario.cod_instituicao + "' where rm_usuario = '" + funcionario.rm_usuario + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionário Alterado com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static bool verificacao_de_certeza_Funcionario(Funcionario funcionario) // verificação para exclusão
        {
            bool resposta; // resposta
                           //  MySqlDataAdapter da = null;
                           //   DataTable dt = new DataTable();
            try
            {

                if (MessageBox.Show("Você tem certeza ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }
        }

        public static void excluir_funcionario(Funcionario funcionario)
        {
            if (verificacao_de_certeza_Funcionario(funcionario) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete funcionario.*, endereco_funcionario.*, contato_funcionario.*, usuario.*, instituicao_usuario.*  from  funcionario, endereco_funcionario, contato_funcionario, usuario, instituicao_usuario where funcionario.rm_funcionario =  '" + funcionario.rm_usuario + "' and endereco_funcionario.rm_funcionario_endereco = '" + funcionario.rm_usuario + "' and contato_funcionario.rm_funcionario_contato = '" + funcionario.rm_usuario + "' and  usuario.rm_usuario = '" + funcionario.rm_usuario + "' and  instituicao_usuario.rm_usuario_instituicao =  '" + funcionario.rm_usuario + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionário excluído com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static DataTable mostrar_Funcionario()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Funcionario',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status',funcionario.nome as 'Nome' ,funcionario.sobrenome as 'Sobrenome' ,funcionario.cpf as 'Cpf',funcionario.sexo as 'Sexo' ,funcionario.data_cadastro as 'Data Cadastro',instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao',contato_funcionario.telefone as 'Telefone',contato_funcionario.celular as 'Celular',contato_funcionario.email as 'E-mail',endereco_funcionario.cep as 'Cep', endereco_funcionario.logradouro as 'Logradouro' , endereco_funcionario.numero as 'N' , endereco_funcionario.bairro as 'Bairro' , endereco_funcionario.cidade as 'Cidade' from usuario left join funcionario on funcionario.rm_usuario_funcionario = usuario.rm_usuario  left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_funcionario on contato_funcionario.rm_usuario_contato = usuario.rm_usuario left join endereco_funcionario on endereco_funcionario.rm_usuario_endereco = usuario.rm_usuario  where nivel_acesso = 'FUNCIONARIO'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }

        public static DataTable pesquisar_Funcionario(Funcionario funcionario)
        {       

            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Funcionario',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status',funcionario.nome as 'Nome' ,funcionario.sobrenome as 'Sobrenome' ,funcionario.cpf as 'Cpf',funcionario.sexo as 'Sexo' ,funcionario.data_cadastro as 'Data Cadastro',instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao',contato_funcionario.telefone as 'Telefone',contato_funcionario.celular as 'Celular',contato_funcionario.email as 'E-mail',endereco_funcionario.cep as 'Cep', endereco_funcionario.logradouro as 'Logradouro' , endereco_funcionario.numero as 'N' , endereco_funcionario.bairro as 'Bairro' , endereco_funcionario.cidade as 'Cidade'  from usuario left join funcionario on funcionario.rm_usuario_funcionario = usuario.rm_usuario  left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_funcionario on contato_funcionario.rm_usuario_contato = usuario.rm_usuario left join endereco_funcionario on endereco_funcionario.rm_usuario_endereco = usuario.rm_usuario where rm_funcionario= '" + funcionario.pesquisa_rm_Funcionario+ "' or cpf = '" + funcionario.pesquisa_rm_Funcionario + "'  or cep = '" + funcionario.pesquisa_rm_Funcionario + "' ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_neutra_Funcionario(Funcionario funcionario)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Funcionario',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status',funcionario.nome as 'Nome' ,funcionario.sobrenome as 'Sobrenome' ,funcionario.cpf as 'Cpf',funcionario.sexo as 'Sexo' ,funcionario.data_cadastro as 'Data Cadastro',instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao',contato_funcionario.telefone as 'Telefone',contato_funcionario.celular as 'Celular',contato_funcionario.email as 'E-mail',endereco_funcionario.cep as 'Cep', endereco_funcionario.logradouro as 'Logradouro' , endereco_funcionario.numero as 'N' , endereco_funcionario.bairro as 'Bairro' , endereco_funcionario.cidade as 'Cidade'  from usuario left join funcionario on funcionario.rm_usuario_funcionario = usuario.rm_usuario  left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_funcionario on contato_funcionario.rm_usuario_contato = usuario.rm_usuario left join endereco_funcionario on endereco_funcionario.rm_usuario_endereco = usuario.rm_usuario where nome = '" + funcionario.pesquisa_neutra + "' or sobrenome = '" + funcionario.pesquisa_neutra + "' or sexo = '" + funcionario.pesquisa_neutra + "'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_elaborada_Funcionario(Funcionario funcionario)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Funcionario',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status',funcionario.nome as 'Nome' ,funcionario.sobrenome as 'Sobrenome' ,funcionario.cpf as 'Cpf',funcionario.sexo as 'Sexo' ,funcionario.data_cadastro as 'Data Cadastro',instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao',contato_funcionario.telefone as 'Telefone',contato_funcionario.celular as 'Celular',contato_funcionario.email as 'E-mail',endereco_funcionario.cep as 'Cep', endereco_funcionario.logradouro as 'Logradouro' , endereco_funcionario.numero as 'N' , endereco_funcionario.bairro as 'Bairro' , endereco_funcionario.cidade as 'Cidade'  from usuario left join funcionario on funcionario.rm_usuario_funcionario = usuario.rm_usuario  left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_funcionario on contato_funcionario.rm_usuario_contato = usuario.rm_usuario left join endereco_funcionario on endereco_funcionario.rm_usuario_endereco = usuario.rm_usuario where rm_funcionario= '" + funcionario.pesquisa_rm_Funcionario + "' or cpf = '" + funcionario.pesquisa_rm_Funcionario + "' or nome = '" + funcionario.pesquisa_neutra + "' or sobrenome = '" + funcionario.pesquisa_neutra + "' or sexo = '" + funcionario.pesquisa_neutra + "' or status_usuario = '" + funcionario.pesquisa_neutra + "'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }


        // FIM FUNCIONARIO


        // ALUNO - CADASTRO, ALTERAÇÃO, EXCLUSÃO
        public static bool verificar_rm_aluno(Aluno aluno)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select rm_aluno from aluno where rm_aluno = '" + aluno.rm_aluno + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;

        }

       /* public static bool verificar_cpf_aluno(Aluno aluno)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select cpf from aluno where cpf = '" + aluno.cpf + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;

        }*/

        public static void cad_aluno(Aluno aluno)
        {
            if (verificar_rm_aluno(aluno))
            {
                MessageBox.Show("Rm já cadastrado ");
                return;
            }
           /* if (verificar_cpf_aluno(aluno))
            {
                MessageBox.Show("Cpf já cadastrado");
                return;
            }*/
            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand(); // cadastramento na tabela usuario
                cmd.CommandText = "insert into usuario(rm_usuario,senha,nivel_acesso,status_usuario) " +
                    "values (@rm_usuario,@senha,@nivel_acesso,@status_usuario)";

                cmd.Parameters.AddWithValue("@rm_usuario", aluno.rm_usuario);
                cmd.Parameters.AddWithValue("@senha", aluno.senha);
                cmd.Parameters.AddWithValue("@nivel_acesso", aluno.nivel_acesso);
                cmd.Parameters.AddWithValue("@status_usuario", aluno.status_usuario);
                cmd.ExecuteNonQuery();

                // cadastramento na tabela aluno
                cmd.CommandText = "insert into aluno (rm_aluno,nome,sobrenome,cpf,sexo,data_cadastro,rm_usuario_aluno) " +
                    "values (@rm_aluno,@nome,@sobrenome,@cpf,@sexo,@data_cadastro,@rm_usuario_aluno)";

                cmd.Parameters.AddWithValue("@rm_aluno", aluno.rm_aluno);
                cmd.Parameters.AddWithValue("@nome", aluno.nome);
                cmd.Parameters.AddWithValue("@sobrenome", aluno.sobrenome);
                cmd.Parameters.AddWithValue("@cpf", aluno.cpf);
                cmd.Parameters.AddWithValue("@sexo", aluno.sexo);
                cmd.Parameters.AddWithValue("@data_cadastro", aluno.data_cadastro);
                cmd.Parameters.AddWithValue("@rm_usuario_aluno", aluno.rm_usuario_aluno); // fk tabela aluno
                cmd.ExecuteNonQuery();

                // cadastramento na tabela endereco_aluno
                cmd.CommandText = "insert into endereco_aluno(cep,logradouro,numero,bairro,cidade,complemento,rm_aluno_endereco,rm_usuario_endereco) " +
                    "values (@cep,@logradouro,@numero,@bairro,@cidade,@complemento,@rm_aluno_endereco,@rm_usuario_endereco)";

                cmd.Parameters.AddWithValue("@cep", aluno.cep);
                cmd.Parameters.AddWithValue("@logradouro", aluno.logradouro);
                cmd.Parameters.AddWithValue("@numero", aluno.numero);
                cmd.Parameters.AddWithValue("@bairro", aluno.bairro);
                cmd.Parameters.AddWithValue("@cidade", aluno.cidade);
                cmd.Parameters.AddWithValue("@complemento", aluno.complemento);
                cmd.Parameters.AddWithValue("@rm_aluno_endereco", aluno.rm_aluno_endereco);
                cmd.Parameters.AddWithValue("@rm_usuario_endereco", aluno.rm_usuario_endereco);
                cmd.ExecuteNonQuery();

                // cadastramento na tabela contato_aluno
                cmd.CommandText = "insert into contato_aluno (telefone,celular,email,rm_aluno_contato,rm_usuario_contato) " +
                   "values (@telefone,@celular,@email,@rm_aluno_contato,@rm_usuario_contato)";

                cmd.Parameters.AddWithValue("@telefone", aluno.telefone);
                cmd.Parameters.AddWithValue("@celular", aluno.celular);
                cmd.Parameters.AddWithValue("@email", aluno.email);
                cmd.Parameters.AddWithValue("@rm_aluno_contato", aluno.rm_aluno_contato);
                cmd.Parameters.AddWithValue("@rm_usuario_contato", aluno.rm_usuario_contato);
                cmd.ExecuteNonQuery();

                // cadastramento na tabela instituicao_usuario
                cmd.CommandText = "insert into instituicao_usuario (rm_usuario_instituicao,cod_instituicao) " +
                    "values (@rm_usuario_instituicao,@cod_instituicao)";
          
                cmd.Parameters.AddWithValue("@rm_usuario_instituicao", aluno.rm_usuario_instituicao);
                cmd.Parameters.AddWithValue("@cod_instituicao", aluno.cod_instituicao);
                cmd.ExecuteNonQuery();

                // cadastramento na tabela curso_usuario
                cmd.CommandText = "insert into curso_usuario (usuario_id_usuario,curso_id_curso) " +
                    "values (@usuario_id_usuario,@curso_id_curso) ";

                cmd.Parameters.AddWithValue("@usuario_id_usuario", aluno.usuario_id_usuario);
                cmd.Parameters.AddWithValue("@curso_id_curso", aluno.curso_id_curso);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Aluno(a) "+aluno.nome + " inserido(a) com sucesso !");
                conBCO.Close();           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }

        public static void alterar_Aluno(Aluno aluno)
        {
            if (verificacao_de_certeza_aluno(aluno) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = "update usuario left join aluno on aluno.rm_usuario_aluno = rm_usuario left join endereco_aluno on endereco_aluno.rm_usuario_endereco = rm_usuario left join contato_aluno on contato_aluno.rm_usuario_contato = rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = rm_usuario set  usuario.senha = '" + aluno.senha + "' ,usuario.status_usuario = '" + aluno.status_usuario + "' ,aluno.nome = '" + aluno.nome + "', aluno.sobrenome = '" + aluno.sobrenome + "',aluno.sexo = '" + aluno.sexo + "' ,aluno.data_cadastro = '" + aluno.data_cadastro + "' ,aluno.cpf = '" + aluno.cpf + "',endereco_aluno.cep = '" + aluno.cep + "',endereco_aluno.logradouro = '" + aluno.logradouro + "' ,endereco_aluno.numero = '" + aluno.numero + "',endereco_aluno.bairro = '" + aluno.bairro + "',endereco_aluno.cidade = '" + aluno.cidade + "',endereco_aluno.complemento = '" + aluno.complemento + "',contato_aluno.telefone = '" + aluno.telefone + "' ,contato_aluno.celular = '" + aluno.celular + "',contato_aluno.email = '" + aluno.email + "',instituicao_usuario.cod_instituicao = '" + aluno.cod_instituicao + "' , curso_usuario.curso_id_curso = '" + aluno.curso_id_curso + "' where  rm_usuario = '" + aluno.rm_usuario + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aluno Alterado com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static bool verificacao_de_certeza_aluno(Aluno aluno) // verificação para exclusão
        {
            bool resposta; // resposta
                           //  MySqlDataAdapter da = null;
                           //   DataTable dt = new DataTable();
            try
            {

                if (MessageBox.Show("Você tem certeza ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }


        }

        public static void excluir_aluno(Aluno aluno)
        {
            if (verificacao_de_certeza_aluno(aluno) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete aluno.*, endereco_aluno.*, contato_aluno.*, usuario.*, curso_usuario.*, instituicao_usuario.*  from aluno, endereco_aluno, contato_aluno, usuario, curso_usuario, instituicao_usuario  where aluno.rm_aluno = '" + aluno.rm_usuario+ "'  and endereco_aluno.rm_aluno_endereco = '" + aluno.rm_usuario + "' and  contato_aluno.rm_aluno_contato = '" + aluno.rm_usuario + "' and usuario.rm_usuario = '" + aluno.rm_usuario + "' and curso_usuario.usuario_id_usuario = '" + aluno.rm_usuario + "' and instituicao_usuario.rm_usuario_instituicao = '" + aluno.rm_usuario + "'  ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aluno excluído com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static DataTable mostrarAluno()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Aluno',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', aluno.nome as 'Nome',aluno.sobrenome as 'Sobrenome' ,aluno.cpf as 'Cpf',aluno.sexo as 'Sexo',aluno.data_cadastro as 'Data de Cadastro',curso_usuario.curso_id_curso as 'Cod Curso',instituicao_usuario.cod_instituicao as 'Cod Etec',contato_aluno.telefone as 'Telefone',contato_aluno.celular as 'Celular',contato_aluno.email as 'E-mail',endereco_aluno.cep as 'Cep', endereco_aluno.logradouro as 'Logradouro', endereco_aluno.numero as 'N' , endereco_aluno.bairro as 'Bairro' , endereco_aluno.cidade as 'Cidade' from usuario left join aluno on aluno.rm_usuario_aluno = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_aluno on contato_aluno.rm_usuario_contato = usuario.rm_usuario left join endereco_aluno on endereco_aluno.rm_usuario_endereco = usuario.rm_usuario where nivel_acesso = 'ALUNO' ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);            
                conBCO.Clone();
                return dt;
                // select id_autor as 'id', nome_autor as 'Nome', nacionalidade as 'Nacionalidade' from autor; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }

        }

        public static DataTable pesquisa_Aluno( Aluno aluno)
        {      

            try
            {
                MySqlDataAdapter da = null; 
                DataTable dt = new DataTable();
                
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Aluno',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', aluno.nome as 'Nome',aluno.sobrenome as 'Sobrenome' ,aluno.cpf as 'Cpf',aluno.sexo as 'Sexo',aluno.data_cadastro as 'Data de Cadastro',curso_usuario.curso_id_curso as 'Cod Curso',instituicao_usuario.cod_instituicao as 'Cod Etec',contato_aluno.telefone as 'Telefone',contato_aluno.celular as 'Celular',contato_aluno.email as 'E-mail',endereco_aluno.cep as 'Cep', endereco_aluno.logradouro as 'Logradouro', endereco_aluno.numero as 'N' , endereco_aluno.bairro as 'Bairro' , endereco_aluno.cidade as 'Cidade' from usuario left join aluno on aluno.rm_usuario_aluno = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_aluno on contato_aluno.rm_usuario_contato = usuario.rm_usuario left join endereco_aluno on endereco_aluno.rm_usuario_endereco = usuario.rm_usuario where rm_aluno= '" + aluno.pesquisa_rm_Aluno+ "' or cpf = '" + aluno.pesquisa_rm_Aluno + "'  or cep = '"+aluno.pesquisa_rm_Aluno+"'";        
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());           
                da.Fill(dt);               
                conBCO.Clone();
                return dt;                         
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }

        public static DataTable pesquisa_neutra_Aluno(Aluno aluno)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Aluno',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', aluno.nome as 'Nome',aluno.sobrenome as 'Sobrenome' ,aluno.cpf as 'Cpf',aluno.sexo as 'Sexo',aluno.data_cadastro as 'Data de Cadastro',curso_usuario.curso_id_curso as 'Cod Curso',instituicao_usuario.cod_instituicao as 'Cod Etec',contato_aluno.telefone as 'Telefone',contato_aluno.celular as 'Celular',contato_aluno.email as 'E-mail',endereco_aluno.cep as 'Cep', endereco_aluno.logradouro as 'Logradouro', endereco_aluno.numero as 'N' , endereco_aluno.bairro as 'Bairro' , endereco_aluno.cidade as 'Cidade' from usuario left join aluno on aluno.rm_usuario_aluno = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_aluno on contato_aluno.rm_usuario_contato = usuario.rm_usuario left join endereco_aluno on endereco_aluno.rm_usuario_endereco = usuario.rm_usuario where nome = '" + aluno.pesquisa_neutra+"' or sobrenome = '"+aluno.pesquisa_neutra+"' or sexo = '"+aluno.pesquisa_neutra+"' ";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_elaborada_Aluno(Aluno aluno)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Aluno',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', aluno.nome as 'Nome',aluno.sobrenome as 'Sobrenome' ,aluno.cpf as 'Cpf',aluno.sexo as 'Sexo',aluno.data_cadastro as 'Data de Cadastro',curso_usuario.curso_id_curso as 'Cod Curso',instituicao_usuario.cod_instituicao as 'Cod Etec',contato_aluno.telefone as 'Telefone',contato_aluno.celular as 'Celular',contato_aluno.email as 'E-mail',endereco_aluno.cep as 'Cep', endereco_aluno.logradouro as 'Logradouro', endereco_aluno.numero as 'N' , endereco_aluno.bairro as 'Bairro' , endereco_aluno.cidade as 'Cidade' from usuario left join aluno on aluno.rm_usuario_aluno = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_aluno on contato_aluno.rm_usuario_contato = usuario.rm_usuario left join endereco_aluno on endereco_aluno.rm_usuario_endereco = usuario.rm_usuario where rm_aluno= '" + aluno.pesquisa_rm_Aluno + "' or cpf = '"+aluno.pesquisa_rm_Aluno+"' or nome = '" + aluno.pesquisa_neutra + "' or sobrenome = '" + aluno.pesquisa_neutra + "' or sexo = '"+aluno.pesquisa_neutra+"' or status_usuario = '"+aluno.pesquisa_neutra+"'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        // FIM ALUNO


        // PROFESSOR - CADASTRO, ALTERAÇÃO, EXCLUSÃO
        public static bool verificar_rm_professor(Professor professor)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select rm_professor from professor where rm_professor = '" + professor.rm_professor + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;

        }

        public static bool verificar_cpf_professor(Professor professor)
        {

            bool resposta; // resposta
            MySqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var conBCO = conexaoBCO();
            var cmd = conBCO.CreateCommand();
            cmd.CommandText = " select cpf from professor where cpf = '" + professor.cpf + "' ";
            da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }
            return resposta;

        }

        public static void cad_professor(Professor professor)
        {
            if (verificar_rm_professor(professor))
            {
                MessageBox.Show("Rm já cadastrado");
                return;
            }
            if (verificar_cpf_professor(professor))
            {
                MessageBox.Show("Cpf já cadastrado");
                return;
            }

            try
            {
                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "insert into usuario(rm_usuario,senha,nivel_acesso,status_usuario) " +
                   "values (@rm_usuario,@senha,@nivel_acesso,@status_usuario)";

                cmd.Parameters.AddWithValue("@rm_usuario", professor.rm_usuario);
                cmd.Parameters.AddWithValue("@senha", professor.senha);
                cmd.Parameters.AddWithValue("@nivel_acesso", professor.nivel_acesso);
                cmd.Parameters.AddWithValue("@status_usuario", professor.status_usuario);
                cmd.ExecuteNonQuery();



                cmd.CommandText = "insert into professor (rm_professor,nome,sobrenome,cpf,sexo,data_cadastro,sede,rm_usuario_professor) " +
                    "values (@rm_professor,@nome,@sobrenome,@cpf,@sexo,@data_cadastro,@sede,@rm_usuario_professor)";

                cmd.Parameters.AddWithValue("@rm_professor", professor.rm_professor);
                cmd.Parameters.AddWithValue("@nome", professor.nome);
                cmd.Parameters.AddWithValue("@sobrenome", professor.sobrenome);
                cmd.Parameters.AddWithValue("@cpf", professor.cpf);
                cmd.Parameters.AddWithValue("@sexo", professor.sexo);
                cmd.Parameters.AddWithValue("@data_cadastro", professor.data_cadastro);
                cmd.Parameters.AddWithValue("@sede", professor.sede);
                cmd.Parameters.AddWithValue("@rm_usuario_professor", professor.rm_usuario_professor);
                cmd.ExecuteNonQuery();

                // tabela endereco_professor
                cmd.CommandText = "insert into endereco_professor(cep,logradouro,numero,bairro,cidade,complemento,rm_professor_endereco,rm_usuario_endereco) " +
                    "values (@cep,@logradouro,@numero,@bairro,@cidade,@complemento,@rm_professor_endereco,@rm_usuario_endereco)";

                cmd.Parameters.AddWithValue("@cep", professor.cep);
                cmd.Parameters.AddWithValue("@logradouro", professor.logradouro);
                cmd.Parameters.AddWithValue("@numero", professor.numero);
                cmd.Parameters.AddWithValue("@bairro", professor.bairro);
                cmd.Parameters.AddWithValue("@cidade", professor.cidade);
                cmd.Parameters.AddWithValue("@complemento", professor.complemento);
                cmd.Parameters.AddWithValue("@rm_professor_endereco", professor.rm_professor_endereco);
                cmd.Parameters.AddWithValue("@rm_usuario_endereco", professor.rm_usuario_endereco);
                cmd.ExecuteNonQuery();
                // fim endereco_professor      

                // tabela contato_professor
                cmd.CommandText = "insert into contato_professor (telefone,celular,email,rm_professor_contato,rm_usuario_contato)" +
                    " values (@telefone,@celular,@email,@rm_professor_contato,@rm_usuario_contato) ";

                cmd.Parameters.AddWithValue("@telefone", professor.telefone);
                cmd.Parameters.AddWithValue("@celular", professor.celular);
                cmd.Parameters.AddWithValue("@email", professor.email);
                cmd.Parameters.AddWithValue("@rm_professor_contato", professor.rm_professor_contato);
                cmd.Parameters.AddWithValue("@rm_usuario_contato", professor.rm_usuario_contato);
                cmd.ExecuteNonQuery();
                //fim contato_professor

                // cadastramento na tabela instituicao_usuario
                cmd.CommandText = "insert into instituicao_usuario (situacao,rm_usuario_instituicao,cod_instituicao) " +
                    "values (@situacao,@rm_usuario_instituicao,@cod_instituicao)";
         
                cmd.Parameters.AddWithValue("@situacao", professor.situacao);
                cmd.Parameters.AddWithValue("@rm_usuario_instituicao", professor.rm_usuario_instituicao);
                cmd.Parameters.AddWithValue("@cod_instituicao", professor.cod_instituicao);
                cmd.ExecuteNonQuery();
                // fim instituicao_usuario

                // cadastramento na tabela curso_usuario
                cmd.CommandText = "insert into curso_usuario (situacao_curso,usuario_id_usuario,curso_id_curso) " +
                    "values (@situacao_curso,@usuario_id_usuario,@curso_id_curso) ";

                cmd.Parameters.AddWithValue("@situacao_curso", professor.situacao_curso);
                cmd.Parameters.AddWithValue("@usuario_id_usuario", professor.usuario_id_usuario);
                cmd.Parameters.AddWithValue("@curso_id_curso", professor.curso_id_curso);
                cmd.ExecuteNonQuery();
                // fim curso_usuario

                MessageBox.Show("Professor inserido com sucesso ! - nome: "+professor.nome+" rm: "+professor.rm_usuario);
                conBCO.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void alterar_Professor(Professor professor)
        {
            if (verificacao_de_certeza_professor(professor) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = "update usuario left join professor on professor.rm_usuario_professor = rm_usuario left join endereco_professor on endereco_professor.rm_usuario_endereco = rm_usuario left join contato_professor on contato_professor.rm_usuario_contato = rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = rm_usuario set usuario.senha = '" + professor.senha + "', usuario.status_usuario = '" + professor.status_usuario + "',usuario.nivel_acesso = '" + professor.nivel_acesso + "',professor.nome = '" + professor.nome + "',professor.sobrenome = '" + professor.sobrenome + "' ,professor.cpf = '" + professor.cpf + "',professor.sexo = '" + professor.sexo + "',professor.data_cadastro = '" + professor.data_cadastro + "' ,professor.sede = '" + professor.sede + "',endereco_professor.cep = '" + professor.cep + "',endereco_professor.logradouro = '" + professor.logradouro + "',endereco_professor.numero = '" + professor.numero + "',endereco_professor.bairro = '" + professor.bairro + "',endereco_professor.cidade = '" + professor.cidade + "',endereco_professor.complemento = '" + professor.complemento + "',contato_professor.telefone = '" + professor.telefone + "',contato_professor.celular = '" + professor.celular + "',contato_professor.email = '" + professor.email + "',instituicao_usuario.cod_instituicao = '" + professor.cod_instituicao + "',instituicao_usuario.situacao = '" + professor.situacao + "' ,curso_usuario.situacao_curso = '" + professor.situacao_curso + "',curso_usuario.curso_id_curso = '" + professor.curso_id_curso + "' where rm_usuario = '" + professor.rm_usuario + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor Alterado com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }
            }
        }

        public static bool verificacao_de_certeza_professor(Professor professor) // verificação para exclusão
        {
            bool resposta; // resposta
                           //  MySqlDataAdapter da = null;
                           //   DataTable dt = new DataTable();
            try
            {

                if (MessageBox.Show("Você tem certeza ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    resposta = true;
                    //  return resposta;
                }
                else
                {
                    resposta = false;
                    // return resposta;
                }
                return resposta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
                // MessageBox.Show("Entrar em contato com equipe de suporte");
            }
        }

        public static void excluir_professor(Professor professor)
        {
            if (verificacao_de_certeza_professor(professor) == true)
            {
                try
                {
                    var conBCO = conexaoBCO();
                    var cmd = conBCO.CreateCommand();
                    cmd.CommandText = cmd.CommandText = " delete professor.*, endereco_professor.*, contato_professor.*, usuario.*, curso_usuario.*, instituicao_usuario.* from professor, endereco_professor, contato_professor, usuario, curso_usuario, instituicao_usuario where professor.rm_professor = '" + professor.rm_usuario + "' and  endereco_professor.rm_professor_endereco =  '" + professor.rm_usuario + "' and contato_professor.rm_professor_contato = '" + professor.rm_usuario + "' and usuario.rm_usuario = '" + professor.rm_usuario + "' and  curso_usuario.usuario_id_usuario = '" + professor.rm_usuario + "'  and  instituicao_usuario.rm_usuario_instituicao = '" + professor.rm_usuario + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor excluído com sucesso! ");
                    conBCO.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                    // MessageBox.Show("Entrar em contato com equipe de suporte");
                }

            }
        }

        public static DataTable mostrar_professor()
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Professor',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', professor.nome as 'Nome' ,professor.sobrenome as 'Sobrenome' ,professor.cpf as 'Cpf',professor.sexo as 'Sexo',professor.data_cadastro as 'Data Cadastro',professor.sede as 'Sede', curso_usuario.curso_id_curso as 'Id do Curso',curso_usuario.situacao_curso as ' Curso', instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao', contato_professor.telefone as 'Telefone',contato_professor.celular as 'Celular',contato_professor.email as '', endereco_professor.cep as 'Cep', endereco_professor.logradouro as 'Logradouro' , endereco_professor.numero as 'N' , endereco_professor.bairro as 'Bairro', endereco_professor.cidade as 'Cidade' from usuario left join professor on professor.rm_usuario_professor = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_professor on contato_professor.rm_usuario_contato = usuario.rm_usuario left join endereco_professor on endereco_professor.rm_usuario_endereco = usuario.rm_usuario where nivel_acesso = 'ADMIN' or nivel_acesso = 'PROFESSOR'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }


        }

        public static DataTable pesquisar_Professor(Professor professor)
        {

            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Professor',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', professor.nome as 'Nome' ,professor.sobrenome as 'Sobrenome' ,professor.cpf as 'Cpf',professor.sexo as 'Sexo',professor.data_cadastro as 'Data Cadastro',professor.sede as 'Sede', curso_usuario.curso_id_curso as 'Id do Curso',curso_usuario.situacao_curso as ' Curso', instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao', contato_professor.telefone as 'Telefone',contato_professor.celular as 'Celular',contato_professor.email as '', endereco_professor.cep as 'Cep', endereco_professor.logradouro as 'Logradouro' , endereco_professor.numero as 'N' , endereco_professor.bairro as 'Bairro', endereco_professor.cidade as 'Cidade' from usuario left join professor on professor.rm_usuario_professor = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_professor on contato_professor.rm_usuario_contato = usuario.rm_usuario left join endereco_professor on endereco_professor.rm_usuario_endereco = usuario.rm_usuario where rm_professor = '" + professor.pesquisa_rm_Professor+ "' or cpf = '" + professor.pesquisa_rm_Professor + "'  or cep = '" + professor.pesquisa_rm_Professor + "'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_neutra_Professor(Professor professor)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Professor',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', professor.nome as 'Nome' ,professor.sobrenome as 'Sobrenome' ,professor.cpf as 'Cpf',professor.sexo as 'Sexo',professor.data_cadastro as 'Data Cadastro',professor.sede as 'Sede', curso_usuario.curso_id_curso as 'Id do Curso',curso_usuario.situacao_curso as ' Curso', instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao', contato_professor.telefone as 'Telefone',contato_professor.celular as 'Celular',contato_professor.email as '', endereco_professor.cep as 'Cep', endereco_professor.logradouro as 'Logradouro' , endereco_professor.numero as 'N' , endereco_professor.bairro as 'Bairro', endereco_professor.cidade as 'Cidade' from usuario left join professor on professor.rm_usuario_professor = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_professor on contato_professor.rm_usuario_contato = usuario.rm_usuario left join endereco_professor on endereco_professor.rm_usuario_endereco = usuario.rm_usuario where nome = '" + professor.pesquisa_neutra + "' or sobrenome = '" + professor.pesquisa_neutra + "' or sexo = '" + professor.pesquisa_neutra + "'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable pesquisa_elaborada_Professor(Professor professor)
        {
            try
            {
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();

                var conBCO = conexaoBCO();
                var cmd = conBCO.CreateCommand();
                cmd.CommandText = "select usuario.rm_usuario as 'Rm Professor',usuario.nivel_acesso as 'Acesso',usuario.status_usuario as 'Status', professor.nome as 'Nome' ,professor.sobrenome as 'Sobrenome' ,professor.cpf as 'Cpf',professor.sexo as 'Sexo',professor.data_cadastro as 'Data Cadastro',professor.sede as 'Sede', curso_usuario.curso_id_curso as 'Id do Curso',curso_usuario.situacao_curso as ' Curso', instituicao_usuario.cod_instituicao as 'Cod Etec', instituicao_usuario.situacao as 'Situacao', contato_professor.telefone as 'Telefone',contato_professor.celular as 'Celular',contato_professor.email as '', endereco_professor.cep as 'Cep', endereco_professor.logradouro as 'Logradouro' , endereco_professor.numero as 'N' , endereco_professor.bairro as 'Bairro', endereco_professor.cidade as 'Cidade' from usuario left join professor on professor.rm_usuario_professor = usuario.rm_usuario left join curso_usuario on curso_usuario.usuario_id_usuario = usuario.rm_usuario left join instituicao_usuario on instituicao_usuario.rm_usuario_instituicao = usuario.rm_usuario left join contato_professor on contato_professor.rm_usuario_contato = usuario.rm_usuario left join endereco_professor on endereco_professor.rm_usuario_endereco = usuario.rm_usuario where rm_professor = '" + professor.pesquisa_rm_Professor + "' or cpf = '" + professor.pesquisa_rm_Professor + "' or nome = '" + professor.pesquisa_neutra + "' or sobrenome = '" + professor.pesquisa_neutra + "' or sexo = '" + professor.pesquisa_neutra + "' or status_usuario = '" + professor.pesquisa_neutra + "'";
                da = new MySqlDataAdapter(cmd.CommandText, conexaoBCO());
                da.Fill(dt);
                conBCO.Clone();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        
        // FIM PROFESSOR 

    }
}
