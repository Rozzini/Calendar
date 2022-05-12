using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using calendar;
using calendar.Models;
using calendar.Repo;

namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCardsController : ControllerBase
    {
        private IRepository _repository;

        public ProjectCardsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ProjectCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectCard>>> GetProjectCards()
        {
            return Ok(await _repository.GetProjectCards());
        }

        // GET: api/ProjectCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCard>> GetProjectCard(int id)
        {
            return await _repository.GetProjectByID(id);
        }

        // POST: api/ProjectCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectCard>> PostProjectCard(ProjectCard projectCard)
        {
            return await _repository.AddProject(projectCard);
        }

        // DELETE: api/ProjectCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectCard>> DeleteProjectCard(int id)
        {
            await _repository.DeleteProject(id);
            return Ok();
        }


    }
}

/*

        IEnumerable<ProjectCard> GetPromotedProjects();

        IEnumerable<ProjectCard> GetNonPromotedProjects();

        IEnumerable<ProjectCard> GetListedProjects();

        IEnumerable<ProjectCard> GetUpcomingProjects();

       void SetListed(int projectID);

        void RemoveListed(int projectID);

        void SetPromoted(int projectID);

        void RemovePromoted(int projectID);

        void UpdateProject(ProjectCard projectCard, int projectID);

        void AddUser(User user);

        Task DeleteUser(int userID);
*/