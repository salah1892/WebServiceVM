using Microsoft.EntityFrameworkCore;
using WebServiceVM.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//ADD ContactsAPIDbContext to the dependency injection Services
//builder.Services.AddDbContext<VMDbContext>(
//    options => options.UseMySQL(
//        builder.Configuration.GetConnectionString("WebServiceVMConnectionStrings")));
builder.Services.AddDbContext<VMDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("WebServiceVMConnectionStrings")));
//builder.Services.AddDbContext<VMDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
