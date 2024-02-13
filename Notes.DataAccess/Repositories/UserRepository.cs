using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;

namespace Notes.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NotesDbContext _context;
        public UserRepository(NotesDbContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public User LogIn(User user)
        {

            return _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        }

    }
}
