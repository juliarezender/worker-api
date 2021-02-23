using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;


namespace Function
{
    public class QueueTriggerFunction
    {
        private readonly IEnviarMensagem _enviarMensagem;

        public QueueTriggerFunction(IEnviarMensagem enviarMensagem)
        {
            _enviarMensagem = enviarMensagem;
        }

        [FunctionName("QueueTriggerFunction")]
        public void Run([QueueTrigger("toemail")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            _enviarMensagem.ConfigurarMensagemASerEnviada();
        }
    }
}
