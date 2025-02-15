using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Enums;
using TravelAgency.Domain.Identity;
using TravelAgency.Repository.Implementation;
using TravelAgency.Repository.Interface;
using TravelAgency.Services.Implementation;
using TravelAgency.Services.Interface;
using TravelAgencyApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<TravelAgencyUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddTransient<ITravelPackageService, TravelPackageService>();
builder.Services.AddTransient<IAccommodationService, AccommodationService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<IArtistsService, ArtistService>();

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    var roleManager 
        = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Basic" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));            
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManager
        = scope.ServiceProvider.GetRequiredService<UserManager<TravelAgencyUser>>();

    string email = "admin@admin.com";
    string password = "Test1234,";
    if(await userManager.FindByEmailAsync(email) == null)
    {
        var user = new TravelAgencyUser();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "Admin";
        user.LastName = "Admin"; 

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}
app.Run();


