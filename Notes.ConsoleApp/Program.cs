using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.BusinessLogic.Services;
using Notes.ConsoleApp.Controllers;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Repositories;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Notes.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<NotesDbContext>();
            dbContextOptionsBuilder.UseSqlite(connectionString);

            var dbContext = new NotesDbContext(dbContextOptionsBuilder.Options);
            var pankRepository = new PankRepository(dbContext);
            var pankService = new PankService(pankRepository);
            var pankController = new PankControllers(pankService);
            Note test;
            bool Exit = false;

            
            while (!Exit) 
            {
                Console.WriteLine("# # # # # Notes App # # # # #");
                Console.WriteLine("1 - View Notes | 2 - Create Note | 3 - Update Note | 4 - Delete Note | 0 - Exit");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (number)
                {
                    case 1:
                        Console.WriteLine("# # # # # Notes App # # # # # ");
                        Console.WriteLine("Your notes:\r\n- - - - - - - - - - - -");
                        var note = pankController.GetAllNotes();
                        if (note != null)
                        {
                           foreach (var n in note.ToList())
                           {
                                Console.WriteLine($"Id: {n.Id} \r\nTitle: {n.Title}\r\nContent: {n.Content}\r\n - - - - - - - - - - - -");
                           }
                           
                        }else
                        {
                            Console.WriteLine("Заметки не найдены");
                        }
                        Console.Write("Success\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("# # # # # Notes App # # # # # \r\nCreating new note:");
                        Console.Write("Title: ");
                        string? title = Console.ReadLine();
                        Console.Write("Content: ");
                        string? content = Console.ReadLine();
                        test = new Note {Title = title, Content = content };
                        pankController.AddNote(test);
                        Console.Write("Success\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("# # # # # Notes App # # # # # \r\nUpdating note:");
                        pankController.GetAllNotes();
                        Console.Write("Напишите Id заметки, чтобы её изменить: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var noteFind = pankController.GetNoteById(id);
                        if (noteFind != null)
                        {
                            noteFind.Title = Console.ReadLine();
                            noteFind.Content = Console.ReadLine();
                           pankController.UpdateNote(noteFind);
                            
                        }
                        Console.Write("Success\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("# # # # # Notes App # # # # # \r\nDeleting note:");
                        pankController.GetAllNotes();
                        Console.Write("Напишите Id заметки, чтобы её удалить: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        noteFind = pankController.GetNoteById(id);
                        if (noteFind != null)
                        { 
                            pankController.RemoveNote(noteFind);
                            
                        }
                        Console.Write("Success\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 0:
                        Exit = true;
                        break;

                }

            }
         






        }




        
    }
}
