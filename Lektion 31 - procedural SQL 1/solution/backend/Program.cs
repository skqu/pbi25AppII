using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Solution.Contexts;
using Solution.Repositories;
using Solution.Services.Books;
using Solution.Services.Bookshelf;
using Solution.Services.Users;

namespace Solution
{
    static class Solution
    {
        static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            string connectionString =  @"Server=localhost; User ID=root; Database=solution_procedural";

            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddScoped<BooksService>();
            builder.Services.AddScoped<BookshelfsService>();
            builder.Services.AddScoped<UsersService>();
            builder.Services.AddScoped<BooksRepository>();
            builder.Services.AddScoped<BooksCopyRepository>();
            builder.Services.AddScoped<BookshelfsRepository>();
            builder.Services.AddScoped<UsersRepository>();
            builder.Services.AddScoped<LoansRepository>();
            builder.Services.AddScoped<UsersService>();
            // dotnet add package Polemo.EntityFrameworkCore.MySql
            // dotnet add package Microsoft.EntityFrameworkCore.Design
            // When context is created run: 
            // - dotnet ef migrations add InitialCreate
            // - dotnet ef database update
            // You should now be able to see the tables in phpmyadmin
            // Redo dotnet ef migrations add "Comment" after each context change. 
            builder.Services.AddDbContext<LibraryContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}

