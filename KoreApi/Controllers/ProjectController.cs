using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_backend.Data;
using core_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace core_backend.Controllers
{
    [Produces("application/json")]
    [Route("project")]
    public class ProjectController : Controller
    {
        ProjectRepo projectRepo;

        public ProjectController(ApplicationDbContext context)
        {
            projectRepo = new ProjectRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public bool Create(int ClientId, string Name, string StartDate, string EndDate)
        {
            projectRepo.CreateProject(ClientId, Name, StartDate, EndDate);
            return true;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(projectRepo.GetAllProjects());
        }

        [HttpGet]
        [Route("GetOneProject/{id}")]
        public IActionResult GetOneProject(int id)
        {
            return new OkObjectResult(projectRepo.GetOneProject(id));
        }

        [HttpPut]
        [Route("Update")]
        public bool Update(int id, string Name, string StartDate, string EndDate)
        {
            projectRepo.UpdateOneProject(id, Name, StartDate, EndDate);
            return true;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(int id)
        {
            projectRepo.DeleteOneProject(id);
            return true;
        }
    }
}