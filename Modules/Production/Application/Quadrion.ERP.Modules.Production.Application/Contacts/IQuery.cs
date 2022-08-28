using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Quadrion.ERP.Modules.Reports.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
