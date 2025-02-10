using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Liberation.Models;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context
builder.Services.AddDbContext<LiberationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services and configure Identity options
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<LiberationDbContext>()
    .AddDefaultTokenProviders();
// Register your polling service as a background service
// builder.Services.AddHostedService<DatabasePollerService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.LoginPath = "/Auth/Login"; // Adjust as needed
    options.LogoutPath = "/Auth/Logout"; // Adjust as needed
    options.AccessDeniedPath = "/Auth/AccessDenied"; // Adjust as needed
    options.SlidingExpiration = true;
});

// Register HttpClient
builder.Services.AddHttpClient();

// Register your custom API service
builder.Services.AddScoped<IMyApiService, MyApiService>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    _ = app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

  

// Define routing to the Views from the Controller Actions
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    

    _ = endpoints.MapControllerRoute(
        name: "liberation",
        pattern: "liberation",
        defaults: new { controller = "Home", action = "Liberation" });

    _ = endpoints.MapControllerRoute(
        name: "home_notes",
        pattern: "home/Notes",
        defaults: new { controller = "Home", action = "Notes" });

    _ = endpoints.MapControllerRoute(
        name: "note_create",
        pattern: "note/Create",
        defaults: new { controller = "Note", action = "Create" });

    _ = endpoints.MapControllerRoute(
        name: "note_edit",
        pattern: "note/Edit",
        defaults: new { controller = "Note", action = "Edit" });

    _ = endpoints.MapControllerRoute(
        name: "note_index",
        pattern: "note/Index",
        defaults: new { controller = "Note", action = "Index" });

    _ = endpoints.MapControllerRoute(
        name: "home_auth",
        pattern: "home/Auth",
        defaults: new { controller = "Home", action = "Auth" });

    _ = endpoints.MapControllerRoute(
        name: "auth_login",
        pattern: "Auth/Login",
        defaults: new { controller = "Auth", action = "Login" });

    _ = endpoints.MapControllerRoute(
        name: "auth_logout",
        pattern: "Auth/Logout",
        defaults: new { controller = "Auth", action = "Logout" });

    _ = endpoints.MapControllerRoute(
        name: "auth_register",
        pattern: "Auth/Register",
        defaults: new { controller = "Auth", action = "Register" });

    _ = endpoints.MapControllerRoute(
        name: "auth_proof",
        pattern: "Auth/Proof",
        defaults: new { controller = "Auth", action = "Proof" });

    _ = endpoints.MapControllerRoute(
        name: "home_API",
        pattern: "Home/API",
        defaults: new { controller = "Home", action = "API" });

    _ = endpoints.MapControllerRoute(
        name: "API_Index",
        pattern: "API/Index",
        defaults: new { controller = "API", action = "Index" });

    _ = endpoints.MapControllerRoute(
        name: "API_ById",
        pattern: "API/ById",
        defaults: new { controller = "API", action = "ById" });

    _ = endpoints.MapControllerRoute(
        name: "API_ByName",
        pattern: "API/ByName",
        defaults: new { controller = "API", action = "ByName" });

        _ = endpoints.MapControllerRoute(
        name: "Home_Audible",
        pattern: "Home/Audible",
        defaults: new { controller = "Home", action = "Audible" });

        
        _ = endpoints.MapControllerRoute(
        name: "Home_Lingual",
        pattern: "Home/Lingual",
        defaults: new { controller = "Home", action = "Lingual" });

        _ = endpoints.MapControllerRoute(
        name: "Lingual_Python",
        pattern: "Lingual/Python",
        defaults: new { controller = "Lingual", action = "Python" });

        _ = endpoints.MapControllerRoute(
        name: "Lingual_CSharp",
        pattern: "Lingual/CSharp",
        defaults: new { controller = "Lingual", action = "CSharp" });

        _ = endpoints.MapControllerRoute(
        name: "Lingual_JS",
        pattern: "Lingual/JS",
        defaults: new { controller = "Lingual", action = "JS" });

        _ = endpoints.MapControllerRoute(
        name: "Lingual_Typescript",
        pattern: "Lingual/Typescript",
        defaults: new { controller = "Lingual", action = "Typescript" });

     _ = endpoints.MapControllerRoute(
        name: "Home_Data",
        pattern: "Home/Data",
        defaults: new { controller = "Home", action = "Data" });

     _ = endpoints.MapControllerRoute(
        name: "Data_Analyze",
        pattern: "Data/Analyze",
        defaults: new { controller = "Data", action = "Analyze" });

      _ = endpoints.MapControllerRoute(
        name: "Data_DataPing",
        pattern: "Data/DataPing",
        defaults: new { controller = "Data", action = "DataPing" });
});

app.Run();
