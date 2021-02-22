using Application.Service;
using Azure.Storage.Queues;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.Testes
{
    [TestFixture]
    public class AzureQueueFactoryTestes
    {
        private AzureQueueFactory azureQueueFactory;

        [SetUp]
        public void Setup()
        {
            azureQueueFactory = new AzureQueueFactory();
        }

        [Test]
        public void TesteRetornoDoMetodoObterQueue()
        {
            var retorno = azureQueueFactory.ObterQueue();

            Assert.AreEqual(retorno.GetType(), typeof(QueueClient));
        }
    }
}
