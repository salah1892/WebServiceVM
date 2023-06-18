using WebVM.WebAPI.Controllers;
using WebVM.WebAPI.Hubs;

namespace WebVM.WebAPI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add services to the container
            builder.Services.AddScoped<PayementHubController>();
            builder.Services.AddControllers();
            builder.Services.AddSignalR();

            //-------Service Cors Policy-----------------------------------------------------------//
            builder.Services.AddCors(options =>
            {
                //options.AddDefaultPolicy("ClientPermission", policy =>
                options.AddPolicy("ClientPermission", policy =>
                {
                    // policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    policy.AllowAnyHeader()
                    .AllowAnyMethod().
                    WithOrigins("http://localhost:3000/").
                    AllowCredentials();
                });
            });
            //------------------------------------------------------------------//
            var app = builder.Build();
            //Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //--------------//
            app.MapControllers();
            app.UseCors("ClientPermission");
            //--------------//
            app.UseEndpoints(endpoints =>
            {
                app.MapControllers();
                endpoints.MapHub<PayementHub>("/PayementOperation");
                endpoints.MapHub<ParametreHub>("/ParametreOperation");
            });
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
//policy.AllowAnyHeader();
//policy.WithOrigins("http://localhost:3000/");
//policy.WithOrigins("https://localhost:7036/");
//policy.AllowAnyMethod();
//policy.AllowCredentials();
//policy.AllowAnyOrigin();