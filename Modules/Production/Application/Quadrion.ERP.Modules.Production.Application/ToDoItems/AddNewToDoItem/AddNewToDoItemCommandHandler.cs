using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Commands;
using Quadrion.ERP.Modules.Reports.Domain.ToDoItems;

namespace Quadrion.ERP.Modules.Reports.Application.ToDoItems.AddNewToDoItem
{
    internal class AddNewToDoItemCommandHandler : ICommandHandler<AddNewToDoItemCommand>
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public AddNewToDoItemCommandHandler(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<Unit> Handle(AddNewToDoItemCommand command, CancellationToken cancellationToken)
        {
            ToDoItem toDoItem = ToDoItem.CreateNew(command.Title);

            foreach (var listDto in command.List)
            {
                toDoItem.AddOrUpdateDetail(Guid.NewGuid(), listDto.Title, listDto.Note);
            }

            await _toDoItemRepository.AddAsync(toDoItem);

            return Unit.Value;
        }
    }
}