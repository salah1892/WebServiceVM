 using WebApplication2.Hubs;

var builder = WebApplication.CreateBuilder(args);

//add sefvice to the container
builder.Services.AddSignalR();
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

//app.MapHub<PayementHub>("/");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<PayementHub>("/PayementOperation");
});
//app.MapGet("/", () => "Hello World!");

app.Run();
