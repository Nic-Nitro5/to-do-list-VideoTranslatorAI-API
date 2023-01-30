using Microsoft.EntityFrameworkCore;
using todo_list_api.Models.Entities;

namespace todo_list_api.Data
{
    public class TodoDBContext: DbContext
    {
        public TodoDBContext(DbContextOptions options): base(options)
        {
        }

        // DBSet
        public DbSet<User> users { get; set; }
        public DbSet<Todo> todos { get; set; }
    }
}
