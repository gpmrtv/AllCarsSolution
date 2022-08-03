using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities.Identity;

namespace AllCar.DataAccess.Configuration.Identity
{
    internal class PermissionEntityConfiguration : BaseEntityConfiguration<PermissionEntity>
    {
        public override void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Permissions", "identity");

            builder.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
