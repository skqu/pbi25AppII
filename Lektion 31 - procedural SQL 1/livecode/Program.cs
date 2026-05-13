using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

string connectionString = @"Server=localhost; User ID=root; Database=livecode_demostration";

builder.Services.AddDbContext<Context>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();
    context.Users.Add(new UserModel { Name = "Stefan" });
    context.SaveChanges();

    using var connection = context.Database.GetDbConnection();

    if (connection.State != ConnectionState.Open)
    {
        connection.Open();
    }

    using var command = connection.CreateCommand();
    command.CommandText = "AddUser";
    command.CommandType = CommandType.StoredProcedure;

    var pUserId = command.CreateParameter();
    pUserId.ParameterName = "p_id";
    pUserId.Value = 10;
    command.Parameters.Add(pUserId);

    var pBookId = command.CreateParameter();
    pBookId.ParameterName = "p_name";
    pBookId.Value = "Not Stefan";
    command.Parameters.Add(pBookId);

    command.ExecuteNonQuery();
}




app.Run();
