using System.ComponentModel.DataAnnotations;
namespace TodoWebApp.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Inserisci il nome utente")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Inserisci il nome utente")]

        public string? Password { get; set; }
    }
}
