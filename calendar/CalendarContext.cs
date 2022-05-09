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
        }
        public DbSet<ProjectCard> ProjectCards { get; set; }
       
    }
}
