using Notes.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User LogIn(User user);
    }
}
