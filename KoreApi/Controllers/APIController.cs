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
        TimeslipRepo timeSlipRepo;
        WBIRepo wbiRepo;

        public APIController(ApplicationDbContext context)
        {
           
            projectRepo = new ProjectRepo(context);
            clientRepo = new ClientRepo(context);
            wbiRepo = new WBIRepo(context);
            timeSlipRepo = new TimeslipRepo(context);
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
        public IActionResult CreateWBI(string description, int estimatedHours, int actualHours, int projectId)
        {
            
            return new OkObjectResult(wbiRepo.CreateWBI(description, estimatedHours, actualHours, projectId));
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
        public IActionResult EditWBI(int id, string description, int estimatedHours, int actualHours)
        {
            var wbi = wbiRepo.EditWBI(id, description, estimatedHours, actualHours);
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
        [Route("CreateTimeslip")]
        public IActionResult CreateTimeslip(string StartTime, string EndTime, string remarks, string tag, int workBreakDownId)
        {

            return new ObjectResult(timeSlipRepo.CreateTimeslip(StartTime, EndTime, remarks, tag, workBreakDownId));
        }

        [HttpGet]
        [Route("GetAllTimeslips")]
        public IActionResult GetAllTimeslips()
        {
            return new ObjectResult(timeSlipRepo.GetAllTimeslips());
        }

        [HttpGet]
        [Route("GetOneTimeslip/{id}")]
        public IActionResult GetOneTimeslip(int id)
        {
            return new ObjectResult(timeSlipRepo.GetOneTimeslip(id));
        }

        [HttpPut]
        [Route("EditTimeslip")]
        public IActionResult EditTimeslip(int id, string StartTime, string EndTime, string remarks, string tag)
        {
            var timeslip = timeSlipRepo.EditTimeslip(id, StartTime, EndTime, remarks, tag);
            if (timeslip == null)
            {
                return new NotFoundObjectResult(timeslip);
            }
            return new ObjectResult(timeslip);
        }

        [HttpDelete]
        [Route("DeleteOneTimeslip")]
        public IActionResult DeleteOneTimeslip(int id)
        {
            var timeslip = timeSlipRepo.DeleteOneTimeslip(id);
            if (timeslip == null)
            {
                return new NotFoundObjectResult(timeslip);
            }
            return new ObjectResult(timeslip);
        }
    }
}