var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Request route match -> Home");
    });

    endpoints.MapGet("test1", async context =>
    {
        await context.Response.WriteAsync("Request route match -> test1");
    });

    endpoints.MapGet("{first}/{second}", async context =>
    {
        await context.Response.WriteAsync("Request route match -> {first}/{second}");
        await context.Response.WriteAsync(Environment.NewLine);
        foreach (var part in context.Request.RouteValues)
        {
            await context.Response
                .WriteAsync($"{part.Key}: {part.Value}\n");
        }
    });

    endpoints.MapFallback(async context =>
    {
        await context.Response.WriteAsync("no pattern match");
    });
});



//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
