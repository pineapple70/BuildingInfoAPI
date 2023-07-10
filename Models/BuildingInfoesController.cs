using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildingInfoAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingInfoesController : ControllerBase
    {
        private readonly BuildingContext _context;

        public BuildingInfoesController(BuildingContext context)
        {
            _context = context;
        }

        // GET: api/BuildingInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingInfo>>> GetBuildingInfos()
        {
          if (_context.BuildingInfo == null)
          {
              return NotFound();
          }
            return await _context.BuildingInfo.ToListAsync();
        }

        // GET: api/BuildingInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingInfo>> GetBuildingInfo(long id)
        {
          if (_context.BuildingInfo == null)
          {
              return NotFound();
          }
            var buildingInfo = await _context.BuildingInfo.FindAsync(id);

            if (buildingInfo == null)
            {
                return NotFound();
            }

            return buildingInfo;
        }

        // PUT: api/BuildingInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingInfo(long id, BuildingInfo buildingInfo)
        {
            if (id != buildingInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(buildingInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingInfoExists(id))
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

        // POST: api/BuildingInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingInfo>> PostBuildingInfo(BuildingInfo buildingInfo)
        {
          if (_context.BuildingInfo == null)
          {
              return Problem("Entity set 'BuildingContext.BuildingInfos'  is null.");
          }
            _context.BuildingInfo.Add(buildingInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingInfo", new { id = buildingInfo.Id }, buildingInfo);
        }

        // DELETE: api/BuildingInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingInfo(long id)
        {
            if (_context.BuildingInfo == null)
            {
                return NotFound();
            }
            var buildingInfo = await _context.BuildingInfo.FindAsync(id);
            if (buildingInfo == null)
            {
                return NotFound();
            }

            _context.BuildingInfo.Remove(buildingInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingInfoExists(long id)
        {
            return (_context.BuildingInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
