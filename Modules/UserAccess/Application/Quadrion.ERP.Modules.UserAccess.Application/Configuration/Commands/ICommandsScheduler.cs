using System.Threading.Tasks;
using Quadrion.ERP.Modules.UserAccess.Application.Contracts;

namespace Quadrion.ERP.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<T>(ICommand<T> command);
    }
}