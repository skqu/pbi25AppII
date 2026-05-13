using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace solution.Migrations
{
    /// <inheritdoc />
    public partial class spCreateLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
            DROP PROCEDURE IF EXISTS CreateLoan;

            CREATE PROCEDURE CreateLoan(
                IN p_UserId INT,
                IN p_BookId INT,
                IN p_CopyNumber int,
                IN p_LoanDate DATE,
                IN p_ReturnDate DATE,
                OUT p_LoanCount INT
            )
            BEGIN
                -- Insert loan
                INSERT INTO Loan (UserId, BookId, CopyNumber, LoanDate, ReturnDate)
                VALUES (p_UserId, p_BookId, p_CopyNumber, p_LoanDate, p_ReturnDate);

                -- Return number of loans for user
                SELECT COUNT(*)
                INTO p_LoanCount
                FROM Loans
                WHERE UserId = p_UserId;
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
