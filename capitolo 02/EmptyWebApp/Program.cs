/*
 * ASP.NET Core - Guida Pratica
 *
 * Author: Antonio Pelleriti
 * Esempio empty web app
 * Apri /info nel browser 
 */

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/info", 
    () => "Worker Process Name: "+
        System.Diagnostics.Process.GetCurrentProcess().ProcessName+
        Environment.NewLine+"Environment: " + app.Environment.EnvironmentName);


app.Run();
