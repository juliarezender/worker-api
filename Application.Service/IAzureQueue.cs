using Domain.Modelos;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IAzureQueue
    {
        Task ReceberDados(Colaborador colaborador);
    }
}
