using core_backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class ProjectRepo
    {

        ApplicationDbContext _context;

        public ProjectRepo (ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateProject(string Name, string StartDate, string EndDate)
        {
            Project project = new Project()
            {
                ClientId = 1,
                Name = Name,
                StartDate = Convert.ToDateTime(StartDate),
                EndDate = Convert.ToDateTime(EndDate)
            };
            _context.Projects.Add(project);
            _context.SaveChanges();


        }
    }
}
