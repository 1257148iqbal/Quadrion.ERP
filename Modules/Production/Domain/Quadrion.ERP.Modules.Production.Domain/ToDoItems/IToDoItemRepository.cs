using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quadrion.ERP.Modules.Reports.Domain.ToDoItems
{
    public interface IToDoItemRepository
    {
        Task<ToDoItem> GetById(Guid id);

        Task AddAsync(ToDoItem item);

        Task<int> Commit();
    }
}
