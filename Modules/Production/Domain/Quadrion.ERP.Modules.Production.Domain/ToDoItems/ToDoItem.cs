using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quadrion.ERP.BuildingBlocks.Domain;

namespace Quadrion.ERP.Modules.Reports.Domain.ToDoItems
{
    public class ToDoItem : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        internal string Title { get; private set; }

        internal List<ToDoItemList> List { get; private set; }

        private ToDoItem()
        {
            List = new List<ToDoItemList>();
        }

        private ToDoItem(string title)
        {
            Title = title;

            List = new List<ToDoItemList>();
        }

        public static ToDoItem CreateNew(string title) => new ToDoItem(title);

        public void Edit(string title)
        {
            Title = title;
        }

        public void AddOrUpdateDetail(Guid id, string title, string note)
        {
            if (List.All(x => x.Id != id))
            {
                List.Add(ToDoItemList.CreateNew(title, note));
            }
            else
            {
                var existingTodo = List.FirstOrDefault(x => x.Id == id);
                existingTodo?.Edit(title, note);
            }
        }
    }
}