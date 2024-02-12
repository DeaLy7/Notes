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
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _context;
        public NoteRepository (NotesDbContext context)
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
        public List<Note> GetAllNotes(int userId)
        {
            return _context.Notes.Where(u=> u.UserId == userId) .ToList();
        }
        
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public User LogIn(User user)
        {
            
            return _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        }

    }
}
