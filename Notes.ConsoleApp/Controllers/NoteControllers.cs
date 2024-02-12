using Microsoft.EntityFrameworkCore;
using Notes.BusinessLogic.Interfaces;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;
using Notes.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.ConsoleApp.Controllers
{
    public class NoteControllers
    {
        private readonly INoteService _pankService;
        public NoteControllers (INoteService pankService)
        {
            _pankService = pankService;
        }

        public void AddNote(Note note) 
        {
            _pankService.AddNote(note);
        }
        
        public void RemoveNote(Note note) 
        {
            _pankService.RemoveNote(note);
        }

        public void UpdateNote(Note note) 
        {
            _pankService.UpdateNote(note);
        }
        public Note? GetNoteById(int id)
        {
            return _pankService.GetNoteById(id);
        }
        public List<Note> GetAllNotes(int userId)
        {
            return _pankService.GetAllNotes(userId);
        }
        public void CreateUser(User user)
        {
            _pankService.CreateUser(user);
        }
        public List<User> GetAllUsers()
        {
            return _pankService.GetAllUsers();
        }
        public User LogIn(User user)
        {
            return _pankService.LogIn(user);
        }
    }
}
