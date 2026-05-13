using Microsoft.AspNetCore.Mvc;
using Solution.Dtos.Loans;
using Solution.Dtos.Users;
using Solution.Services.Users;

namespace Solution.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _service;

        public UsersController(UsersService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserRequestDto user)
        {
            _service.NewUser(user);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody] UserRequestDto user)
        {
            _service.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(int userId)
        {
            _service.DeleteUser(userId);
            return Ok();
        }

        [HttpGet("{userId}")]
        public ActionResult<UserRespondDto> GetUser(int userId)
        {
            return Ok(_service.GetUser(userId));
        }

        [HttpPost("loan")]
        public ActionResult LoanBook([FromBody] LoanRequestDto loan)
        {
            string status = _service.LoanBook(loan);
            return Ok(status);
        }

        [HttpGet("{UserId}/loans")]
        public ActionResult UserLoans(int userId)
        {
            List<LoanRespondDto> loans = _service.GetLoansById(userId);
            return Ok(loans);
        }

        [HttpDelete("loan")]
        public ActionResult ReturnBook([FromBody] LoanRequestDto loan)
        {
            _service.ReturnBook(loan);
            return Ok();
        }
    }
}