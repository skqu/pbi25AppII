using Solution.Dtos.Loans;
using Solution.Dtos.Users;
using Solution.Models;
using Solution.Repositories;

namespace Solution.Services.Users
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepo;
        private readonly BooksCopyRepository _bookCopiesRepo;
        private readonly LoansRepository _loansRepo;

        public UsersService(
            UsersRepository usersRepo,
            BooksCopyRepository bookCopiesRepo,
            LoansRepository loansRepo)
        {
            _usersRepo = usersRepo;
            _bookCopiesRepo = bookCopiesRepo;
            _loansRepo = loansRepo;
        }

        public void NewUser(UserRequestDto userDto)
        {
            UserModel userModel = new UserModel
            {
                UserId = userDto.UserId,
                Name = userDto.Name,
                Mail = userDto.Mail,
                Title = userDto.Title
            };

            _usersRepo.CreateEntry(userModel);
        }

        public void UpdateUser(UserRequestDto userDto)
        {
            UserModel? userModel = _usersRepo.GetEntries().Find(
                u => u.UserId == userDto.UserId
            );

            if (userModel == null)
            {
                return;
            }

            userModel.Name = userDto.Name;
            userModel.Mail = userDto.Mail;
            userModel.Title = userDto.Title;

            _usersRepo.UpdateEntry(userModel);
        }

        public void DeleteUser(int userId)
        {
            UserModel? userModel = _usersRepo.GetEntries().Find(
                u => u.UserId == userId
            );

            if (userModel == null)
            {
                return;
            }

            bool hasLoans = _loansRepo.GetEntries().Any(
                l => l.UserId == userId
            );

            if (hasLoans)
            {
                return;
            }

            _usersRepo.DeleteEntry(userModel);
        }

        public UserRespondDto GetUser(int userId)
        {
            UserRespondDto rtnUser = new UserRespondDto();

            UserModel? userModel = _usersRepo.GetEntries().Find(
                u => u.UserId == userId
            );

            if (userModel == null)
            {
                return rtnUser;
            }

            rtnUser.UserId = userModel.UserId;
            rtnUser.Name = userModel.Name;
            rtnUser.Mail = userModel.Mail;
            rtnUser.Title = userModel.Title;

            foreach (LoanModel loan in _loansRepo.GetEntries().FindAll(
                l => l.UserId == userId))
            {
                rtnUser.Loans.Add(new LoanRespondDto
                {
                    UserId = loan.UserId,
                    BookId = loan.BookId,
                    CopyNumber = loan.CopyNumber,
                    LoanDate = loan.LoanDate,
                    ReturnDate = loan.ReturnDate
                });
            }

            return rtnUser;
        }

        public void LoanBook(LoanRequestDto loanDto)
        {
            UserModel? userModel = _usersRepo.GetEntries().Find(
                u => u.UserId == loanDto.UserId
            );

            BooksCopyModel? bookCopyModel = _bookCopiesRepo.GetEntries().Find(
                b => b.BookId == loanDto.BookId &&
                     b.CopyNumber == loanDto.CopyNumber
            );

            if (userModel == null || bookCopyModel == null)
            {
                return;
            }

            bool isAlreadyLoaned = _loansRepo.GetEntries().Any(
                l => l.BookId == loanDto.BookId &&
                     l.CopyNumber == loanDto.CopyNumber
            );

            if (isAlreadyLoaned)
            {
                return;
            }


            LoanModel loanModel = new LoanModel
            {
                UserId = loanDto.UserId,
                BookId = loanDto.BookId,
                CopyNumber = loanDto.CopyNumber,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                User = userModel,
                BookCopy = bookCopyModel
            };



            _loansRepo.CreateEntry(loanModel);
        }

        public void ReturnBook(LoanRequestDto loanDto)
        {
            LoanModel? loanModel = _loansRepo.GetEntries().Find(
                l => l.UserId == loanDto.UserId &&
                     l.BookId == loanDto.BookId &&
                     l.CopyNumber == loanDto.CopyNumber
            );

            if (loanModel == null)
            {
                return;
            }

            _loansRepo.DeleteEntry(loanModel);
        }
    }
}