using Microsoft.EntityFrameworkCore;
using StaffManagement.DataAccess;
using StaffManagement.DataAccess.Models;
using StaffManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<IStaffRepository, SqlserverStaffRepository>();
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StaffDb")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseMvcWithDefaultRoute();

app.UseStaticFiles();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
