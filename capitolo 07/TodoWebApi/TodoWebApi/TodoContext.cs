using Microsoft.EntityFrameworkCore;
using TodoWebApi.Models;

namespace TodoWebApi
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
            modelBuilder.Entity<Todo>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Todos)
                .HasForeignKey(c => c.IDCategoria);


            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Todos);
            base.OnModelCreating(modelBuilder);
        }
    }
}
