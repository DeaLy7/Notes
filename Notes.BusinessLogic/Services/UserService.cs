using Notes.BusinessLogic.Interfaces;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;
using Notes.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository context)
        {
            _userRepository = context;
        }
        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public User LogIn(User user)
        {
            return _userRepository.LogIn(user);
        }
    }
}
