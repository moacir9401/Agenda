using Agenda.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(databaseName: "Usuarios"));
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(databaseName: "Contatos"));
builder.Services.AddControllersWithViews();

var app = builder.Build();
 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
