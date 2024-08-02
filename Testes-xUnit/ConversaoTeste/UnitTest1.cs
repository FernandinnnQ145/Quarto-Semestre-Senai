

using Conversao;

namespace ConversaoTeste
{
    public class UnitTest1
    {
        [Fact]
        public void ConferirCalculo()
        {
            double celcius = 31;
            var valorEsperado = 87.8;

            var valorObtido = Conversao.Conversao.ConverterCelsiusParaFahrenheit(celcius);

            Assert.Equal(valorObtido, valorEsperado);
        }
    }
}