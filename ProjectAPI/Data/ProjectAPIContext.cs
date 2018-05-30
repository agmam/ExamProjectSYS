using Microsoft.EntityFrameworkCore;
using ProjectAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Data
{
    public class ProjectAPIContext : DbContext
    {
        public ProjectAPIContext(DbContextOptions<ProjectAPIContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(c => c.Id);

        }
    }
}

