using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using calendar;
using calendar.Models;

namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCardsController : ControllerBase
    {
        private readonly CalendarContext _context;

        public ProjectCardsController(CalendarContext context)
        {
            _context = context;
        }

        // GET: api/ProjectCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectCard>>> GetProjectCards()
        {
            return await _context.ProjectCards.ToListAsync();
        }

        // GET: api/ProjectCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCard>> GetProjectCard(int id)
        {
            var projectCard = await _context.ProjectCards.FindAsync(id);

            if (projectCard == null)
            {
                return NotFound();
            }

            return projectCard;
        }

        // PUT: api/ProjectCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectCard(int id, ProjectCard projectCard)
        {
            if (id != projectCard.ID)
            {
                return BadRequest();
            }

            _context.Entry(projectCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectCard>> PostProjectCard(ProjectCard projectCard)
        {
            _context.ProjectCards.Add(projectCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectCard", new { id = projectCard.ID }, projectCard);
        }

        // DELETE: api/ProjectCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectCard>> DeleteProjectCard(int id)
        {
            var projectCard = await _context.ProjectCards.FindAsync(id);
            if (projectCard == null)
            {
                return NotFound();
            }

            _context.ProjectCards.Remove(projectCard);
            await _context.SaveChangesAsync();

            return projectCard;
        }

        private bool ProjectCardExists(int id)
        {
            return _context.ProjectCards.Any(e => e.ID == id);
        }
    }
}
