using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quadrion.ERP.BuildingBlocks.Application.Outbox;
using Quadrion.ERP.BuildingBlocks.Infrastructure.InternalCommands;
using Quadrion.ERP.Modules.Reports.Domain.ToDoItems;

namespace Quadrion.ERP.Modules.Reports.Infrastructure
{
    public class ReportsContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public ReportsContext(DbContextOptions options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
