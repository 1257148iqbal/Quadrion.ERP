using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Quadrion.ERP.Modules.Reports.Application.Contracts
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }

    public interface ICommand : IRequest
    {
        Guid Id { get; }
    }
}
