using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca01
{
    static class Globais
    {
        public static bool logado = false;
        public static string url = string.Empty;
        public static TelaPrincipal tela = new TelaPrincipal();
       
        public static string caminho = System.Environment.CurrentDirectory; // pegando o executavel do programa
       // public static string nome_Banco = "bdbibliotecaetec";
       // public static string caminho_Banco = "";
    }
}
