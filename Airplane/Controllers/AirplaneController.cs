using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirplaneCore.Infrastructure;
using AirplaneCore.Models;

namespace AirplaneCore.Controllers
{
    [Route("api/[controller]")]
    public class AirplaneController : Controller
    {
        private readonly Context context;

        public AirplaneController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await context.Airplane.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var existingItem = await context.Airplane.FindAsync(id);

            if (existingItem == null)
            {
                return NotFound();

            }
            return Ok(existingItem);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(int id, [FromBody] Airplane itemToUpdate)
        {
            var existingItem = await context.Airplane.SingleOrDefaultAsync((System.Linq.Expressions.Expression<System.Func<Airplane, bool>>)(i => i.Id == id));
            if (existingItem == null)
            {
                return NotFound(new { Message = $"Item with id {id} not found" });
            }

            existingItem.Model = itemToUpdate.Model;
            existingItem.Passengers = itemToUpdate.Passengers;
            existingItem.CreationDate = itemToUpdate.CreationDate;

            this.context.Airplane.Update((Airplane)existingItem);

            await this.context.SaveChangesAsync();
            return Ok(existingItem);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] Airplane item)
        {
            var itemToCreate = new Airplane
            {
                Model = item.Model,
                Passengers = item.Passengers,
                CreationDate = item.CreationDate,
            };
            context.Airplane.Add(itemToCreate);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = itemToCreate.Id }, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var existingItem = await context.Airplane.SingleOrDefaultAsync((System.Linq.Expressions.Expression<System.Func<Airplane, bool>>)(x => x.Id == id));
            if (existingItem == null)
            {
                return NotFound();
            }

            context.Airplane.Remove(existingItem);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
