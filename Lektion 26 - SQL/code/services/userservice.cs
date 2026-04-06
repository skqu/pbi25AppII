using code.dto;
using code.model;
using code.repository.user;

namespace code.services.user
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(UserDto createUserDto)
        {
            string[] parts = createUserDto.FullName.Trim().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            string firstName = parts.Length > 0 ? parts[0] : "";
            string surName = parts.Length > 1 ? parts[1] : "";

            UserModel userModel = new UserModel
            {
                Name = firstName,
                SurName = surName,
                Mail = createUserDto.Mail,
                CreatedAt = DateTime.UtcNow
            };

            UserModel createdUser = await _userRepository.CreateUserAsync(userModel);

            return new UserDto
            {
                Id = createdUser.Id,
                FullName = $"{createdUser.Name} {createdUser.SurName}".Trim(),
                Mail = createdUser.Mail
            };
        }

        public async Task<UserDto?> GetUserAsync(int id)
        {
            UserModel? userModel = await _userRepository.GetUserByIdAsync(id);

            if (userModel == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = userModel.Id,
                FullName = $"{userModel.Name} {userModel.SurName}".Trim(),
                Mail = userModel.Mail
            };
        }
    }
}