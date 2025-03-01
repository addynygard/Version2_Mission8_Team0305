using Microsoft.EntityFrameworkCore;
using Version2_Mission8_Team0305.Models;
using Version2_Mission8_Team0305.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Db connection
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskDb")));

// ✅ Register the ITaskRepository with TaskRepository for Dependency Injection
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Seed categories on startup
using (var scope = app.Services.CreateScope()) 
{
    var context = scope.ServiceProvider.GetRequiredService<TaskContext>();

    // Ensure database is created before seeding
    context.Database.EnsureCreated();

    // Check if the Categories table exists before seeding
    if (!context.Categories.Any())
    {
        context.Categories.AddRange(
            new Category { Name = "Work" },
            new Category { Name = "Home" },
            new Category { Name = "School" },
            new Category { Name = "Church" }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();