using Notes.DataAccess.Data.Models;

namespace Notes.BusinessLogic.Interfaces
{
    public interface IPankService
    {
        void AddNote(Note note);
        void RemoveNote(Note note);
        void UpdateNote(Note note);
        Note? GetNoteById(int id);
        List<Note> GetAllNotes();
    }
}
