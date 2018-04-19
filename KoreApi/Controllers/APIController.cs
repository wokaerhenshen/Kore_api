using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_backend.Data;
using core_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace core_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/API")]
    public class APIController : Controller
    {

        ProjectRepo projectRepo;
        ClientRepo clientRepo;
        // WBIRepo wBIRepo;
        // TimeSlipRepo timeSlipRepo;

        public APIController(ApplicationDbContext context)
        {
            projectRepo = new ProjectRepo(context);
            clientRepo = new ClientRepo(context);
        }

        [HttpPost]
        [Route("CreateClient")]
        public bool CreateClient(string Name, int DeletionStateCode,int StateCode)
        {
            clientRepo.CreateClient(Name, DeletionStateCode, StateCode);
            return true;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public IActionResult GetAllClients()
        {
            return new OkObjectResult(clientRepo.GetAllClients());
        }

        [HttpGet]
        [Route("GetOneClient/{id}")]
        public IActionResult GetOneClient(int id)
        {
            return new OkObjectResult(clientRepo.GetOneClient(id));
        }

        //update client
        [HttpPut]
        [Route("UpdateOneClient")]
        public bool UpdateOneClient(int id,string Name, int DeletionStateCode, int StateCode)
        {
            clientRepo.UpdateOneClient(id,Name, DeletionStateCode, StateCode);
            return true;
        }

        //delete client
        [HttpDelete]
        [Route("DeleteOneClient")]
        public bool DeleteOneClient(int id)
        {
            clientRepo.DeleteOneClient(id);
            return true;
        }

        [HttpPost]
        [Route("CreateProject")]
        public bool CreateProject(int ClientId, string Name, string StartDate, string EndDate)
        {
            projectRepo.CreateProject(ClientId, Name, StartDate, EndDate);
            return true;
        }

        [HttpGet]
        [Route("GetAllProject")]
        public IActionResult GetAllProject()
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
        [Route("UpdateOneProject")]
        public bool UpdateOneProject(int id, string Name, string StartDate, string EndDate)
        {
            projectRepo.UpdateOneProject(id, Name, StartDate, EndDate);
            return true;
        }

        [HttpDelete]
        [Route("DeleteOneProject")]
        public bool DeleteOneProject(int id)
        {
            projectRepo.DeleteOneProject(id);
            return true;
        }



        [HttpPost]
        [Route("CreateWBI")]
        public bool CreateWBI()
        {
            return true;
        }



        [HttpPost]
        [Route("CreateTimeSlip")]
        public bool CreateTimeSlip()
        {
            return true;
        }


    }
}