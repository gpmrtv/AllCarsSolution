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
    internal class ModelEntityConfiguration : BaseEntityConfiguration<ModelEntity>
    {
        public override void Configure(EntityTypeBuilder<ModelEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Models");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.MakeId)
                .HasColumnName("MakeId")
                .IsRequired();

            builder.Property(p => p.ParentId)
                .HasColumnName("ParentId")
                .IsRequired(false);

            builder.HasMany(m => m.Children)
                .WithOne(o => o.Parent)
                .HasForeignKey(o => o.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Generations)
                .WithOne(o => o.Model)
                .HasForeignKey(o => o.ModelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
