using Notes.DataAccess.Data.Models;

namespace Notes.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User LogIn(User user);
    }
}
