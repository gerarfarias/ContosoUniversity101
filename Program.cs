using ContosoUniversity101.Data;
using ContosoUniversity101.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseInMemoryDatabase("ContosoUniversityDB"));

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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    // Seed minimal data
    if (!context.Students.Any())
    {
        context.Students.AddRange(
            new Student { FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2023-09-01") },
            new Student { FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2024-01-15") },
            new Student { FirstName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2022-08-23") }
        );
    }
    if (!context.Courses.Any())
    {
        context.Courses.AddRange(
            new Course { Title = "Chemistry", Credits = 3 },
            new Course { Title = "Microeconomics", Credits = 4 },
            new Course { Title = "Macroeconomics", Credits = 4 }
        );
    }
    context.SaveChanges();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
