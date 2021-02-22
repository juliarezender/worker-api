using Application.Service;
using AutoFixture;
using Azure.Storage.Queues;
using Domain.Modelos;
using Moq;
using NUnit.Framework;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Testes
{
    [TestFixture]
    public class AzureQueueTestes
    {
        private AzureQueue _azureQueue;
        private Mock<IAzureQueueFactory> _azureQueueFactory;
        private Mock<QueueClient> _queue;

        [SetUp]
        public void Setup()
        {
            _azureQueueFactory = new Mock<IAzureQueueFactory>();
            _queue = new Mock<QueueClient>("UseDevelopmentStorage=true", "testequeue");
            _azureQueue = new AzureQueue(_azureQueueFactory.Object);
        }

        [Test]
        public async Task TesteChamadaDoMetodoSendMessageAsyncQuandoCriaNovoColaborador()
        {
            var colaborador = new Colaborador
            {
                Id = 1,
                Nome = "Teste",
                Telefone = "99999999",
                Email = "teste@email.com"
            };
            var colaboradorSerializado = JsonSerializer.Serialize(colaborador);
            _azureQueueFactory.Setup(mock => mock.ObterQueue()).Returns(_queue.Object);

            await _azureQueue.ReceberDados(colaborador);

            _queue.Verify(mock => mock.SendMessageAsync(colaboradorSerializado), Times.Once);
        }

        [Test]
        public async Task TesteChamadaDoMetodoCreateIfNotExistsAsyncQuandoQueueEstiverNullAsync()
        {
            var colaborador = new Colaborador
            {
                Id = 1,
                Nome = "Teste",
                Telefone = "99999999",
                Email = "teste@email.com"
            };
            var colaboradorSerializado = JsonSerializer.Serialize(colaborador);
            _azureQueueFactory.Setup(mock => mock.ObterQueue()).Returns(_queue.Object);

            await _azureQueue.ReceberDados(colaborador);

            _queue.Verify(mock => mock.CreateIfNotExistsAsync(null, default), Times.Once);
        }
    }
}
