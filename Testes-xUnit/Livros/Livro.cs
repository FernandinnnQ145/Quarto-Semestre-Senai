using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros
{
    public static class Livro
    {
        static List<string> livros = new List<string>();

        public static string AdicionarLivro(string titulo)
        {
            livros.Add(titulo);
            return titulo;
        }
    }
}


