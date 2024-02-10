﻿

using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Notes.DataAccess.Data.Models
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } 
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
