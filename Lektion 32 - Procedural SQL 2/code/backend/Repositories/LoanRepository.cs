using Solution.Contexts;
using Solution.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Solution.Repositories
{
    public class LoansRepository : IGenericRepostirory<LoanModel>
    {
        private readonly LibraryContext _context;

        public LoansRepository(LibraryContext context)
        {
            _context = context;
        }

        public void CreateEntry(LoanModel model)
        {
            _context.Loans.Add(model);
            _context.SaveChanges();
        }

        public LoanModel? GetEntry(params object[] keyValues)
        {
            return _context.Loans.Find(keyValues);
        }

        public List<LoanModel> GetEntries()
        {
            return _context.Loans.ToList();
        }

        public void UpdateEntry(LoanModel newModel)
        {
            _context.Loans.Update(newModel);
            _context.SaveChanges();
        }

        public void DeleteEntry(LoanModel model)
        {
            _context.Loans.Remove(model);
            _context.SaveChanges();
        }

        public List<UserLoanViewModel> GetLoansByUser(int userId)
        {
            return _context.UserLoans
                .Where(l => l.UserId == userId)
                .ToList();
        }

        public int CreateLoan(LoanModel loanModel)
        {
            using var connection = _context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using var command = connection.CreateCommand();
            command.CommandText = "CreateLoan";
            command.CommandType = CommandType.StoredProcedure;

            var pUserId = command.CreateParameter();
            pUserId.ParameterName = "p_UserId";
            pUserId.Value = loanModel.UserId;
            command.Parameters.Add(pUserId);

            var pBookId = command.CreateParameter();
            pBookId.ParameterName = "p_BookId";
            pBookId.Value = loanModel.BookId;
            command.Parameters.Add(pBookId);

            var pCopyNumber = command.CreateParameter();
            pCopyNumber.ParameterName = "p_CopyNumber";
            pCopyNumber.Value = loanModel.CopyNumber;
            command.Parameters.Add(pCopyNumber);

            var pLoanDate = command.CreateParameter();
            pLoanDate.ParameterName = "p_LoanDate";
            pLoanDate.Value = loanModel.LoanDate;
            command.Parameters.Add(pLoanDate);

            var pReturnDate = command.CreateParameter();
            pReturnDate.ParameterName = "p_ReturnDate";
            pReturnDate.Value = loanModel.ReturnDate;
            command.Parameters.Add(pReturnDate);

            var pLoanCount = command.CreateParameter();
            pLoanCount.ParameterName = "p_LoanCount";
            pLoanCount.DbType = DbType.Int32;
            pLoanCount.Direction = ParameterDirection.Output;
            command.Parameters.Add(pLoanCount);

            command.ExecuteNonQuery();

            return Convert.ToInt32(pLoanCount.Value);
        }
    }
}