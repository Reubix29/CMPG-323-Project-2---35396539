using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using CMPG323_35396539_Project_2.Models;
using System.Linq.Expressions;

namespace CMPG323_35396539_Project_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ConnectedOfficeContext _context;

        public CategoriesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        //GET: api/Categories/devices/7

        [HttpGet("devices/{id}")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesInCategory(Guid id)
        {
            var devices = await _context.Device.Where(cat => cat.CategoryId == id).ToListAsync();
            if (devices == null)
            {
                return NotFound();
            }
            return Ok(devices);
        }

        //GET: api/Categories/zones/7
        //Returns the number of zones in each cat

        //[HttpGet("zones/{id}")]
        //public async Task<ActionResult<IEnumerable<Zone>>> GetZonesInCategory(Guid id)
        //{
        //    var zones = await _context.Zone.Join(_context.Device, _context.Zone.CategoryId) .ToListAsync();
        //    if (zones == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(zones);
        //}

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Category.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.CategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        //PATCH: api/Categories/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCategory(Guid id, [FromBody] JsonPatchDocument<Category> patchCategory)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            patchCategory.ApplyTo(category, ModelState);

            return Ok(category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
