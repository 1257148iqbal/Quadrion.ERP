using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quadrion.ERP.Modules.Reports.Application.Contracts
{
    public interface IReportsModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
