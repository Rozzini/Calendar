using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendar.Models;
using calendar.Repo;
using Microsoft.EntityFrameworkCore;

namespace calendar.Repo
{
    public class Repository : IRepository
    {
        private readonly CalendarContext appDbContext;

        public Repository(CalendarContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ProjectCard> AddProject(ProjectCard projectCard)
        {
            var result = await appDbContext.ProjectCards.AddAsync(projectCard);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteProject(int projectID)
        {
            var result = await appDbContext.ProjectCards.FirstOrDefaultAsync(x => x.ID == projectID);
            if (result != null)
            {
                appDbContext.ProjectCards.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<ProjectCard> GetNonPromotedProjects()
        {
            return appDbContext.ProjectCards.Where(x => x.Promoted == false);
        }

        public async Task<ProjectCard> GetProjectByID(int projectID)
        {
            return await appDbContext.ProjectCards.FirstOrDefaultAsync(x => x.ID == projectID);
        }

        public IEnumerable<ProjectCard> GetPromotedProjects()
        {
            return appDbContext.ProjectCards.Where(x => x.Promoted == true);
        }

        public async Task<IEnumerable<ProjectCard>> GetProjectCards()
        {
            return await appDbContext.ProjectCards.ToListAsync();
        }
    }
}
