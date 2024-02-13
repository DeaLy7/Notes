using Microsoft.EntityFrameworkCore;
using Notes.BusinessLogic.Interfaces;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;

namespace Notes.BusinessLogic.Services
{
    public class NoteService : INoteService
    {
       
            private readonly INoteRepository _noteRepository;
            public NoteService(INoteRepository context)
            {
                _noteRepository = context;
            }
            public void AddNote(Note note)
            {
                _noteRepository.AddNote(note);
            }
            public void RemoveNote(Note note)
            {
                _noteRepository.RemoveNote(note);
            }
            public void UpdateNote(Note note)
            {
                _noteRepository.UpdateNote(note);
            }
            public Note? GetNoteById(int id)
            {
                return _noteRepository.GetNoteById(id);
            }
            public List<Note> GetAllNotes(int userId)
            {
                return _noteRepository.GetAllNotes(userId);
            }
    }
}
