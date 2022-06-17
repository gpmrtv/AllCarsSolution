using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities;

namespace AllCar.DataAccess.Configuration
{
    internal class CarEntityConfiguration : BaseEntityConfiguration<CarEntity>
    {
        public override void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Cars");

            builder.Property(p => p.Vin)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.BodyNum)
                .HasMaxLength(64);

            builder.Property(p => p.ChassisNum)
                .HasMaxLength(64);

            builder.Property(p => p.EngineNum)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Notes)
                .HasMaxLength(2048);

            builder.Property(p => p.Year)
                .IsRequired();

            builder.Property(p => p.EquipmentVariantId)
                .HasColumnName("EquipmentVariantId")
                .IsRequired();

            builder.Property(p => p.ColorId)
                .HasColumnName("ColorId")
                .IsRequired();

            builder.HasOne(o => o.Color)
                .WithMany(m => m.Cars)
                .HasForeignKey(fk => fk.ColorId)
                .IsRequired();

            builder.HasOne(o => o.EquipmentVariant)
                .WithMany(m => m.Cars)
                .HasForeignKey(fk => fk.EquipmentVariantId)
                .IsRequired();
        }
    }
}
