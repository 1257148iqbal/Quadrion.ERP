using MediatR;
using Quadrion.ERP.Modules.UserAccess.Application.Contracts;

namespace Quadrion.ERP.Modules.UserAccess.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}