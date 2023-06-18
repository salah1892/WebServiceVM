using Microsoft.EntityFrameworkCore;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Hubs;

internal class Program
{
    private static readonly object MyAllows;

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //add sefvice to the container
        builder.Services.AddSignalR();
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //ADD ContactsAPIDbContext to the dependency injection Services
        builder.Services.AddDbContext<VMDbContext>(options =>
        {
            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        });

        //options => options.UseSqlServer(
        //builder.Configuration.GetConnectionString("WebServiceVMConnectionStrings")));
        //builder.Services.AddDbContext<VMDbContext>();
        //-------Service Cors Policy-----------------------------------------------------------//
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        //------------------------------------------------------------------//

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        ////--------------//
        app.UseCors();
        ////--------------//

        app.UseEndpoints(endpoints =>
        {
            app.MapControllers();
            endpoints.MapHub<PayementHub>("/PayementOperation");
            endpoints.MapHub<ParametreHub>("/ParametreOperation");
        });

        //--------------//
        //app.UseCors();
        //--------------//
        app.Run();
    }
}