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
    [Route("wbi")]
    public class WBIController : Controller
    {
        WBIRepo wbiRepo;

        public WBIController(ApplicationDbContext context)
        {
            wbiRepo = new WBIRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string description, int estimatedHours, int actualHours, int projectId)
        {
            return new OkObjectResult(wbiRepo.CreateWBI(description, estimatedHours, actualHours, projectId));
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
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
        [Route("Edit")]
        public IActionResult Edit(int id, string description, int estimatedHours, int actualHours)
        {
            var wbi = wbiRepo.EditWBI(id, description, estimatedHours, actualHours);
            if (wbi == null)
            {
                return new NotFoundObjectResult(wbi);
            }
            return new OkObjectResult(wbi);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var wbi = wbiRepo.DeleteOneWBI(id);
            if (wbi == null)
            {
                return new NotFoundObjectResult(wbi);
            }
            return new OkObjectResult(wbi);
        }
    }
}