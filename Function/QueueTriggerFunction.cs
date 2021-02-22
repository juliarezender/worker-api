using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;


namespace Function
{
    public static class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        public static void Run([QueueTrigger("toemail")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            EnviarMensagem.ConfigurarMensagemASerEnviada();
        }
    }
}
