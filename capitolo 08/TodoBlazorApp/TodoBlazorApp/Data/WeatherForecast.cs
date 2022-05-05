using System.ComponentModel.DataAnnotations;

namespace TodoBlazorApp.Data
{
    public class WeatherForecast
    {
        [Key]
        public Guid ID;

        [Required(ErrorMessage ="Inserire la data")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Inserire la data")]

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}