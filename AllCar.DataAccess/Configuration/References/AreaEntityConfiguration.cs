using AllCar.Shared.Entities.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AllCar.Shared.Entities;

namespace AllCar.DataAccess.Configuration.References
{
    internal class AreaEntityConfiguration : BaseEntityConfiguration<AreaEntity>
    {
        public override void Configure(EntityTypeBuilder<AreaEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Areas");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("Description")
                .IsRequired(false);

            builder.Property(p => p.LogoUri)
                .HasColumnName("LogoUri")
                .IsRequired();

            builder.HasMany(m => m.Cars)
                .WithMany(m => m.Areas)
                .UsingEntity<CarAreasEntity>(
                   j => j
                    .HasOne(pt => pt.Car)
                    .WithMany(t => t.CarAreas)
                    .HasForeignKey(pt => pt.CarId),
                j => j
                    .HasOne(pt => pt.Area)
                    .WithMany(p => p.CarAreas)
                    .HasForeignKey(pt => pt.AreaId),
                j =>
                {
                    j.HasKey(t => new { t.CarId, t.AreaId });
                    j.Property(p => p.Cost)
                        .HasColumnName("Cost")
                        .IsRequired();
                    j.ToTable("CarAreas");
                });
        }
    }
}
