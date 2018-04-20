using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace core_backend.Data
{
    public class Seeder
    {
        private ApplicationDbContext _context;

        public Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (_context.Clients.Any())
            {
                return;
            }
            var clients = new Client[]
            {
                new Client { Name = "Calgary Flames", DeletionStateCode = 1, StateCode = 1 },
                new Client { Name = "Vancouver Canucks", DeletionStateCode = 2, StateCode = 2 },
                new Client { Name = "Winnipeg Jets", DeletionStateCode = 3, StateCode = 3 }
            };
            foreach (Client c in clients)
            {
                _context.Clients.Add(c);
            }
            _context.SaveChanges();

            if (_context.Projects.Any())
            {
                return;
            }
            var projects = new Project[]
            {
                new Project { Name = "Project Calgary", StartDate = DateTime.Parse("2018-01-20"), EndDate = DateTime.Parse("2018-01-30"),
                              ClientId = clients.Single(c => c.Name == "Calgary Flames").ClientId },
                new Project { Name = "Project Vancouver", StartDate = DateTime.Parse("2018-02-20"), EndDate = DateTime.Parse("2018-02-30"),
                              ClientId = clients.Single(c => c.Name == "Vancouver Canucks").ClientId },
                new Project { Name = "Project Winnnipeg", StartDate = DateTime.Parse("2018-03-20"), EndDate = DateTime.Parse("2018-03-30"),
                              ClientId = clients.Single(c => c.Name == "Winnipeg Jets").ClientId }
            };
            foreach (Project p in projects)
            {
                _context.Projects.Add(p);
            }
            _context.SaveChanges();

            if (_context.WorkBreakdownItems.Any())
            {
                return;
            }
            var workBreakdownItems = new WorkBreakdownItem[]
            {
                new WorkBreakdownItem { Description = "Calgary's Finance", EstimatedHours = 50, ActualHours = 20,
                                        ProjectId = projects.Single(p => p.Name == "Project Calgary").ProjectId},
                new WorkBreakdownItem { Description = "Calgary's Management", EstimatedHours = 40, ActualHours = 30,
                                        ProjectId = projects.Single(p => p.Name == "Project Calgary").ProjectId},
                new WorkBreakdownItem { Description = "Vancouver's Finance", EstimatedHours = 50, ActualHours = 20,
                                        ProjectId = projects.Single(p => p.Name == "Project Vancouver").ProjectId},
                new WorkBreakdownItem { Description = "Vancouver's Management", EstimatedHours = 40, ActualHours = 30,
                                        ProjectId = projects.Single(p => p.Name == "Project Vancouver").ProjectId},
                new WorkBreakdownItem { Description = "Winnipeg's Finance", EstimatedHours = 50, ActualHours = 20,
                                        ProjectId = projects.Single(p => p.Name == "Project Winnipeg").ProjectId},
                new WorkBreakdownItem { Description = "Winnipeg's Management", EstimatedHours = 40, ActualHours = 30,
                                        ProjectId = projects.Single(p => p.Name == "Project Winnipeg").ProjectId},
            };
            foreach (WorkBreakdownItem w in workBreakdownItems)
            {
                _context.WorkBreakdownItems.Add(w);
            }
            _context.SaveChanges();

            if (_context.ApplicationUser.Count() != 0)
            {
                return;
            }
            var user = new UserDetail() { FirstName = "Bob", LastName = "Jones", Position = "Junior Developer" };
            _context.UserDetail.Add(user);
            _context.SaveChanges();

            if (_context.Timeslips.Any())
            {
                return;
            }
            var timeslipOne = new Timeslip()
            {
                StartTime = DateTime.ParseExact("2018-04-20 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("2018-04-20 11:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture),
                UserId = user.UserId,
                WorkBreakdownItemId = workBreakdownItems.Single(w => w.Description == "Calgary's Finance").WorkBreakdownItemId
            };
            _context.Timeslips.Add(timeslipOne);
            _context.SaveChanges();
        }
    }
}
