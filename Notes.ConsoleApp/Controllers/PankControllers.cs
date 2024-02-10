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
    public class PankControllers
    {
        private readonly IPankService _pankService;
        public PankControllers (IPankService pankService)
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
        public List<Note> GetAllNotes()
        {
            return _pankService.GetAllNotes();
        }

    }
}
