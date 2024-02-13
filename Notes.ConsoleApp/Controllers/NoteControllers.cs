using Notes.BusinessLogic.Interfaces;
using Notes.DataAccess.Data.Models;

namespace Notes.ConsoleApp.Controllers
{
    public class NoteControllers
    {
        private readonly INoteService _noteService;
        public NoteControllers(INoteService noteService)
        {
            _noteService = noteService;
        }

        public void AddNote(Note note)
        {
            _noteService.AddNote(note);
        }

        public void RemoveNote(Note note)
        {
            _noteService.RemoveNote(note);
        }

        public void UpdateNote(Note note)
        {
            _noteService.UpdateNote(note);
        }
        public Note? GetNoteById(int id)
        {
            return _noteService.GetNoteById(id);
        }
        public List<Note> GetAllNotes(int userId)
        {
            return _noteService.GetAllNotes(userId);
        } 
    }
}
