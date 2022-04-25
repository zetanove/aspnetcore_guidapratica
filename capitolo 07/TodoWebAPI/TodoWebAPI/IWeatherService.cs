namespace TodoWebAPI
{
    public interface IWeatherService{
        public WeatherForecast Create(DateTime d);
    }

    public class WeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast Create(DateTime date)
        {
            var obj = new WeatherForecast
            {
                Date = date,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
            return obj;
        }
    }
}
