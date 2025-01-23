
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddScoped<ITodoService, TodoService>(); // Register the service

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();     
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5097); // HTTP
    options.ListenAnyIP(7097, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS
    });
});
var app = builder.Build();
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }