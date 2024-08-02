using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    public static class Lista
    {
        public class Produto
        {
            public string nome { get; set;}

            public double quantidade { get; set;}
        }
        

        public static string AdicionarProduto(Produto produto)
        {
            var produto1 = new Lista.Produto { nome = "Salgado", quantidade = 3 };
            List<Produto> lista = new List<Produto>();
            lista.Add(produto1);

            var produtoExistente = lista.FirstOrDefault(p => p.nome == produto.nome);
            if (produtoExistente != null)
            {
                produtoExistente.quantidade += 1;
                return "Quantidade aumentada";
            }
            else
            {
                lista.Add(produto);
                return "Produto Cadastrado";
            }


        }
        
    }
}
