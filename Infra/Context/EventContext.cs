using Core.Events;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;
namespace Infra. Context{
    public class EventContext : DbContext{
     
        public DbSet<StoredEvent> StoredEvent { get; set; }

        public EventContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
