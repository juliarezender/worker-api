using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MailKit.Net.Smtp;

[assembly: FunctionsStartup(typeof(Function.Startup))]

namespace Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IEnviarMensagem, EnviarMensagem>();
        }
    }
}
