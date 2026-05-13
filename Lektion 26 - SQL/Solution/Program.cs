using Solution.Services;

namespace Solution
{
    class Program
    {
        static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddScoped<UserService>();

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

