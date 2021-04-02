using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CheckpointWebAPI.Models;

namespace CheckpointWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoItemsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GetToDoItems()
        {
            Console.WriteLine("HttpGet");
            return await _context.ToDoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDTO>> GetToDoItem(long id)
        {
            var todoItem = await _context.ToDoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return ItemToDTO(todoItem);
        }

        // PUT: api/ToDoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(long id, ToDoItemDTO toDoItemDTO)
        {
            if (id != toDoItemDTO.Id)
            {
                return BadRequest();
            }
            var todoItem = await _context.ToDoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            //todoItem.Name = toDoItemDTO.Name;
            //todoItem.IsComplete = toDoItemDTO.IsComplete;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ToDoItemExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> PostToDoItem(ToDoItemDTO toDoItemDTO)
        {
            var todoItem = new ToDoItem
            {
                //Id = toDoItem.Id,
                Owner = toDoItemDTO.Owner,
                Year = toDoItemDTO.Year,
                Make = toDoItemDTO.Make,
                Model = toDoItemDTO.Model,
                Color = toDoItemDTO.Color,
                Price = toDoItemDTO.Price,
                User = toDoItemDTO.User,
                Img = toDoItemDTO.Img,
            };
            _context.ToDoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetToDoItems),
                new { id = todoItem.Id },
                ItemToDTO(todoItem));
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(long id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ToDoItemExists(long id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }

        private static ToDoItemDTO ItemToDTO(ToDoItem toDoItem) =>
        new ToDoItemDTO
        {
            Id = toDoItem.Id,
            Owner = toDoItem.Owner,
            Year = toDoItem.Year,
            Make = toDoItem.Make,
            Model = toDoItem.Model,
            Color = toDoItem.Color,
            Price = toDoItem.Price,
            User = toDoItem.User,
            Img = toDoItem.Img,
        };
    }
}
