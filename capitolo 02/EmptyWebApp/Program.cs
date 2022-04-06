var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/info", 
    () => "Worker Process Name: "+
        System.Diagnostics.Process.GetCurrentProcess().ProcessName+
        Environment.NewLine+"Environment: " + app.Environment.EnvironmentName);


app.Run();
