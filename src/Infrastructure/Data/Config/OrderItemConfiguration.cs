﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(oi => oi.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(oi => oi.ProductName)
                .HasMaxLength(100);

            builder.Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);
        }
    }
}
