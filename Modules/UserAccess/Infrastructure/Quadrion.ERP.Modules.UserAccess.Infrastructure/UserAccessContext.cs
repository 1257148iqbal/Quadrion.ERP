using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quadrion.ERP.BuildingBlocks.Application.Outbox;
using Quadrion.ERP.BuildingBlocks.Infrastructure.InternalCommands;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.InternalCommands;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Outbox;

namespace Quadrion.ERP.Modules.UserAccess.Infrastructure
{
    public class UserAccessContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public UserAccessContext(DbContextOptions options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OutboxMessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
        }
    }
}