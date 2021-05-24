using System.Threading.Tasks;
using API.Core.Command;
using Core.Events;

namespace Core.Interfaces{
     public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}