using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Persistence;
using UserManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "User Management API",
            Version = "v1",
            Description = "API برای مدیریت کاربران",
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
