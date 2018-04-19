using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using core_backend.Models;
using System.ComponentModel.DataAnnotations;

namespace core_backend.Data
{
    public class UserDetail
    {
        [Key]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        //navigation properties
        public virtual ICollection<Timeslip> Timeslips { get; set; }
        // 1 to 1 relationship with ApplicationUser
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class Timeslip
    {
        [Key]
        public int TimeslipId { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WorkBreakdownItemId { get; set; }
        //navigation properties
        public virtual UserDetail UserDetail { get; set; }
        public virtual WorkBreakdownItem WorkBreakdownItem { get; set; }
    }

    public class WorkBreakdownItem
    {
        [Key]
        public int WorkBreakdownItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public int ActualHours { get; set; }
        public int ProjectId { get; set; }
        

        //navigation properties
        public virtual ICollection<Timeslip> Timeslips { get; set; }
        public virtual Project Project { get; set; }
    }

    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //navigation properties
        public virtual ICollection<WorkBreakdownItem> WorkBreakdownItems { get; set; }
        public virtual Client Client { get; set; }

    }

    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public int DeletionStateCode { get; set; }
        public int StateCode { get; set; }

        //navigation properties
        public virtual ICollection<Project> Projects { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Timeslip> Timeslips { get; set; }
        public DbSet<WorkBreakdownItem> WorkBreakdownItems { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Project>()
                .HasOne(c=> c.Client)
                .WithMany(p=> p.Projects)
                .HasForeignKey(fk=> new { fk.ClientId})
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Timeslip>()
               .HasOne(t => t.UserDetail)
               .WithMany(t => t.Timeslips)
               .HasForeignKey(fk => new { fk.UserId })
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkBreakdownItem>()
              .HasOne(w => w.Project)
              .WithMany(w => w.WorkBreakdownItems)
              .HasForeignKey(fk => new { fk.ProjectId })
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Timeslip>()
             .HasOne(t => t.WorkBreakdownItem)
             .WithMany(t => t.Timeslips)
             .HasForeignKey(fk => new { fk.WorkBreakdownItemId})
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
               .HasOne(u => u.UserDetail)
               .WithOne(au => au.ApplicationUser)
               .HasForeignKey<UserDetail>(u => u.UserId);


            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
