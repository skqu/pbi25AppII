using Livecode.Model;
using Livecode.Dtos;
using Livecode.Repositories.UserRepository;
using Livecode.Contexts;

namespace Livecode.Service
{
    public class UsersService
    {
        private readonly UserContext _userContext;
        private readonly UserRepository _repository;

        public UsersService()
        {
            _userContext = new UserContext();
            _repository = new UserRepository(_userContext);
        }

        public void AddUser(UserDto userDto)
        {
            UserModel user = new UserModel
            {
                Name = userDto.Name,
                Id = userDto.Id
            };

            _repository.Add(user);
        }

        public List<UserDto> GetUsers()
        {
            List<UserDto> users = new List<UserDto>();
            List<UserModel> usersModels = _repository.GetUsers();

            foreach (UserModel userModel in usersModels)
            {
                UserDto tmp = new UserDto{Name = userModel.Name, Id = userModel.Id};
                users.Add(tmp);
            }

            return users;
        }

        public UserDto GetUser(byte userId)
        {
            UserModel userModel = _repository.Get(userId);
            UserDto user = new UserDto
            {
                Name = userModel.Name,
                Id = userModel.Id
            };

            return user;
        }

        public void PrintUser(byte userId)
        {
            Console.WriteLine(_repository.Get(userId).Name);
        }
    }
}