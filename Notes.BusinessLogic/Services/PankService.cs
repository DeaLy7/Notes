using Microsoft.EntityFrameworkCore;
using Notes.BusinessLogic.Interfaces;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;

namespace Notes.BusinessLogic.Services
{
    public class PankService : IPankService
    {
       
            private readonly IPankRepository _pankRepository;
            public PankService(IPankRepository context)
            {
                _pankRepository = context;
            }
            public void AddNote(Note note)
            {
                _pankRepository.AddNote(note);
            }
            public void RemoveNote(Note note)
            {
                _pankRepository.RemoveNote(note);
            }
            public void UpdateNote(Note note)
            {
                _pankRepository.UpdateNote(note);
            }
            public Note? GetNoteById(int id)
            {
                return _pankRepository.GetNoteById(id);
            }
            public List<Note> GetAllNotes()
            {
                return _pankRepository.GetAllNotes();
            }

    }
}
