using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace livecode.Migrations
{
    /// <inheritdoc />
    public partial class spAddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"
            CREATE PROCEDURE AddUser(IN p_id INT, IN p_name VARCHAR(100))
                BEGIN
                    INSERT INTO Users (id, name)
                    VALUES (p_id, p_name);
                END;
            ";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
