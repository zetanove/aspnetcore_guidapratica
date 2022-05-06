using TodoWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:TodoDbContext"]);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PolicyCF", policy => policy.RequireClaim("CodiceFiscale", "PLLNTN12D18Z112I"));
    options.AddPolicy("Administrator", policy => policy.Add("Administrator"));
    options.AddPolicy("MinimimOrders", policy => policy.AddRequirements(new MinimumOrdersRequirement(1000)))
});


builder.Services.AddDefaultIdentity<Utente>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

}).AddEntityFrameworkStores<TodoDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


public class MinimumOrdersRequirement : IAuthorizationRequirement
{
    public MinimumOrdersRequirement(int minimum) =>
        Minimum = minimum;

    public int Minimum { get; }
}

public class MinimumOrdersHandler : AuthorizationHandler<MinimumOrdersRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, MinimumOrdersRequirement requirement)
    {
        var user = context.User;
        var ordini = 1000; //calcola a partire da User
        if (ordini >= requirement.Minimum)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}