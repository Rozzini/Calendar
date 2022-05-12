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

        public async Task DeleteProject(int projectID)
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

        public IEnumerable<ProjectCard> GetListedProjects()
        {
            return appDbContext.ProjectCards.Where(x => x.Listed == true);
        }

        public IEnumerable<ProjectCard> GetUpcomingProjects()
        {
            return appDbContext.ProjectCards.Where(x => x.Listed == false);
        }

        public async void SetListed(int projectID)
        {
            var result = await appDbContext.ProjectCards.FirstOrDefaultAsync(x => x.ID == projectID);
            if (result != null && result.Listed != true)
            {
                result.Listed = true;
                await appDbContext.SaveChangesAsync();
            }
        }

        public async void RemoveListed(int projectID)
        {
            var result = await appDbContext.ProjectCards.FirstOrDefaultAsync(x => x.ID == projectID);
            if (result != null && result.Listed != false)
            {
                result.Listed = false;
                await appDbContext.SaveChangesAsync();
            }
        }

        public async void SetPromoted(int projectID)
        {
            var result = await appDbContext.ProjectCards.FirstOrDefaultAsync(x => x.ID == projectID);
            if (result != null && result.Promoted != true)
            {
                result.Promoted = true;
                await appDbContext.SaveChangesAsync();
            }
        }

        public async void RemovePromoted(int projectID)
        {
            var result = await appDbContext.ProjectCards.FirstOrDefaultAsync(x => x.ID == projectID);
            if (result != null && result.Promoted != false)
            {
                result.Promoted = false;
                await appDbContext.SaveChangesAsync();
            }
        }

        public async void UpdateProject(ProjectCard projectCard, int projectID)
        {
            var PC = await appDbContext.ProjectCards.FirstOrDefaultAsync(x => x.ID == projectID);
            try 
            {
                if (PC != null)
                {
                    PC.Name = projectCard.Name;
                    PC.LaunchDate = projectCard.LaunchDate;
                    PC.Description = projectCard.Description;
                    PC.BlockChain = projectCard.BlockChain;
                    PC.Supply = projectCard.Supply;
                    PC.WhiteListSpots = projectCard.WhiteListSpots;
                    PC.WebSite = projectCard.WebSite;
                    PC.Discord = projectCard.Discord;
                    PC.Twitter = projectCard.Twitter;
                    PC.Inst = projectCard.Inst;
                    PC.Listed = projectCard.Listed;
                    await appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public async void AddUser(User user)
        {
            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int userID)
        {
            var result = await appDbContext.Users.FirstOrDefaultAsync(x => x.ID == userID);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}