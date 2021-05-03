using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEtec
{
    public static class UsuarioLogado
    {
		public static string rm = string.Empty;
		public static string cpf = string.Empty;
		public static string nomeCompleto = string.Empty;
		public static string senha = string.Empty;
		public static Dictionary<string, string> instituicoes = new Dictionary<string, string>();
		public static string codUsuario = string.Empty;
    }
}
