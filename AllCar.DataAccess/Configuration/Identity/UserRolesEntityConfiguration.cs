using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities.Identity;

namespace AllCar.DataAccess.Configuration.Identity
{
    internal class UserRolesEntityConfiguration : BaseEntityConfiguration<UserRolesEntity>
    {
        public override void Configure(EntityTypeBuilder<UserRolesEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserRoles");

            builder.HasKey(k => new { k.UserId, k.RoleId });

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.RoleId)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(m => m.Roles)
                .HasForeignKey(fk => fk.UserId);

            builder.HasOne(o => o.Role)
                .WithMany(m => m.Users)
                .HasForeignKey(fk => fk.RoleId);
        }
    }
}
