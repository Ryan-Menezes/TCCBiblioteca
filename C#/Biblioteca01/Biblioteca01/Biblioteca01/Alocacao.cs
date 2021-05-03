using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    class Alocacao
    {
        public Int32 id_locacao;
        public string data_locacao;
        public string data_devolucao;
        // public Int32 id_exemplares; auto increment
        public Int32 tombo_exemplares;
        public Int32 rm_usuario;//rm_usuario_locacao
        public Int32 rm_admin;//rm_usuarioAdimin_locacao
        public string situacao;
        // public string senha;

        //public string pesquisar_situacao;
        public string pesquisar_letra;
        public Int64 pesquisar_num;

    }
}
