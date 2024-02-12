using Notes.DataAccess.Data.Models;

namespace Notes.BusinessLogic.Interfaces
{
    public interface INoteService
    {
        void AddNote(Note note);
        void RemoveNote(Note note);
        void UpdateNote(Note note);
        Note? GetNoteById(int id);
        List<Note> GetAllNotes(int userId);
        void CreateUser(User user);
        List<User> GetAllUsers();
        User LogIn(User user);
    }
}
