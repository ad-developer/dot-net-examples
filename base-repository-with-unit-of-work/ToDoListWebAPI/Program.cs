using Microsoft.EntityFrameworkCore;
using ToDoListWebAPI.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddTransient<IToDoListDbContext, ToDoListDbContext>();
builder.Services.AddDbContext<ToDoListDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/todolist/gettodolist", (IToDoListRepository repository) =>
{
   
    return repository.GetAll();
})
.WithName("GEtToDoList");

app.MapGet("/todolist/gettodoitem/{id}", (int id, IToDoListRepository repository) =>
{
    return repository.GetById(id);
})
.WithName("GetToDoItem");

app.Run();