using EmployeeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeAPIContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            List<Employee> emps = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Rasmus", LastName ="Madsen" , DepartmentNumber = 1 },
                new Employee { Id = 2, FirstName = "Mahnaz", LastName ="Mirzabagherian" , DepartmentNumber = 1 },
                new Employee { Id = 3, FirstName = "Anders", LastName ="Gadeberg" , DepartmentNumber = 2 },
                new Employee { Id = 4, FirstName = "Emil", LastName ="Dall" , DepartmentNumber = 2 }
            };

            context.Employees.AddRange(emps);
            context.SaveChanges();

        }
    }
}
