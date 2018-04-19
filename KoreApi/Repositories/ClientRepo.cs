using core_backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class ClientRepo
    {

        ApplicationDbContext _context;

        public ClientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateClient(string Name, int DeletionStateCode, int StateCode)
        {
            Client client = new Client()
            {
                Name = Name,
                DeletionStateCode = DeletionStateCode,
                StateCode = StateCode
            };
            _context.Clients.Add(client);
            _context.SaveChanges();


        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetOneClient(int id)
        {
            return _context.Clients.Where(i => i.ClientId == id).FirstOrDefault();
        }


    }
}
