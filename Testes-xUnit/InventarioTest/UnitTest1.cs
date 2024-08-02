using Inventario;

namespace InventarioTest
{
    public class UnitTest1
    {
        
        [Fact]
        public void ConferirInventario()
        {

            //Considerando que nao tem um produto cadastrado com esse nome
            var produto = new Lista.Produto { nome = "Coxinha", quantidade = 1 };

            var valorEsperado = "Produto Cadastrado";

           var valorObtido = Lista.AdicionarProduto(produto);

            Assert.Equal(valorObtido, valorEsperado);


            
        }

        [Fact]
        public void TestarAtualizacaoDeProdutoExistente()
        {
            //Considerando que tem um produto cadastrado com esse nome
            
            var produto2 = new Lista.Produto { nome = "Salgado", quantidade = 1 };

            
            var resultadoEsperado = "Quantidade aumentada";
            var resultado = Lista.AdicionarProduto(produto2);

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}