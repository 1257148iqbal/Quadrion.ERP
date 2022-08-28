using System;
using System.Collections.Generic;
using System.Text;
using Quadrion.ERP.Modules.Reports.Application.Contracts;

namespace Quadrion.ERP.Modules.Reports.Application.ToDoItems.AddNewToDoItem
{
    public class AddNewToDoItemCommand : CommandBase
    {
        public AddNewToDoItemCommand(string title, List<ToDoItemListDto> list)
        {
            Title = title;
            List = list;
        }

        internal string Title { get; }

        internal List<ToDoItemListDto> List { get; }
    }
}
