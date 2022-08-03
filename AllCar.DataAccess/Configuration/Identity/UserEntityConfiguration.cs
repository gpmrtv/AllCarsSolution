using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities.Identity;

namespace AllCar.DataAccess.Configuration.Identity
{
    internal class UserEntityConfiguration : BaseEntityConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users", "identity");

            builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(128).IsRequired();
            builder.Property(p => p.Login).HasMaxLength(64).IsRequired();
        }
    }
}
