using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities;

namespace AllCar.DataAccess.Configuration
{
    internal class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.CreatedUserId).HasColumnName("CreatedUserId").IsRequired();
            builder.Property(p => p.CreatedDateTime).HasColumnName("CreatedDateTime").IsRequired();
            builder.Property(p => p.UpdatedUserId).HasColumnName("UpdatedUserId");
            builder.Property(p => p.UpdatedDateTime).HasColumnName("UpdatedDateTime");
        }
    }
}
