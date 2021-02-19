using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Domain.Modelos;

namespace Application.Service
{
    public class AzureQueue : IAzureQueue
    {
        private readonly IAzureQueueFactory _azureQueueFactory;
        public AzureQueue(IAzureQueueFactory azureQueueFactory) 
        {
            _azureQueueFactory = azureQueueFactory;
        }

        public async Task ReceberDados(Colaborador colaborador)
        {
            var queue = _azureQueueFactory.ObterQueue();

            var colaboradorSerializado = JsonSerializer.Serialize(colaborador);

            await InserirMensagemNaQueue(queue, colaboradorSerializado);
        }

        static async Task InserirMensagemNaQueue(QueueClient queue, string colaborador)
        {
            await queue.CreateIfNotExistsAsync();

            await queue.SendMessageAsync(colaborador);
        }
    }
}
