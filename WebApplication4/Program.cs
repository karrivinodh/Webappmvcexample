using Microsoft.EntityFrameworkCore;
using WebApplication4.DBContext;

var builder = WebApplication.CreateBuilder(args);


string Constr = builder.Configuration.GetConnectionString("MyConStr");
// Add services to the container.
builder.Services.AddDbContext<EmployeeContext>(contextOptions => contextOptions.UseSqlServer(Constr));
builder.Services.AddDbContext<DepartmentDBContext>(contextOptions => contextOptions.UseSqlServer(Constr));
builder.Services.AddDbContext<traineeContext>(contextOptions => contextOptions.UseSqlServer(Constr));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Departments}/{action=Index}/{id?}");

app.Run();
