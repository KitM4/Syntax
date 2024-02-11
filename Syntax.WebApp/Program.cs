using Syntax.Data.Database;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SyntaxDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

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