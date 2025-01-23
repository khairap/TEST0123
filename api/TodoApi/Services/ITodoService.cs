using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        Task<TodoItem> CreateTodoItemAsync(TodoItem item);
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync(bool? isCompleted = null);
        Task<TodoItem> GetTodoItemByIdAsync(int id);
        Task<bool> UpdateTodoItemAsync(int id, TodoItem updatedItem);
        Task<bool> DeleteTodoItemAsync(int id);
    }
}
