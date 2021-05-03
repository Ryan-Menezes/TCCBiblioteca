using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEtec
{
    static class Globais
    {
        public static bool logado = false;
        public static string url = "http://localhost/TCCBiblioteca/";
        public static TelaPrincipal tela = new TelaPrincipal();
        public static TelaLogin TelaLogin = new TelaLogin();
        public static string nomeApp = "Biblioteca";
        public static Bitmap logo = Properties.Resources.Logo;
    }
}
