using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//���U Hangfire�åB�ϥΰO����O�s�Ƶ{�A
//�w�]�ҤU���� HangFire�M��i�H�ϥ� sqlserver�A�i�z�L config.UseSqlServerStorage();�A���ݭn�]�w
builder.Services.AddHangfire(ConfigurationBinder =>
{
    ConfigurationBinder.UseInMemoryStorage();
});
//���Uhangfire�n�ϥΪ����A���A���A���N�O�W���Ҽg���ϥΰO�������A��
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

//�ϥ�hangfire���ت�����O
app.UseHangfireDashboard();

app.MapControllers();

app.Run();
