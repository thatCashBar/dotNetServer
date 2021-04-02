using Microsoft.EntityFrameworkCore;

namespace CheckpointWebAPI.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
            //Stuff
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}