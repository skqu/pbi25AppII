using Solution.Dtos;
using Solution.Models;
using Solution.Repositories;

namespace Solution.Services
{
    public class UserService
    {
        private UserRepositories _userRepo = new UserRepositories();
        
        public void NewUser(UserDto userDto)
        {
            UserModel userModel = new UserModel
            {
                Name = userDto.Name,
                Id = userDto.Id
            };
            _userRepo.Add(userModel);
        }

        public void RemoveUser(byte userId)
        {
            _userRepo.Remove(userId);
        }

        public UserDto? GetUser(byte userId)
        {
            UserModel? user = _userRepo.Get(userId);
            if ( user == null)
            {
                return null;
            }

            return new UserDto
            {
                Name = user.Name,
                Id = user.Id
            };
        }

    }
}