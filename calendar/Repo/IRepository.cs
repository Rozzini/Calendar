using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendar.Models;

namespace calendar.Repo
{
    public interface IRepository
    {
        Task<IEnumerable<ProjectCard>> GetProjectCards();

        IEnumerable<ProjectCard> GetPromotedProjects();

        IEnumerable<ProjectCard> GetNonPromotedProjects();

        IEnumerable<ProjectCard> GetListedProjects();

        IEnumerable<ProjectCard> GetUpcomingProjects();

       void SetListed(int projectID);

        void RemoveListed(int projectID);

        void SetPromoted(int projectID);

        void RemovePromoted(int projectID);

        Task<ProjectCard> GetProjectByID(int projectID);

        Task<ProjectCard> AddProject(ProjectCard projectCard);

        void UpdateProject(ProjectCard projectCard, int projectID);

        Task DeleteProject(int projectID);

        void AddUser(User user);

        Task DeleteUser(int userID);
    }
}
