using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities.References;

namespace AllCar.DataAccess.Configuration.References
{
    internal class GearEntityConfiguration : BaseEntityConfiguration<GearEntity>
    {
        public override void Configure(EntityTypeBuilder<GearEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Gears");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
