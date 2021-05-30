using System;
using Microsoft.EntityFrameworkCore;

namespace SaloonStudio.Model
{
    public class SaloonDbContext:DbContext
    {
        public SaloonDbContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseMySql(@"Server=localhost;Database=SaloonStudio;Uid=root;Pwd=Admin@123;",
                new MySqlServerVersion(new Version(8, 0, 25)),
                optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            
        }


    }
}
