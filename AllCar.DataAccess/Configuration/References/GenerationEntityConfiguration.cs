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
    internal class GenerationEntityConfiguration : BaseEntityConfiguration<GenerationEntity>
    {
        public override void Configure(EntityTypeBuilder<GenerationEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Generations");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.ImageUri)
                .HasColumnName("ImageUri")
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(p => p.ModelId)
                .HasColumnName("ModelId")
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(p => p.StartDate)
                .HasColumnName("StartDate")
                .IsRequired();

            builder.Property(p => p.EndDate)
                .HasColumnName("EndDate")
                .IsRequired(false);
        }
    }
}
