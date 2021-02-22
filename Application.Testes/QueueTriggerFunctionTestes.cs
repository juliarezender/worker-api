using Function;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace Application.Testes
{
    [TestFixture]
    public class QueueTriggerFunctionTestes
    {
        private readonly ILogger logger;

        [Test]
        public void QueueTriggerTeste()
        {
            QueueTriggerFunction.Run("TestQueueItem", log: logger);
        }
    }
}
