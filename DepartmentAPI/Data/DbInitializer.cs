using DepartmentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(DepartmentAPIContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Departments.Any())
            {
                return;   // DB has been seeded
            }

            List<Department> deps = new List<Department>
            {
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "Administration"},
               
            };

            context.Departments.AddRange(deps);
            context.SaveChanges();

        }
    }
}
