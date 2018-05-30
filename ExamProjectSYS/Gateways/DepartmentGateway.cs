using ProjectManagementAPI.Entities;
using ProjectManagementAPI.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentManagementAPI.Gateways
{
    public class DepartmentGateway : IGateway<Department>
    {
        private WebAPIService web = new WebAPIService("http://departmentapi");
        public Department Add(Department entity)
        {
            var Department = web.PostAsync<Department>("/api/Departments", entity).Result;
            return Department;
        }

        public void Edit(Department entity)
        {
            var Department = web.PutAsync<Department>("/api/Departments", entity).Result;

        }


        public Department Get(int id)
        {
            var Department = web.GetAsync<Department>("/api/Departments/" + id).Result;
            return Department;

        }

        public IEnumerable<Department> GetAll()
        {
            var Department = web.GetAsync<IEnumerable<Department>>("/api/Departments").Result;
            return Department;
        }

        public void Remove(int id)
        {
            var Department = web.DeleteAsync<Department>("/api/Departments/" + id).Result;

        }
    }
}