using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    class Aluno:Usuario
    {
       
        public Int32 rm_aluno; // int, chave primaria 
        public string nome;
        public string sobrenome;
        public string cpf;
        public string sexo;
        public string data_cadastro;
        public Int32 rm_usuario_aluno;
        //public string imgAluno;

        public string cep;
        public string logradouro;
        public string numero; 
        public string bairro;
        public string cidade;
        public string complemento;
        public Int32 rm_aluno_endereco; // chave estrageira referencia tabela: aluno, atributo: rm
        

        public string telefone;
        public string celular;
        public string email;
        public Int32 rm_aluno_contato; // chave estrageira referencia tabela: aluno, atributo: rm

        public Int64 pesquisa_rm_Aluno;
        public object pesquisa_neutra;
        
    }
}
