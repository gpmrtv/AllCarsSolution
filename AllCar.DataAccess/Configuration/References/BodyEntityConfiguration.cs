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
    internal class BodyEntityConfiguration : BaseEntityConfiguration<BodyEntity>
    {
        public override void Configure(EntityTypeBuilder<BodyEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Bodies");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.ParentId)
                .HasColumnName("ParentId")
                .IsRequired(false);

            builder.HasMany(m => m.Childrens)
                .WithOne(o => o.Parent)
                .HasForeignKey(fk => fk.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
