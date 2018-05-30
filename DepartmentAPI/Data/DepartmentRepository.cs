using DepartmentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Data
{
    public class DepartmentRepository: IRepository<Department>
    {
        private readonly DepartmentAPIContext db;

        public DepartmentRepository(DepartmentAPIContext context)
        {

            db = context;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Department Add(Department entity)
        {

            var Department = db.Departments.Add(entity).Entity;
            db.SaveChanges();
            return Department;
        }

        public void Edit(Department entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Department Get(int id)
        {
            return db.Departments.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public void Remove(int id)
        {
            var emp = db.Departments.FirstOrDefault(p => p.Id == id);
            db.Departments.Remove(emp);
            db.SaveChanges();
        }
    }
}
