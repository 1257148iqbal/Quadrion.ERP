using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quadrion.ERP.Modules.Reports.Domain.ToDoItems;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Domain.ToDoItems
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ReportsContext _reportsContext;

        public ToDoItemRepository(ReportsContext reportsContext)
        {
            _reportsContext = reportsContext;
        }

        public async Task<ToDoItem> GetById(Guid id)
        {
            return await _reportsContext.ToDoItems.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(ToDoItem item)
        {
            await _reportsContext.ToDoItems.AddAsync(item);
        }

        public async Task<int> Commit()
        {
            return await _reportsContext.SaveChangesAsync();
        }
    }
}
