using Microsoft.EntityFrameworkCore;

namespace BlazorAppWebAssembly1
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Todos);
            base.OnModelCreating(modelBuilder);
        }
    }

}
