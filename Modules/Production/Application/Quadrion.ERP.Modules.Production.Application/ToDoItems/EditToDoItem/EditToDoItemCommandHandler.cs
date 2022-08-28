using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Commands;
using Quadrion.ERP.Modules.Reports.Domain.ToDoItems;

namespace Quadrion.ERP.Modules.Reports.Application.ToDoItems.EditToDoItem
{
    internal class EditToDoItemCommandHandler : ICommandHandler<EditToDoItemCommand, Guid>
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public EditToDoItemCommandHandler(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<Guid> Handle(EditToDoItemCommand command, CancellationToken cancellationToken)
        {
            ToDoItem toDoItem = await _toDoItemRepository.GetById(command.ToDoId);

            toDoItem.Edit(command.Title);

            foreach (var listDto in command.List)
            {
                toDoItem.AddOrUpdateDetail(listDto.Id, listDto.Title, listDto.Note);
            }

            return toDoItem.Id;
        }
    }
}