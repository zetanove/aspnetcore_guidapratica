using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoWebApp.Models
{
    public class TodoDbContext: DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Todos)
            .HasForeignKey(c=>c.IDCategoria);

            modelBuilder.Entity<Todo>()
                .Property(c => c.CreationDate)
                .HasDefaultValueSql("getdate()");
            
            modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Todos);
            base.OnModelCreating(modelBuilder);
        }
    }

    [NotMapped]
    class Fake
    {
        public int ID { get; set; }
    }


    [Table("Todo")]
    public class Todo 
    {
        [Key]
        [Column("IDTodo")]
        public int ID { get; set; }

        [Required(ErrorMessage ="Titolo obbligatorio")]
        public string Titolo { get; set; }
        public string? Dettagli { get; set; }
        public DateTime? Promemoria { get; set; }
        public bool Completata { get; set; } = false;

        
        public int? IDCategoria { get; set; }

        [ForeignKey("IDCategoria")]
        public virtual Categoria? Categoria { get; set; }

        public int? IDUtente { get; set; }

        [ForeignKey("IDUtente")]
        public virtual Utente? Utente { get; set; }

        [NotMapped]
        public DateTime CreationDate { get; set; }
    }


    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }

        [Required(ErrorMessage = "Il nome della categoria è obbligatorio")]
        public string NomeCategoria { get; set; }

        public string? Colore { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }

    public class Utente: IdentityUser
    {
        [Key]
        public int IDUtente { get; set; }


        public virtual ICollection<Todo> Todos { get; set; }
    }

}
