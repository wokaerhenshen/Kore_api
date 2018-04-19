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
    [Route("api")]
    public class APIController : Controller
    {

        ProjectRepo projectRepo;
        ClientRepo clientRepo;
         WBIRepo wbiRepo;
        // TimeSlipRepo timeSlipRepo;

        public APIController(ApplicationDbContext context)
        {
           
            projectRepo = new ProjectRepo(context);
            clientRepo = new ClientRepo(context);
            wbiRepo = new WBIRepo(context);
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
        public IActionResult CreateWBI(string name, string description, int estimatedHours, int actualHours, int projectId)
        {
            
            return new OkObjectResult(wbiRepo.CreateWBI(name, description, estimatedHours, actualHours, projectId));
        }
        [HttpGet]
        [Route("GetAllWBIs")]
        public IActionResult GetAllWBIs()
        {
            return new OkObjectResult(wbiRepo.GetAllWBIs());
        }

        [HttpGet]
        [Route("GetOneWBI/{id}")]
        public IActionResult GetOneWBI(int id)
        {
            return new OkObjectResult(wbiRepo.GetOneWBI(id));
        }

        [HttpPut]
        [Route("EditWBI")]
        public IActionResult EditWBI(int id, string name, string description, int estimatedHours, int actualHours)
        {
            var wbi = wbiRepo.EditWBI(id, name, description, estimatedHours, actualHours);
            if (wbi == null)
            {
                return new NotFoundObjectResult(wbi);
            }
            return new OkObjectResult(wbi);
        }
        [HttpDelete]
        [Route("DeleteOneWBI")]
        public IActionResult RemoveWBI(int id)
        {
            var wbi = wbiRepo.DeleteOneWBI(id);
            if (wbi == null)
            {
                return new NotFoundObjectResult(wbi);
            }
            return new OkObjectResult(wbi);
        }
        [HttpPost]
        [Route("CreateTimeSlip")]
        public bool CreateTimeSlip()
        {
            return true;
        }

        

    }
}