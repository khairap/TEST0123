using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> CreateTodoItemAsync(TodoItem item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync(bool? isCompleted = null)
        {
            var query = _context.TodoItems.AsQueryable();

            if (isCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == isCompleted.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<bool> UpdateTodoItemAsync(int id, TodoItem updatedItem)
        {
            var existingItem = await _context.TodoItems.FindAsync(id);
            if (existingItem == null) return false;

            // Update fields
            existingItem.Name = updatedItem.Name ?? existingItem.Name;
            existingItem.IsCompleted = updatedItem.IsCompleted;

            _context.Entry(existingItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return false;

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
