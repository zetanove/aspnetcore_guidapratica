using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoWebApi.Models
{
    [Table("Todo")]
    public class Todo
    {
        [Key]
        [Column("IDTodo")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Titolo obbligatorio")]
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

    public class Utente
    {
        [Key]
        public int IDUtente { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}
