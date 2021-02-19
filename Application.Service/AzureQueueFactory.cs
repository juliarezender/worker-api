using Azure.Storage.Queues;
using System;

namespace Application.Service
{
    public class AzureQueueFactory : IAzureQueueFactory
    {
        public QueueClient ObterQueue()
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            return new QueueClient(connectionString, "toemail", new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 });
        }
    }

    public interface IAzureQueueFactory
    {
        QueueClient ObterQueue();
    }
}
