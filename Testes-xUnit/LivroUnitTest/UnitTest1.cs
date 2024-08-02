using Livros;

namespace LivroUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Adicionar()
        {
            var titulo = "game of thrones";


            var add = Livro.AdicionarLivro(titulo);

            Assert.Equal(add, titulo);
        }

    }
    
    }

