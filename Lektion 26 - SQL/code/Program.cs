using Code.Services;
using Code.Context;
using Code.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddOpenApi();
            builder.Services.AddControllers();

            builder.Services.AddDbContext<UserContext>(options =>
                options.UseInMemoryDatabase("users.db"));

            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<UsersService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapControllers();

            app.Run();
        }
    }
}