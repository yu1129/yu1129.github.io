using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
builder.Services.AddControllersWithViews();

services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration["MongoDB_HP"]));
services.AddScoped<IMongoDatabase>(provider => provider.GetRequiredService<IMongoClient>().GetDatabase("testdb"));

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
