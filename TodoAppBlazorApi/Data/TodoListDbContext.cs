using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoAppBlazor.Api.Entities;
using Task = TodoAppBlazor.Api.Entities.Task;

namespace TodoAppBlazor.Api.Data
{
    public class TodoListDbContext : IdentityDbContext<User,Role,Guid>
    {
        public TodoListDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
