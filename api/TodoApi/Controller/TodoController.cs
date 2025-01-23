using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem item)
        {
            var createdItem = await _todoService.CreateTodoItemAsync(item);
            return CreatedAtAction(nameof(GetTodoItem), new { id = createdItem.Id }, createdItem);
        }

        // Read (with optional filtering)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems([FromQuery] bool? isCompleted = null)
        {
            var items = await _todoService.GetTodoItemsAsync(isCompleted);
            return Ok(items);
        }

        // Read by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var item = await _todoService.GetTodoItemByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // Update (allows updating flags)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem updatedItem)
        {
            if (!await _todoService.UpdateTodoItemAsync(id, updatedItem))
            {
                return NotFound();
            }

            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            if (!await _todoService.DeleteTodoItemAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
