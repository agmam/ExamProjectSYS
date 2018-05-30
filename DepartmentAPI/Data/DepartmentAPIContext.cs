using DepartmentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Data
{
    public class DepartmentAPIContext: DbContext
    {
        public DepartmentAPIContext(DbContextOptions<DepartmentAPIContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasKey(c => c.Id);

        }
    }
}
