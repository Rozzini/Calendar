using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace calendar
{
    public class CalendarContext : DbContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ProjectCard> ProjectCards { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Calendar; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=True");
            }
        }

    }
}
