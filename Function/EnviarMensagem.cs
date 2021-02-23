using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Function
{
    public class EnviarMensagem : IEnviarMensagem 
    {
        public Task ConfigurarMensagemASerEnviada()
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("mail@gmail.com", "mail@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("mail@gmail.com", "mail@gmail.com"));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "Texto"
            };
            ConfigurarSMTPClient(mailMessage);
            return Task.CompletedTask;
        }
        private Task ConfigurarSMTPClient(MimeMessage mailMessage)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("mail@gmail.com", "password");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
            return Task.CompletedTask;
        }

    }
}
