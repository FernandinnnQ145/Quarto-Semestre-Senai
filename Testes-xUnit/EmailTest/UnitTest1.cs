using Email;

namespace EmailTest
{
    public class UnitTest1
    {
        [Fact]
        public void ConferirEmail()
        {
            string email = "teste@teste.com";

            Assert.True(Verificacao.ValidarEmail(email));
        }
    }
}