using JeverlyStore.DAL;
using JewerlyStore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection=builder.Configuration.GetConnectionString("Host=localhost;Port=5432;Database=JewerlyStore;Username=postgres;password=123456");
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.InitializerServices();
builder.Services.InitializerRepozitories();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();