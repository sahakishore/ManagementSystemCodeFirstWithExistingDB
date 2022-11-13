using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ManagementSystemCodeFirstWithExistingDB
{
    public partial class ManagementSystemContext : DbContext
    {
        public ManagementSystemContext()
            : base("name=ManagementSystemContext")
        {
        }

        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.EmployeeDetail)
                .WithRequired(e => e.Employee);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RoleId);
        }
    }
}
