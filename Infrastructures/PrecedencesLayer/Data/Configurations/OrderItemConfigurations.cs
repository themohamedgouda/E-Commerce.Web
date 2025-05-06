using DomainLayer.Models.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecedencesLayer.Data.Configurations
{
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
        
            builder.Property(oi => oi.Price)
                .HasColumnType("decimal(8,2)");

            builder.OwnsOne(OI => OI.Product);

        }
    }
}
