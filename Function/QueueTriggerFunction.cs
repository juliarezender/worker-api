using MailKit.Net.Smtp;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using MimeKit;


namespace Function
{
    public static class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        public static void Run([QueueTrigger("toemail")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            ConfigurarMensagemASerEnviada();
        }

        public static void ConfigurarMensagemASerEnviada()
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("email@gmail.com", "email@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("email@gmail.com", "email@gmail.com"));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "Texto"
            };
            ConfigurarSMTPClient(mailMessage);
        }

        public static void ConfigurarSMTPClient(MimeMessage mailMessage)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("email@gmail.com", "password");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
