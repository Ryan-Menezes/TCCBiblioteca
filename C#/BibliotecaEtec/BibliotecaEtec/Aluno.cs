using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    class Aluno : Usuario
    {

        public string rm_aluno; // int, chave primaria 
        public string nome;
        public string sobrenome;
        public string cpf;
        public string sexo;
        public byte[] imgAluno;

        public string cep;
        public string logradouro;
        public string numero;
        public string bairro;
        public string cidade;
        public string complemento;

        public string telefone;
        public string celular;
        public string email;

        public List<string> cursos;
    }
}
