using Notes.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DataAccess.Interfaces
{
    public interface INoteRepository
    {
        void AddNote(Note note);
        void RemoveNote(Note note);
        void UpdateNote(Note note);
        Note? GetNoteById(int id);
        List <Note> GetAllNotes(int userId);
        void CreateUser (User user);
        List<User> GetAllUsers();
        User LogIn(User user);
    }
    
}
