using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.BusinessLogic.Interfaces;
using Notes.BusinessLogic.Services;
using Notes.ConsoleApp.Controllers;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;
using Notes.DataAccess.Repositories;

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
            var noteRepository = new NoteRepository(dbContext);
            var noteService = new NoteService(noteRepository);
            
            
            var userRepository = new UserRepository(dbContext);
            var userService = new UserService(userRepository);

             IServiceProvider GetServiceProvider()
             {
                IServiceCollection services = new ServiceCollection()
               .AddTransient<INoteRepository, NoteRepository>()
               .AddTransient<IUserRepository, UserRepository>()
               .AddTransient<IUserService, UserService>()
               .AddTransient<INoteService, NoteService>()
               .AddTransient<NoteControllers>()
               .AddTransient<UserControllers>()
               .AddDbContext<NotesDbContext>(options => options.UseSqlite(connectionString));
                using ServiceProvider serviceProvider = services.BuildServiceProvider();
            
                return services.BuildServiceProvider();
             }
            
            var serviceProvider = GetServiceProvider();
            var userController = serviceProvider.GetRequiredService<UserControllers>();
            var noteController = serviceProvider.GetRequiredService<NoteControllers>();

            Note note = new();
            User user = new();
            bool Exit = false;
            while (!Exit)
            {
                if (user.Id == 0)
                {
                    Console.WriteLine("1 - Sign in | 2 - Sign up | 3 - Exit ");

                    int menu = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (menu)
                    {
                        case 1:
                            Console.WriteLine("# # # # # Sign in # # # # # \r\nWrite a login and password:");

                            Console.Write("Login: ");
                            user.UserName = Console.ReadLine();
                            Console.Write("Password: ");
                            user.Password = Console.ReadLine();
                            user = userController.LogIn(user);
                            Console.Clear();


                            break;
                        case 2:
                            Console.WriteLine("# # # # # Sign up # # # # # \r\nCreating new account:");
                            Console.Write("Login: ");
                            string? userName = Console.ReadLine();
                            Console.Write("Password: ");
                            string? newpassword = Console.ReadLine();
                            user = new User { UserName = userName, Password = newpassword };
                            userController.CreateUser(user);
                            Console.Write("Success\n");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            Exit = true;
                            break;

                    }

                }
                if (user.Id != 0)
                {


                    Console.WriteLine("# # # # # Notes App # # # # #");
                    Console.WriteLine("1 - View Notes | 2 - Create Note | 3 - Update Note | 4 - Delete Note | 5 - Log out | 0 - Exit");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (number)
                    {
                        case 1:
                            Console.WriteLine("# # # # # Notes App # # # # # ");
                            Console.WriteLine("Your notes:\r\n- - - - - - - - - - - -");
                            var noteList = noteController.GetAllNotes(user.Id);
                            if (noteList != null)
                            {
                                foreach (var n in noteList.ToList())
                                {
                                    Console.WriteLine($"Id: {n.Id} \r\nTitle: {n.Title}\r\nContent: {n.Content}\r\n - - - - - - - - - - - -");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Заметки не найдены");
                            }
                            Console.Write("Success\n");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("# # # # # Notes App # # # # # \r\nCreating new note:");
                            note = new Note();
                            Console.Write("Title: ");
                            note.Title = Console.ReadLine();
                            Console.Write("Content: ");
                            note.Content = Console.ReadLine();
                            note.UserId = user.Id;
                            noteController.AddNote(note);
                            Console.Write("Success\n");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("# # # # # Notes App # # # # # \r\nUpdating note:");


                            if (noteController.GetNoteById != null)
                            {
                                Console.WriteLine("У вас нет записей, чтобы их редактировать");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            }
                            else
                            {
                                foreach (var n in noteController.GetAllNotes(user.Id).ToList())
                                {
                                    Console.WriteLine($"Id: {n.Id} \r\nTitle: {n.Title}\r\nContent: {n.Content}\r\n - - - - - - - - - - - -");
                                }
                            }
                            Console.Write("Напишите Id заметки, чтобы её изменить: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var noteFind = noteController.GetNoteById(id);
                            if (noteFind != null)
                            {
                                noteFind.Title = Console.ReadLine();
                                noteFind.Content = Console.ReadLine();
                                noteController.UpdateNote(noteFind);

                            }
                            Console.Write("Success\n");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            Console.WriteLine("# # # # # Notes App # # # # # \r\nDeleting note:");
                            noteController.GetAllNotes(user.Id);
                            if (noteController.GetNoteById == null)
                            {
                                Console.WriteLine("У вас нет записей для удаления");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            }
                            else
                            {
                                foreach (var n in noteController.GetAllNotes(user.Id).ToList())
                                {
                                    Console.WriteLine($"Id: {n.Id} \r\nTitle: {n.Title}\r\nContent: {n.Content}\r\n - - - - - - - - - - - -");
                                    Console.WriteLine();
                                }
                            }
                            Console.Write("Напишите Id заметки, чтобы её удалить: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            noteFind = noteController.GetNoteById(id);
                            if (noteFind != null)
                            {
                                noteController.RemoveNote(noteFind);

                            }
                            Console.Write("Success\n");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 5:
                            user.Id = 0;
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
}
