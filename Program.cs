using Microsoft.EntityFrameworkCore;
using Liberation.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LiberationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


    app.UseEndpoints(endpoints =>
    {
        _ = endpoints.MapControllerRoute(
            name: "liberation",
            pattern: "liberation",
            defaults: new { controller = "Home", action = "Liberation" });

         _ = endpoints.MapControllerRoute(
            name: "home_notes",
            pattern: "home/Notes",
            defaults: new { controller = "Home", action = "Notes" });


        _ = endpoints.MapControllerRoute(
            name: "note_Create",
            pattern: "note/Create",
            defaults: new { controller = "Note", action = "Create" }
        );

         _ = endpoints.MapControllerRoute(
            name: "note_edit",
            pattern: "note/edit",
            defaults: new { controller = "Note", action = "Edit" }
        );
            
                     _ = endpoints.MapControllerRoute(
            name: "note_index",
            pattern: "Note/Index",
            defaults: new { controller = "Note", action = "Index" });
            
             _ = endpoints.MapControllerRoute(
            name: "home",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });


app.Run();
    