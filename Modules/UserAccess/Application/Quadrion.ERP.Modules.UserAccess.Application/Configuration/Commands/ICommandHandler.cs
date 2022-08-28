using MediatR;
using Quadrion.ERP.Modules.UserAccess.Application.Contracts;

namespace Quadrion.ERP.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}