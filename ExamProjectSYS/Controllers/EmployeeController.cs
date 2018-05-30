using System.Collections.Generic;
using EmployeeManagementAPI.Gateways;
using ProjectManagementAPI.Entities;
using ProjectManagementAPI.Gateways;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace EmployeeManagementAPI.Controllers
{



    [Produces("application/json")]

    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private static IGateway<Employee> gateway = new EmployeeGateway();
        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return gateway.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "GetEmp")]
        public Employee Get(int id)
        {
            return gateway.Get(id);
        }

        // POST: api/Employees
        [HttpPost]
        public void Post([FromBody]Employee value)

        {
            gateway.Add(value);

        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee value)
        {
            if (id == value.Id)
            {
                gateway.Edit(value);
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            gateway.Remove(id);
        }
    }
}
