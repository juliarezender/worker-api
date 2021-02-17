using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Domain.Modelos;

namespace Application.Service
{
    public class AzureQueue : IAzureQueue
    {
        public AzureQueue() {}

        public async Task ReceberDados(Colaborador colaborador)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            QueueClient queue = new QueueClient(connectionString, "to-email");

            string valoresColaborador = string.Concat(colaborador.Nome, ", ", colaborador.Telefone, ", ", colaborador.Email);

            await InserirMensagemNaQueue(queue, valoresColaborador);
        }

        static async Task InserirMensagemNaQueue(QueueClient queue, string valoresColaborador)
        {
            if (null != await queue.CreateIfNotExistsAsync());

            await queue.SendMessageAsync(valoresColaborador);
        }
    }
}
