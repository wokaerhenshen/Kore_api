using core_backend.Models;
using core_backend.Utility;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public Seeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                new Project { Name = "Project Calgary",
                              StartDate = new DateTime(2018, 01, 20, 01, 01, 01),
                              EndDate =  new DateTime(2018, 01, 30, 02, 02, 02),
                              ClientId = clients.Single(c => c.Name == "Calgary Flames").ClientId },
                new Project { Name = "Project Vancouver",
                              StartDate = new DateTime(2018, 02, 20, 01, 01, 01),
                              EndDate = new DateTime(2018, 02, 27, 02, 02, 02),
                              ClientId = clients.Single(c => c.Name == "Vancouver Canucks").ClientId },
                new Project { Name = "Project Winnipeg",
                              StartDate = new DateTime(2018, 03, 20, 01, 01, 01),
                              EndDate = new DateTime(2018, 03, 30, 02, 02, 02),
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

                var user = new ApplicationUser { UserName = "admin@user.com", Email = "admin@user.com" };
                var result = _userManager.CreateAsync(user, "Bcit123!");
                if (result.IsCompletedSuccessfully)

                {
                    _userManager.AddToRoleAsync(user, StringDirectory.AdminUser);
                    _context.UserDetail.Add(new UserDetail

                    {
                        UserId = user.Id,
                        FirstName = "Karl",
                        LastName = "Xu",
                        Position = "Senior Developer"
                    });

                    _context.SaveChanges();

                }
                var userTwo = new ApplicationUser { UserName = "regular@user.com", Email = "regular@user.com" };
                var resultTwo = _userManager.CreateAsync(userTwo, "Bcit123!"); if (resultTwo.IsCompletedSuccessfully)

                {
                    _userManager.AddToRoleAsync(userTwo, StringDirectory.CustomerUser);
                    _context.UserDetail.Add(new UserDetail

                    {
                        UserId = userTwo.Id,
                        FirstName = "Carolyn",
                        LastName = "Ho",
                        Position = "Consultant"
                    });

                    _context.SaveChanges();

                }

    

            if (_context.Timeslips.Any())
            {
                return;
            }
            var timeslipOne = new Timeslip()
            {
                StartTime = DateTime.ParseExact("2018-04-20 08:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("2018-04-20 11:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                UserId = user.Id,
                WorkBreakdownItemId = workBreakdownItems.Single(w => w.Description == "Calgary's Finance").WorkBreakdownItemId,
                Remarks = "TestRemark",
                Tag = "TestTag"
            };
            _context.Timeslips.Add(timeslipOne);
            _context.SaveChanges();
        }
    }
}
