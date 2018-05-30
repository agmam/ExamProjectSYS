using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentAPI.Data;
using DepartmentAPI.Entities;

namespace DepartmentAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Departments")]
    public class DepartmentsController : Controller
    {
        private readonly IRepository<Department> repo;


        public DepartmentsController(IRepository<Department> rep)
        {
            repo = rep;
        }

        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            return repo.GetAll();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Department = repo.Get(id);

            if (Department == null)
            {
                return NotFound();
            }

            return Ok(Department);
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment([FromRoute] int id, [FromBody] Department Department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Department.Id)
            {
                return BadRequest();
            }



            try
            {
                repo.Edit(Department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] Department Department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Add(Department);

            return CreatedAtAction("GetDepartment", new { id = Department.Id }, Department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!DepartmentExists(id))
            {
                return NotFound();
            }

            repo.Remove(id);

            return Ok();
        }

        private bool DepartmentExists(int id)
        {
            return repo.Get(id) != null;
        }
    }
}