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
       // WBIRepo wBIRepo;
       // TimeSlipRepo timeSlipRepo;

        public APIController(ApplicationDbContext context)
        {
            
        }

        [HttpPost]
        [Route("CreateProject")]
        public bool CreateProject(string Name, DateTime StartDate, DateTime EndDate)
        {
            projectRepo.CreateProject(Name, StartDate, EndDate);
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