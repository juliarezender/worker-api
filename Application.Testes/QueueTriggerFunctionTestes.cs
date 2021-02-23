using Function;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.Testes
{
    [TestFixture]
    public class QueueTriggerFunctionTestes
    {
        private Mock<ILogger> _logger;
        private Mock<IEnviarMensagem> _enviarMensagem;
        private QueueTriggerFunction _queueTriggerFunction;

        [SetUp]
        public void SetUp()
        {
            _enviarMensagem = new Mock<IEnviarMensagem>();
            _queueTriggerFunction = new QueueTriggerFunction(_enviarMensagem.Object);
            _logger = new Mock<ILogger>();
        }


        [Test]
        public void TesteChamadaDoMetodoConfigurarMensagemASerEnviada()
        {
            _enviarMensagem.Setup(mock => mock.ConfigurarMensagemASerEnviada());

            _queueTriggerFunction.Run("TestQueueItem", _logger.Object);

            _enviarMensagem.Verify(mock => mock.ConfigurarMensagemASerEnviada());
        }
    }
}
