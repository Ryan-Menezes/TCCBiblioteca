using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    class Livro
    {
        //public Int32 cod_livro; auto increment
        public Int32 tombo; 
        public string titulo;
        public string ano_publicacao; 
        public Int32 volume; 
        public Int32 edicao;                         
        public string insercao; 
        public string isbn; 
        public string idioma;
        // public string img_livro; 
        // public string pdf_livro; 
        public Int32 editora_id_editora;
        public Int32 genero_id_genero;
        public Int32 autor_id_autor;
        public string nome_colaboradores;
        public Int32 colaborador_id_colaborador;


        // GENERO //
        public string nome_genero;
        // FIM GENERO//


        //AUTOR//
        public string nome_autor;
        public string nacionalidade_autor;
        //public string colaborador;
        //FIM AUTOR//

        // EDITORA//
       // public string id_editora;
        public string nome_editora;
        public string cnpj;
        //FIM EDITORA//

        //EXEMPLARES 
        public Int32 quantidade;
        public Int32 livro_tombo_exemplares;
        public Int32 id_instituicao;
        // FIM EXEMPLARES

        public Int64 pesquisa_tombo;
        public string pesquisa_neutra;
    }
}
