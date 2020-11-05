using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SystemManageOutCome.Data.EF
{
    public class SystemManageOutComeDbContextFactory : IDesignTimeDbContextFactory<SystemManageDBContext>
    {
        public SystemManageDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("SystemManageOutComeDatabase");


            var optionBuilder = new DbContextOptionsBuilder<SystemManageDBContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new SystemManageDBContext(optionBuilder.Options);



        }
    }
}
