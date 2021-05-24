using Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
                builder.Property(c => c.Timestamp)
                    .HasField("CreationDate");

                builder.Property(c => c.MessageType)
                    .HasField("Action");
        }
    }
}