using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using Quadrion.ERP.Modules.Reports.Application.Contracts;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Processing;

namespace Quadrion.ERP.Modules.Reports.Infrastructure
{
    public class ReportsModule : IReportsModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = ReportsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
