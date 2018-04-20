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
    [Route("timeslip")]
    public class TimeslipController : Controller
    {
        TimeslipRepo timeslipRepo;

        public TimeslipController(ApplicationDbContext context)
        {
            timeslipRepo = new TimeslipRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string StartTime, string EndTime, string remarks, string tag, int workBreakDownId)
        {

            return new ObjectResult(timeslipRepo.CreateTimeslip(StartTime, EndTime, remarks, tag, workBreakDownId));
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new ObjectResult(timeslipRepo.GetAllTimeslips());
        }

        [HttpGet]
        [Route("GetOneTimeslip/{id}")]
        public IActionResult GetOneTimeslip(int id)
        {
            return new ObjectResult(timeslipRepo.GetOneTimeslip(id));
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(int id, string StartTime, string EndTime, string remarks, string tag)
        {
            var timeslip = timeslipRepo.EditTimeslip(id, StartTime, EndTime, remarks, tag);
            if (timeslip == null)
            {
                return new NotFoundObjectResult(timeslip);
            }
            return new ObjectResult(timeslip);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var timeslip = timeslipRepo.DeleteOneTimeslip(id);
            if (timeslip == null)
            {
                return new NotFoundObjectResult(timeslip);
            }
            return new ObjectResult(timeslip);
        }
    }
}