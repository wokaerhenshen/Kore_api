using core_backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class WBIRepo
    {
        ApplicationDbContext _context;

        public WBIRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public WorkBreakdownItem CreateWBI(string name, string description, int estimatedHours, int actualHours, int projectId)
        {
            WorkBreakdownItem wbi = new WorkBreakdownItem()
            {
                Name = name,
                Description = description,
                EstimatedHours = estimatedHours,
                ActualHours = actualHours,
                ProjectId = projectId
            };
            _context.WorkBreakdownItems.Add(wbi);
            _context.SaveChanges();

            return wbi;
        }

        public List<WorkBreakdownItem> GetAllWBIs()
        {
            return _context.WorkBreakdownItems.ToList();
        }

        public WorkBreakdownItem GetOneWBI(int id)
        {
            return _context.WorkBreakdownItems.Where(i => i.WorkBreakdownItemId == id)
                .FirstOrDefault();
        }
        public WorkBreakdownItem EditWBI(int id, string name, string description, int estimatedHours, int actualHours, int projectId)
        {
            var wbi = GetOneWBI(id);
            if (wbi == null)
            {
                return wbi;
            }
            else
            {
                wbi.Name = name;
                wbi.Description = description;
                wbi.EstimatedHours = estimatedHours;
                wbi.ActualHours = actualHours;
                wbi.ProjectId = projectId;
                _context.SaveChanges();
            }
            return wbi;
        }
        public WorkBreakdownItem DeleteOneWBI(int id)
        {
            var wbi = GetOneWBI(id);
            if (wbi == null)
            {
                return wbi;
            }
            _context.WorkBreakdownItems.Remove(wbi);
            _context.SaveChanges();
            return wbi;
        }

    }
}
