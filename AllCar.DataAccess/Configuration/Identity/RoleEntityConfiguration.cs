using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities.Identity;

namespace AllCar.DataAccess.Configuration.Identity
{
    internal class RoleEntityConfiguration : BaseEntityConfiguration<RoleEntity>
    {
        public override void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Roles");

            builder.Property(p => p.ContextUid)
                .IsRequired(false);

            builder.Property(p => p.ParentId)
                .IsRequired(false);

            builder.Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasOne(o => o.Parent)
                .WithOne()
                .HasForeignKey<RoleEntity>(fk => fk.ParentId);
        }
    }
}
