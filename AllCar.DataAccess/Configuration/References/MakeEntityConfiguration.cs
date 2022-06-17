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
    internal class MakeEntityConfiguration : BaseEntityConfiguration<MakeEntity>
    {
        public override void Configure(EntityTypeBuilder<MakeEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Makes");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.LogoImageUri)
                .HasColumnName("LogoImageUri")
                .HasMaxLength(1024)
                .IsRequired();

            builder.HasMany(m => m.Models)
                .WithOne(o => o.Make)
                .HasForeignKey(fk => fk.MakeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
