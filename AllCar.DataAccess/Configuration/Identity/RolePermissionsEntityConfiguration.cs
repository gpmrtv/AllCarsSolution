using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities.Identity;

namespace AllCar.DataAccess.Configuration.Identity
{
    internal class RolePermissionsEntityConfiguration : BaseEntityConfiguration<RolePermissionsEntity>
    {
        public override void Configure(EntityTypeBuilder<RolePermissionsEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("RolePermissions", "identity");

            builder.HasKey(k => new { k.PermissionId, k.RoleId });

            builder.Property(p => p.PermissionId)
                .IsRequired();

            builder.Property(p => p.RoleId)
                .IsRequired();

            builder.HasOne(o => o.Permission)
                .WithMany(m => m.Roles)
                .HasForeignKey(fk => fk.PermissionId);

            builder.HasOne(o => o.Role)
                .WithMany(m => m.Permissions)
                .HasForeignKey(fk => fk.RoleId);
        }
    }
}
