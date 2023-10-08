using AnyoneForTennis.Data;
using AnyoneForTennis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>() // Add role services.
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

// Seed roles before startup.
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Coach", "Member" };

    foreach (var role in roles)
    {
        // Check if roles have already been created to avoid recreating them upon startup.
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// Seed the default admin , members and coaches accounts.
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string name = "Admin";
    string email = "admin@anyonefortennis.com";
    string password = "Admin123!";

    // Check if the default admin exists to avoid recreating it upon startup.
    if (await userManager.FindByEmailAsync(email) == null)
    {
        // Create a new user.
        var user = new ApplicationUser();
        user.FirstName = name;
        user.LastName = name;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);

        // Assign the new user to the admin role.
        await userManager.AddToRoleAsync(user, "Admin");
    }

    string role = "Member";

    for (int i = 1; i <= 10; i++)
    {
         name = $"Member{i}"; // Change the member's name
         email = $"member{i}@anyonefortennis.com"; // Change the email
         password = $"Member{i}123!"; // Change the password

        // Check if the member already exists to avoid recreating it upon startup.
        if (await userManager.FindByEmailAsync(email) == null)
        {
            // Create a new user.
            var user = new ApplicationUser();
            user.FirstName = name;
            user.LastName = name;
            user.UserName = email;
            user.Email = email;
            user.EmailConfirmed = true;

            await userManager.CreateAsync(user, password);

            // Assign the new user to the "Members" role.
            await userManager.AddToRoleAsync(user, role);
        }
    }

    role = "Coach";
    for (int i = 1; i <= 10; i++)
    {
        name = $"Coach {i}"; // Change the Coaches name
        email = $"coach{i}@anyonefortennis.com"; // Change the email
        password = $"Coach{i}123!"; // Change the password

        // Check if Coach already exists to avoid recreating it upon startup.
        if (await userManager.FindByEmailAsync(email) == null)
        {
            // Create a new user.
            var user = new ApplicationUser();
            user.FirstName = name;
            user.LastName = name;
            user.UserName = email;
            user.Email = email;
            user.EmailConfirmed = true;
            user.Biography = $"I am a coach with {i} years of experience.";
            await userManager.CreateAsync(user, password);

            // Assign the new user to the "Coaches" role.
            await userManager.AddToRoleAsync(user, role);
        }
    }

}
AppDbInitializer.Seed(app);
app.Run();
