using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using WebApplication1.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<PersonService>();
builder.Services.AddControllers().AddNewtonsoftJson(); 

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) 
    ));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();  




app.Run();



