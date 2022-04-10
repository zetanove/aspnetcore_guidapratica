namespace ActionResults.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public DateTime Promemoria { get; set; }
        public bool Completato { get; set; }

        public Todo(string titolo, string desc, DateTime prom)
        {
            Titolo = titolo;
            Descrizione = desc;
            Promemoria = prom;
        }
    }

}
