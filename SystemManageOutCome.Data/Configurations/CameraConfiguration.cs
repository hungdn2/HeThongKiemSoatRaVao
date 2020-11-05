using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SystemManageOutCome.Data.Entities;


namespace SystemManageOutCome.Data.Configurations
{
    public class CameraConfiguration : IEntityTypeConfiguration<Camera>
    {
   

        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            // primary
            builder.ToTable("Camera");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();

            // bat buoc nhap
            builder.Property(x => x.Cam_Name).IsRequired(true);
            builder.Property(x => x.Cam_address);
        }
    }
}
