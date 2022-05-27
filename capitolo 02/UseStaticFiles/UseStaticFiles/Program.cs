/*
 * ASP.NET Core - Guida Pratica
 *
 * Author: Antonio Pelleriti
 * Esempio uso file statici
 * Apri /immagine.jpg nel browser per visualizzare immagine
 */

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.Run();
