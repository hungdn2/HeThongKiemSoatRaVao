using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SystemManageOutCome.Data.Entities;

namespace SystemManageOutCome.Data.Configurations
{
    class UserRoleConfiguration : IEntityTypeConfiguration<User_Role>
    {
        public void Configure(EntityTypeBuilder<User_Role> builder)
        {
            builder.HasKey(t => new { t.IdEm, t.IdRole });
            builder.ToTable("UserRole");
 
        }
    }
}
