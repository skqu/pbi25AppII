using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace solution.Migrations
{
    /// <inheritdoc />
    public partial class view_UserLoans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
            DROP VIEW IF EXISTS UserLoans;
            CREATE VIEW UserLoans AS
                SELECT 
                    l.BookId,
                    l.CopyNumber,
                    u.Name, 
                    l.UserId
                FROM Loans l
                JOIN Users u ON l.UserId = u.UserId;
            ";

            migrationBuilder.Sql(sp);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS UserLoans;");
        }
    }
}
