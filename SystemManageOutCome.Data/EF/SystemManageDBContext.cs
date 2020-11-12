using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SystemManageOutCome.Data.Entities;


namespace SystemManageOutCome.Data.EF
{
    public class SystemManageDBContext : IdentityDbContext
    {
        public SystemManageDBContext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Camera> cameras { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User_Role> user_Roles { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<CustomerImage> CustomerIm { get; set; }
        public DbSet<HistoryComeOut> historyComeOuts { get; set; }

    }

}
