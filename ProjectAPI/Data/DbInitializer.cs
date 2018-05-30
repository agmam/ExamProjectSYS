using ProjectAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProjectAPIContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Projects.Any())
            {
                return;   // DB has been seeded
            }

            List<Project> pros = new List<Project>
            {
                new Project { Id = 1, Name = "DBDEXAM" , DepartmentNumber = 1 },
                new Project { Id = 2, Name = "SYSEXAM" , DepartmentNumber = 1 },
                new Project { Id = 3, Name = "CA1" , DepartmentNumber = 2 },
                new Project { Id = 4, Name = "CA2", DepartmentNumber = 2 }
            };

            context.Projects.AddRange(pros);
            context.SaveChanges();

        }
    }
}
