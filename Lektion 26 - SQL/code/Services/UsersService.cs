using Code.Dtos;
using Code.Models;
using Code.Repositories;

namespace Code.Services
{
    public class UsersService
    {
        private readonly UserRepository _userRepo;

        public UsersService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void NewUser(UsersDto user)
        {
            UserModel userModel = new UserModel
            {
                Name = user.Name,
                Id = user.Id,
                Created = DateTime.Now
            };

            _userRepo.Add(userModel);
        }

        public UsersDto? GetUser(byte userId)
        {
            UserModel? userModel = _userRepo.GetById(userId);
            UsersDto? user = new UsersDto();
            
            
            if (userModel != null)
            {
                user.Name = userModel.Name;
                user.Id = userModel.Id;
            }else
            {
                user = null;
            }

            return user;
        }

        public void Remove(byte userId)
        {
            _userRepo.Remove(userId);
        }
    }
}