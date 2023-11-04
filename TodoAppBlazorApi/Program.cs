using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoAppBlazor.Api.Data;
using TodoAppBlazor.Api.Respositories;
using TodoList.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddDbContext<TodoListDbContext>(option =>
option.UseSqlServer(configuration.GetConnectionString("TodoListDbContext")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITaskRespository, TaskRespository>();

var app = builder.Build();

app.MigrateDbContext<TodoListDbContext>(async (context, services) =>
{
    var logger = services.GetService<ILogger<TodoListDbContextSeed>>();
    new TodoListDbContextSeed().SeedAsync(context,logger);
}
);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
