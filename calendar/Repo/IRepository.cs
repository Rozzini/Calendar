using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendar.Models;

namespace calendar.Repo
{
    interface IRepository
    {
        Task<IEnumerable<ProjectCard>> GetProjectCards();

        IEnumerable<ProjectCard> GetPromotedProjects();

        IEnumerable<ProjectCard> GetNonPromotedProjects();

        Task<ProjectCard> GetProjectByID(int projectID);

        Task<ProjectCard> AddProject(ProjectCard projectCard);

        void DeleteProject(int projectID);
    }
}
