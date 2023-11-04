using Microsoft.AspNetCore.Identity;
using TodoList.Models.Enums;

namespace TodoAppBlazor.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<Entities.User> passwordHasher = new PasswordHasher<Entities.User>();
        public async Task SeedAsync(TodoListDbContext context,ILogger<TodoListDbContextSeed> Ilogger) { 
            if(!context.Users.Any())
            {
                var user = new Entities.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "Admin1@gmail.com",
                    PhoneNumber = "032132131",
                    UserName = "Admin",
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);
            }
            if (!context.Tasks.Any())
            {
                var task = new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same task 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.high,
                    Status = Status.Open
                };
                context.Tasks.Add(task);
            }
            await context.SaveChangesAsync();
        }
    }
}
