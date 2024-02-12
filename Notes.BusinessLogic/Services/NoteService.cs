using Microsoft.EntityFrameworkCore;
using Notes.BusinessLogic.Interfaces;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;

namespace Notes.BusinessLogic.Services
{
    public class NoteService : INoteService
    {
       
            private readonly INoteRepository _pankRepository;
            public NoteService(INoteRepository context)
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
            public List<Note> GetAllNotes(int userId)
            {
                return _pankRepository.GetAllNotes(userId);
            }

            public void CreateUser(User user)
            {
                _pankRepository.CreateUser(user);
            }
            public List<User> GetAllUsers()
            {
            return _pankRepository.GetAllUsers();
            }
            public User LogIn(User user)
            {
            return _pankRepository.LogIn(user);
            }

    }
}
