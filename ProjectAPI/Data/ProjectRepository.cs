using Microsoft.EntityFrameworkCore;
using ProjectAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Data
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly ProjectAPIContext db;

        public ProjectRepository(ProjectAPIContext context)
        {

            db = context;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Project Add(Project entity)
        {

            var Project = db.Projects.Add(entity).Entity;
            db.SaveChanges();
            return Project;
        }

        public void Edit(Project entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Project Get(int id)
        {
            return db.Projects.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects.ToList();
        }

        public void Remove(int id)
        {
            var emp = db.Projects.FirstOrDefault(p => p.Id == id);
            db.Projects.Remove(emp);
            db.SaveChanges();
        }
    }
}
