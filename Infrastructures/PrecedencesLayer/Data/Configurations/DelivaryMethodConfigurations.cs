using DomainLayer.Models.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecedencesLayer.Data.Configurations
{
    internal class DelivaryMethodConfigurations : IEntityTypeConfiguration<DelivaryMethod>
    {
        public void Configure(EntityTypeBuilder<DelivaryMethod> builder)
        {
            builder.ToTable("DelivaryMethods")
                .Property(P => P.Price)
                .HasColumnType("decimal(8,2)");

            builder.Property(N => N.ShortName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(D => D.DeliveryTime)
                .HasColumnType("varchar")
                .HasMaxLength(50);




























        }
    }
}
