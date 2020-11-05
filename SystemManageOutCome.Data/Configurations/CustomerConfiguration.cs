using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SystemManageOutCome.Data.Entities;

namespace SystemManageOutCome.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CMT).IsRequired();
            builder.Property(x => x.Member).IsRequired().HasDefaultValue<int>(1);
            
        }
    }
}
