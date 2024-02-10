using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DataAccess.Repositories
{
    public class PankRepository : IPankRepository
    {
        private readonly NotesDbContext _context;
        public PankRepository (NotesDbContext context)
        {
            _context = context;
        }
        public void AddNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();


        }
        public void RemoveNote (Note note)
        {
            _context.Remove(note);
            _context.SaveChanges();


        }
        public void UpdateNote(Note note)
        {
            _context.Attach(note);
            _context.SaveChanges();


        }
        public Note? GetNoteById (int id)
        {
            return _context.Notes.Find(id);
        }
        public List<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }
       
    }
}
