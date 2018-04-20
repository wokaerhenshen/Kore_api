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
    [Route("client")]
    public class ClientController : Controller
    {
        ClientRepo clientRepo;

        public ClientController(ApplicationDbContext context)
        {
            clientRepo = new ClientRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public bool Create(string Name, int DeletionStateCode, int StateCode)
        {
            clientRepo.CreateClient(Name, DeletionStateCode, StateCode);
            return true;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
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
        [Route("Update")]
        public bool Update(int id, string Name, int DeletionStateCode, int StateCode)
        {
            clientRepo.UpdateOneClient(id, Name, DeletionStateCode, StateCode);
            return true;
        }

        //delete client
        [HttpDelete]
        [Route("Delete")]
        public bool Delete(int id)
        {
            clientRepo.DeleteOneClient(id);
            return true;
        }
    }
}