using System;
using System.Collections.Generic;
using System.Text;
using Quadrion.ERP.Modules.Reports.Application.Contracts;
using Quadrion.ERP.Modules.Reports.Application.ToDoItems.AddNewToDoItem;

namespace Quadrion.ERP.Modules.Reports.Application.ToDoItems.EditToDoItem
{
    public class EditToDoItemCommand : CommandBase<Guid>
    {
        public EditToDoItemCommand(Guid toDoId, string title, List<ToDoItemListDto> list)
        {
            ToDoId = toDoId;
            Title = title;
            List = list;
        }

        internal Guid ToDoId { get; }

        internal string Title { get; }

        internal List<ToDoItemListDto> List { get; }
    }
}