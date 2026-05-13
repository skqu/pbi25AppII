using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace solution.Migrations
{
    /// <inheritdoc />
    public partial class trigger_PreventDoubleLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string sp = @"

                DROP TRIGGER IF EXISTS PreventDoubleLoan;

                CREATE TRIGGER PreventDoubleLoan

                BEFORE INSERT ON Loans

                FOR EACH ROW

                BEGIN

                IF EXISTS (

                    SELECT 1 FROM Loans

                    WHERE BookId = NEW.BookId

                    AND CopyNumber = NEW.CopyNumber

                ) THEN

                    SIGNAL SQLSTATE '45000'

                    SET MESSAGE_TEXT = 'Book copy is already loaned';

                END IF;

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
