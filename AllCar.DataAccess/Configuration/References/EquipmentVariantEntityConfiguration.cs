using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.DataAccess.Configuration.References
{
    internal class EquipmentVariantEntityConfiguration : BaseEntityConfiguration<EquipmentVariantEntity>
    {
        public override void Configure(EntityTypeBuilder<EquipmentVariantEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("EquipmentOptions");

            builder.Property(p => p.BodyId)
                .HasColumnName("BodyId")
                .IsRequired();

            builder.Property(p => p.GearboxId)
                .HasColumnName("GearboxId")
                .IsRequired();

            builder.Property(p => p.GearId)
                .HasColumnName("GearId")
                .IsRequired();

            builder.Property(p => p.GenerationId)
                .HasColumnName("GenerationId")
                .IsRequired();

            builder.Property(p => p.MakeId)
                .HasColumnName("MakeId")
                .IsRequired();

            builder.Property(p => p.ModelId)
                .HasColumnName("ModelId")
                .IsRequired();

            builder.HasOne(o => o.Body)
                .WithOne(o => o.EquipmentVariant)
                .HasForeignKey<EquipmentVariantEntity>(fk => fk.BodyId)
                .IsRequired();

            builder.HasOne(o => o.Gearbox)
                .WithOne(o => o.EquipmentVariant)
                .HasForeignKey<EquipmentVariantEntity>(fk => fk.GearboxId)
                .IsRequired();

            builder.HasOne(o => o.Gear)
                .WithOne(o => o.EquipmentVariant)
                .HasForeignKey<EquipmentVariantEntity>(fk => fk.GearId)
                .IsRequired();

            builder.HasOne(o => o.Generation)
                .WithOne(o => o.EquipmentVariant)
                .HasForeignKey<EquipmentVariantEntity>(fk => fk.GenerationId)
                .IsRequired();

            builder.HasOne(o => o.Make)
                .WithOne(o => o.EquipmentVariant)
                .HasForeignKey<EquipmentVariantEntity>(fk => fk.MakeId)
                .IsRequired();

            builder.HasOne(o => o.Model)
                .WithOne(o => o.EquipmentVariant)
                .HasForeignKey<EquipmentVariantEntity>(fk => fk.ModelId)
                .IsRequired();
        }
    }
}
