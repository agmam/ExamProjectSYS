
using ProjectManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Gateways
{
    public class ProjectGateway : IGateway<Project>
    {
        private WebAPIService web = new WebAPIService("http://projectapi");
        public Project Add(Project entity)
        {
            var project = web.PostAsync<Project>("/api/projects", entity).Result;
            return project;
        }

        public void Edit(Project entity)
        {
            var project = web.PutAsync<Project>("/api/projects", entity).Result;

        }


        public Project Get(int id)
        {
            var project = web.GetAsync<Project>("/api/projects/" + id).Result;
            return project;

        }

        public IEnumerable<Project> GetAll()
        {
            var project = web.GetAsync<IEnumerable<Project>>("/api/projects").Result;
            return project;
        }

        public void Remove(int id)
        {
            var project = web.DeleteAsync<Project>("/api/projects/"+ id).Result;
           
        }
    }
}
