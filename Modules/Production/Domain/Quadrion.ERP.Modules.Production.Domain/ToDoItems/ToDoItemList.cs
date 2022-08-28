using System;
using System.Collections.Generic;
using System.Text;
using Quadrion.ERP.BuildingBlocks.Domain;

namespace Quadrion.ERP.Modules.Reports.Domain.ToDoItems
{
    public class ToDoItemList : Entity
    {
        public Guid Id { get; private set; }

        internal Guid ItemId { get; private set; }

        internal string Title { get; private set; }

        internal string Note { get; private set; }

        private ToDoItemList()
        {
        }

        private ToDoItemList(string title, string note)
        {
            Title = title;
            Note = note;
        }

        public static ToDoItemList CreateNew(string title, string note) => new ToDoItemList(title, note);

        public void Edit(string title, string note)
        {
            Title = title;
            Note = note;
        }
    }
}