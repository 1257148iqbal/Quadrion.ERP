using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quadrion.ERP.Modules.Reports.Domain.ToDoItems;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Domain.ToDoItems
{
    public class ToDoItemEntityTypeConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        private const string Schema = "Reports";

        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.ToTable("ToDoItems", Schema);

            builder.HasKey(x => x.Id);

            builder.Property<string>("Title");

            builder.OwnsMany<ToDoItemList>("List", b =>
            {
                b.WithOwner().HasForeignKey("ItemId");
                b.ToTable("ToDoItemList", Schema);
                b.Property<Guid>("ItemId");
                b.Property<string>("Title");
                b.Property<string>("Note");

                b.HasKey(x=> x.Id);
            });
        }
    }
}
