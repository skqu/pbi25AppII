using Code.Services;

namespace Code
{
    class Program
    {
        static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddSingleton<PostService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapControllers();


            app.Run();


        }
    }    
}
