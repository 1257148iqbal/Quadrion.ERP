using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quadrion.ERP.Modules.Reports.Application.Contracts;

namespace Quadrion.ERP.Modules.Reports.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
    }
}
