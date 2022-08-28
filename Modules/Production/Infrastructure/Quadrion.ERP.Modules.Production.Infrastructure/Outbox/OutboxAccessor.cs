using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quadrion.ERP.BuildingBlocks.Application.Outbox;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly ReportsContext _reportsContext;

        internal OutboxAccessor(ReportsContext reportsContext)
        {
            _reportsContext = reportsContext;
        }

        public void Add(OutboxMessage message)
        {
            _reportsContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}
