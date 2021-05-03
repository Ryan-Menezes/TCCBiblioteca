using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    public abstract class Usuario
    {
        public Int32 rm_usuario;
        public string senha;
        public string nivel_acesso;
        public string status_usuario;

        // INSTITUIÇÃO
        // public Int32 cod_instituicao_usuario; - pk auto_increment
        public string situacao;
        public Int32 rm_usuario_instituicao;
        public Int32 cod_instituicao;

        // CURSO
        //id_curso_usuario; - pk auto_increment;
        public string situacao_curso;
        public Int32 usuario_id_usuario;
        public Int32 curso_id_curso;

        //ENDEREÇO
        public Int32 rm_usuario_endereco;

        // CONTATO
        public Int32 rm_usuario_contato;
    }
}
