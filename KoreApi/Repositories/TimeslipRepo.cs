using core_backend.Data;
using core_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class TimeslipRepo
    {
        ApplicationDbContext _context;

        public TimeslipRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateTimeslip (string StartTime, string EndTime)
        {

            Timeslip timeslip = new Timeslip()
            {
                StartTime = DateTime.Parse(StartTime),
                EndTime = DateTime.Parse(EndTime),
                UserId = "1",
                WorkBreakdownItemId = 1
            };
            _context.Timeslips.Add(timeslip);
            _context.SaveChanges();
        }
    }
}
