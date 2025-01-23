using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace TodoApi.Tests
{
    public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly WebApplicationFactory<Program> _factory;

        public IntegrationTestBase(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
    }

    public class TodoApiTests : IntegrationTestBase
    {
        public TodoApiTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task GetTodos_ShouldReturn200OK()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/todo");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNull();
        }

        [Fact]
        public async Task AddTodo_ShouldReturn201Created()
        {
            // Arrange
            var client = _factory.CreateClient();
            var todoItem = new { Name = "New Task", IsCompleted = false };

            // Act
            var content = new StringContent(JsonSerializer.Serialize(todoItem), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/todo", content);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var content2 = await response.Content.ReadAsStringAsync();
            content2.Should().Contain("New Task");
        }

        [Fact]
        public async Task UpdateTodo_ShouldReturn204NoContent()
        {
            // Arrange
            var client = _factory.CreateClient();
            var updatedTodo = new { Id = 1, Name = "Updated Task", IsCompleted = true };

            // Act
            var content = new StringContent(JsonSerializer.Serialize(updatedTodo), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/todo/1", content);            

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteTodo_ShouldReturn204NoContent()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync("/api/todo/1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

    }
}
