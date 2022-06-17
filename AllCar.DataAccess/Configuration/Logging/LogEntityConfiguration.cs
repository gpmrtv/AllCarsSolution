using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities;

namespace AllCar.DataAccess.Configuration.Logging
{
    public class LogEntityConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public virtual void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ContextId).HasColumnName("ContextId").IsRequired();
            builder.Property(p => p.OldJson).HasColumnName("OldJson");
            builder.Property(p => p.NewJson).HasColumnName("NewJson");
            builder.Property(p => p.DifferentsJson).HasColumnName("DifferentsJson");
            builder.Property(p => p.ModifiedUserId).HasColumnName("ModifiedUserId").IsRequired();
            builder.Property(p => p.ModifiedDateTime).HasColumnName("ModifiedDateTime").IsRequired();
            builder.Property(p => p.Operation).HasColumnName("Operation").IsRequired();

            builder.Ignore(p => p.CreatedDateTime);
            builder.Ignore(p => p.UpdatedDateTime);
            builder.Ignore(p => p.CreatedUserId);
            builder.Ignore(p => p.UpdatedUserId);
        }
    }
}
