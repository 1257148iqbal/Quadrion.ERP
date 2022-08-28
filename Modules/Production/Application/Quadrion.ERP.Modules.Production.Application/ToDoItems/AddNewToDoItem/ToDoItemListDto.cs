using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrion.ERP.Modules.Reports.Application.ToDoItems.AddNewToDoItem
{
    public class ToDoItemListDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }
    }
}
