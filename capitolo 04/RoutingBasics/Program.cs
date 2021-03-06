var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");



app.MapGet("{first}/{second}", async context =>
{
    await context.Response.WriteAsync("Request route match -> {first}/{second}");
    await context.Response.WriteAsync(Environment.NewLine);
    foreach (var part in context.Request.RouteValues)
    {
        await context.Response
            .WriteAsync($"{part.Key}: {part.Value}\n");
    }
}); ;

app.MapGet("/register/{user:alpha:minlength(10)}", (string user) => $"Hello {user}!");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Request route match -> Home");
//    });

//    endpoints.MapGet("test1", async context =>
//    {
//        await context.Response.WriteAsync("Request route match -> test1");
//    });

//    endpoints.MapGet("{first}/{second}", async context =>
//    {
//        await context.Response.WriteAsync("Request route match -> {first}/{second}");
//        await context.Response.WriteAsync(Environment.NewLine);
//        foreach (var part in context.Request.RouteValues)
//        {
//            await context.Response
//                .WriteAsync($"{part.Key}: {part.Value}\n");
//        }
//    });

//    endpoints.MapFallback(async context =>
//    {
//        await context.Response.WriteAsync("no pattern match");
//    });
//});

app.MapFallback(async context => {
    await context.Response.WriteAsync("Nessun altro endpoint ha gestito la richiesta!");
});

app.Run();
