var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
            name: "home",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });


app.Run();
    