using EmployeeAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Data
{
    public class EmployeeRepository: IRepository<Employee>
    {
        private readonly EmployeeAPIContext db;

        public EmployeeRepository(EmployeeAPIContext context)
        {
            
            db = context;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Employee Add(Employee entity)
        {
        
            var Employee = db.Employees.Add(entity).Entity;
            db.SaveChanges();
            return Employee;
        }

        public void Edit(Employee entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public void Remove(int id)
        {
            var emp = db.Employees.FirstOrDefault(p => p.Id == id);
            db.Employees.Remove(emp);
            db.SaveChanges();
        }
    }
}
