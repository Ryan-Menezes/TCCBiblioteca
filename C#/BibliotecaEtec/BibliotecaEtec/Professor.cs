using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    class Professor : Usuario
    {
        public string rm_professor;
        public string nome;
        public string sobrenome;
        public string cpf;
        public string sexo;
        public byte[] imgProfessor;
        public string sede;

        public string cep;
        public string logradouro;
        public string numero;
        public string bairro;
        public string cidade;
        public string complemento;

        public string telefone;
        public string celular;
        public string email;

        public List<string> instituicoes;
        public List<string> situacoes;
    }
}
