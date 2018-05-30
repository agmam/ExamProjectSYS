using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentManagementAPI.Gateways;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Entities;
using ProjectManagementAPI.Gateways;

namespace ProjectManagementAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Department")]
    public class DepartmentController : Controller
    {
        private static IGateway<Department> gateway = new DepartmentGateway();
        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return gateway.GetAll();
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "GetDep")]
        public Department Get(int id)
        {
            return gateway.Get(id);
        }

        // POST: api/Departments
        [HttpPost]
        public void Post([FromBody]Department value)
        {
            gateway.Add(value);

        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Department value)
        {
            if (id == value.Id)
            {
                gateway.Edit(value);
            }
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            gateway.Remove(id);
        }
    }
}