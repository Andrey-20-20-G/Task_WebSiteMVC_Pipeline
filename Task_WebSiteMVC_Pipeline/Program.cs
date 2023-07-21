using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task_WebSiteMVC_Pipeline.DAL;
using Task_WebSiteMVC_Pipeline.DAL.Interfaces;
using Task_WebSiteMVC_Pipeline.DAL.Repositories;
using Task_WebSiteMVC_Pipeline.Domain.Entity;
using Task_WebSiteMVC_Pipeline.Service.Implementations;
using Task_WebSiteMVC_Pipeline.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

var connection = builder.Configuration.GetConnectionString("DBCon");

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(connection);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
