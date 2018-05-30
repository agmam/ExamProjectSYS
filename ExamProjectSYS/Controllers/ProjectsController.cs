using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Entities;
using ProjectManagementAPI.Gateways;


namespace ProjectManagementAPI.Controllers
{

    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private static IGateway<Project> gateway = new ProjectGateway();
        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return gateway.GetAll();
        }

        // GET: api/Projects/5
        [HttpGet("{id}", Name = "GetPro")]
        public Project Get(int id)
        {
            return gateway.Get(id);
        }

        // POST: api/Projects
        [HttpPost]
        public void Post([FromBody]Project value)
        {
            gateway.Add(value);

        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Project value)
        {
            if (id == value.Id)
            {
                gateway.Edit(value);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            gateway.Remove(id);
        }
    }
}
