using Solution.Services.Books;
using Solution.Services.Bookshelf;
using Solution.Services.Users;

namespace Solution
{
    class Program
    {
        static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddSingleton<BooksService>();
            builder.Services.AddSingleton<BookshelfsService>();
            builder.Services.AddSingleton<UsersService>();

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

