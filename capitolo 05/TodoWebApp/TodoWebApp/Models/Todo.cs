using System.ComponentModel.DataAnnotations;

namespace TodoWebApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        //[Display(Name = "Titolo dell'attività")]
        public string Titolo { get; set; }

        
        public string Descrizione { get; set; }
        
        [Display(Name = "Data di promemoria")]
        [DisplayFormat( DataFormatString= "{0:d}")]
        [DataType(DataType.DateTime)]
        public DateTime? Promemoria { get; set; }
        
        public bool Completato { get; set; }

        public string Categoria { get; set; }
    }

    public class CategoryService
    {
        public List<string> GetCategories()
        {
            return new List<string>() { "Rosso", "Giallo", "Verde" };
        }

    }


}
