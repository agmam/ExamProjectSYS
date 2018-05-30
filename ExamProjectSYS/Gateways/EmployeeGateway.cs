using ProjectManagementAPI.Entities;
using ProjectManagementAPI.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Gateways
{
    public class EmployeeGateway : IGateway<Employee>
    {
        private WebAPIService web = new WebAPIService("http://employeeapi");
        public Employee Add(Employee entity)
        {
            var Employee = web.PostAsync<Employee>("/api/Employees", entity).Result;
            return Employee;
        }

        public void Edit(Employee entity)
        {
            var Employee = web.PutAsync<Employee>("/api/Employees", entity).Result;

        }


        public Employee Get(int id)
        {
            var Employee = web.GetAsync<Employee>("/api/Employees/" + id).Result;
            return Employee;

        }

        public IEnumerable<Employee> GetAll()
        {
            var Employee = web.GetAsync<IEnumerable<Employee>>("/api/Employees").Result;
            return Employee;
        }

        public void Remove(int id)
        {
            var Employee = web.DeleteAsync<Employee>("/api/Employees/" + id).Result;

        }
    }
}

