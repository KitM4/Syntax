using Syntax.Domain.Models;
using Syntax.Data.Database;
using Syntax.Application.Services;
using Syntax.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SyntaxDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
    })
    .AddEntityFrameworkStores<SyntaxDbContext>().AddDefaultTokenProviders();

//builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

WebApplication app = builder.Build();

// TODO: refactoring this code
if (args.Length > 0 && args[0] == "db-rebuild")
    DbInitializer.RebuildDatabase(app.Services.CreateScope());

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}");

app.Run();