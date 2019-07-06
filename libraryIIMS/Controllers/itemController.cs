using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libraryIIMS.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libraryIIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class itemController : ControllerBase
    {
        private readonly libraryIIMSContext _context;

        public itemController(libraryIIMSContext context)
        {
            _context = context;
        }
        
        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Item.ToListAsync();
        }


        // GET api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItems(int id)
        {
            var items = await _context.Item.FindAsync(id);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        // PUT api/Item/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        //POST api/Item/5
        [HttpPost]
        public async Task<ActionResult<Item>> PostItems(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItems", new { id = item.ItemId }, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if(item == null)
            {
                return NotFound();
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }
        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
