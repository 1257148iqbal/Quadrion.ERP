using System.Collections.Generic;
using Quadrion.ERP.BuildingBlocks.Domain;

namespace Quadrion.ERP.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public interface IDomainEventsAccessor
    {
        IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}