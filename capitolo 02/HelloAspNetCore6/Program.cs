/*
 * ASP.NET Core - Guida Pratica
 *
 * Author: Antonio Pelleriti
 * Esempio web app Razor Pages
 * Apri /info nel browser per endpoint personalizzato
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/info", async context =>
        {
            await context.Response.WriteAsync("Worker Process Name : " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
        });
    });
}


app.Run();
