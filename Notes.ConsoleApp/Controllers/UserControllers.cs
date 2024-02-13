using Notes.BusinessLogic.Interfaces;
using Notes.DataAccess.Data.Models;

namespace Notes.ConsoleApp.Controllers
{
    public class UserControllers
    {
        private readonly IUserService _userService;
        public UserControllers(IUserService userService)
        {
            _userService = userService;
        }

        public void CreateUser(User user)
        {
            _userService.CreateUser(user);
        }
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
        public User LogIn(User user)
        {
            return _userService.LogIn(user);
        }
    }
}
