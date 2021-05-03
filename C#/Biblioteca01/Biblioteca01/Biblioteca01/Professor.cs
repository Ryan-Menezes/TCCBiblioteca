using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    class Professor:Usuario
    {
        public Int32 rm_professor;
        public string nome;
        public string sobrenome;
        public string cpf;
        public string sexo;
        public string data_cadastro;
        //img_professor
        public Int32 sede;
        public Int32 rm_usuario_professor;

        public string cep;
        public string logradouro;
        public string numero;
        public string bairro;
        public string cidade;
        public string complemento;
        public Int32 rm_professor_endereco;

        public string telefone;
        public string celular;
        public string email;
        public Int32 rm_professor_contato;

        public Int64 pesquisa_rm_Professor;
        public object pesquisa_neutra;
    }
}
