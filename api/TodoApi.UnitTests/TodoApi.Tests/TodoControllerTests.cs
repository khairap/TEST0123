using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Services;
using Xunit;

namespace TodoApi.Tests
{
    public class TodoControllerTests
    {
        private readonly Mock<ITodoService> _mockService;
        private readonly TodoController _controller;

        public TodoControllerTests()
        {
            _mockService = new Mock<ITodoService>();
            _controller = new TodoController(_mockService.Object);
        }

        [Fact]
        public async Task GetTodoItems_ShouldReturnOkResult_WithListOfTodos()
        {
            // Arrange
            var todos = new List<TodoItem>
            {
                new TodoItem { Id = 1, Name = "Task 1", IsCompleted = false },
                new TodoItem { Id = 2, Name = "Task 2", IsCompleted = true }
            };
            _mockService.Setup(s => s.GetTodoItemsAsync(null)).ReturnsAsync(todos);

            // Act
            var result = await _controller.GetTodoItems();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTodos = Assert.IsType<List<TodoItem>>(okResult.Value);
            Assert.Equal(2, returnedTodos.Count);
        }

        [Fact]
        public async Task GetTodoItem_ShouldReturnOkResult_WhenItemExists()
        {
            // Arrange
            var todo = new TodoItem { Id = 1, Name = "Task 1", IsCompleted = false };
            _mockService.Setup(s => s.GetTodoItemByIdAsync(1)).ReturnsAsync(todo);

            // Act
            var result = await _controller.GetTodoItem(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTodo = Assert.IsType<TodoItem>(okResult.Value);
            Assert.Equal(todo.Id, returnedTodo.Id);
        }

        [Fact]
        public async Task GetTodoItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            _mockService.Setup(s => s.GetTodoItemByIdAsync(1)).ReturnsAsync((TodoItem)null);

            // Act
            var result = await _controller.GetTodoItem(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateTodoItem_ShouldReturnCreatedAtActionResult_WhenItemIsCreated()
        {
            // Arrange
            var newTodo = new TodoItem { Id = 1, Name = "New Task", IsCompleted = false };
            _mockService.Setup(s => s.CreateTodoItemAsync(newTodo)).ReturnsAsync(newTodo);

            // Act
            var result = await _controller.CreateTodoItem(newTodo);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedTodo = Assert.IsType<TodoItem>(createdResult.Value);
            Assert.Equal(newTodo.Id, returnedTodo.Id);
            Assert.Equal(newTodo.Name, returnedTodo.Name);
        }

        [Fact]
        public async Task UpdateTodoItem_ShouldReturnNoContent_WhenItemIsUpdated()
        {
            // Arrange
            var updatedTodo = new TodoItem { Id = 1, Name = "Updated Task", IsCompleted = true };
            _mockService.Setup(s => s.UpdateTodoItemAsync(1, updatedTodo)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateTodoItem(1, updatedTodo);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateTodoItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var updatedTodo = new TodoItem { Id = 1, Name = "Updated Task", IsCompleted = true };
            _mockService.Setup(s => s.UpdateTodoItemAsync(1, updatedTodo)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateTodoItem(1, updatedTodo);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteTodoItem_ShouldReturnNoContent_WhenItemIsDeleted()
        {
            // Arrange
            _mockService.Setup(s => s.DeleteTodoItemAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTodoItem(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTodoItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            _mockService.Setup(s => s.DeleteTodoItemAsync(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteTodoItem(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
