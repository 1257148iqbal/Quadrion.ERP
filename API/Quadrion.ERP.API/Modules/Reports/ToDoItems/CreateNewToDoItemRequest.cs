using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quadrion.ERP.Modules.Reports.Application.ToDoItems.AddNewToDoItem;

namespace Quadrion.ERP.API.Modules.Reports.ToDoItems
{
    public class CreateNewToDoItemRequest
    {
        public string Title { get; set; }

        public List<ToDoItemListDto> List { get; set; }
    }
}
