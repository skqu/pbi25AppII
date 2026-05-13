using Livecode.Service;

namespace Livecode
{
    class Program
    {
        static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddScoped<UsersService>();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
