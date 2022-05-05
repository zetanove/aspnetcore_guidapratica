using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace TodoBlazorApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {}

        public DbSet<Todo>? Todos { get; set; } 
    }

    [Table("Todo")]
    public class Todo
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Titolo obbligatorio")]
        public string Titolo { get; set; }
        public string? Dettagli { get; set; }
        public DateTime? Promemoria { get; set; }
        public bool Completata { get; set; } = false;
    }


}
