using Microsoft.EntityFrameworkCore;

using SystemManageOutCome.Data.Configurations;
using SystemManageOutCome.Data.Entities;


namespace SystemManageOutCome.Data.EF
{
    public class SystemManageDBContext : DbContext
    {
        public SystemManageDBContext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CameraConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Camera> cameras { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User_Role> user_Roles { get; set; }
        public DbSet<Customer> customers { get; set; }
    }

}
