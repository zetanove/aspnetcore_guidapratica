var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Ciao mondo!");

app.MapGet("/info", 
    () => "Worker Process Name: "+
        System.Diagnostics.Process.GetCurrentProcess().ProcessName);


app.Run();
