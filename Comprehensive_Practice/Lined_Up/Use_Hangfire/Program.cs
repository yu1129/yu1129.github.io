using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//註冊 Hangfire並且使用記憶體保存排程，
//預設所下載的 HangFire套件可以使用 sqlserver，可透過 config.UseSqlServerStorage();，但需要設定
builder.Services.AddHangfire(ConfigurationBinder =>
{
    ConfigurationBinder.UseInMemoryStorage();
});
//註冊hangfire要使用的伺服器，伺服器就是上面所寫的使用記憶體當伺服器
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//使用hangfire內建的儀表板
app.UseHangfireDashboard();

app.MapControllers();

app.Run();
