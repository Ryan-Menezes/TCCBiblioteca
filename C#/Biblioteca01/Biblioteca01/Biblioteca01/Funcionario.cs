using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    class Funcionario:Usuario
    {
        public Int32 rm_funcionario; // primaria
        public string cpf; // unique
        public string nome;
        public string sobrenome ;
        public string sexo;
        public string data_cadastro;
        public Int32 rm_usuario_funcionario;
        //public string img_funcionario;

        public string cep;
        public string logradouro;
        public string numero;
        public string bairro;
        public string cidade;
        public string complemento;
        public Int32 rm_funcionario_endereco; // talvez esteja errado chave estrageira deve ser int 

        public string telefone;
        public string celular;
        public string email;
        public Int32 rm_funcionario_contato; // talvez esteja errado chave estrageira deve ser int 

        public Int64 pesquisa_rm_Funcionario;
        public object pesquisa_neutra;
    }
}
