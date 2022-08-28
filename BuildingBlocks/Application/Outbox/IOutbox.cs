using System.Threading.Tasks;

namespace Quadrion.ERP.BuildingBlocks.Application.Outbox
{
    public interface IOutbox
    {
        void Add(OutboxMessage message);

        Task Save();
    }
}