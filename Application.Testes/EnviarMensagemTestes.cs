using Function;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.Testes
{
    [TestFixture]
    public class EnviarMensagemTestes
    {
        private EnviarMensagem _enviarMensagem;

        [SetUp]
        public void SetUp()
        {
            _enviarMensagem = new EnviarMensagem();
        }

        [Test]
        public void TestNaoSeiAinda()
        {
            Task.WhenAll(_enviarMensagem.ConfigurarMensagemASerEnviada());
        }
    }
}
