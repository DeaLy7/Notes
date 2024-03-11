using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Notes.BusinessLogic.Interfaces;
using Notes.BusinessLogic.Services;
using Notes.ConsoleApp.Controllers;
using Notes.Controllers;
using Notes.DataAccess.Data.Models;
using Notes.DataAccess.Interfaces;
using Notes.DataAccess.Repositories;
using System.Runtime.CompilerServices;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services
       .AddTransient<INoteRepository, NoteRepository>()
       .AddTransient<IUserRepository, UserRepository>()
       .AddTransient<IUserService, UserService>()
       .AddTransient<INoteService, NoteService>()       
       .AddDbContext<NotesDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen ();
               
var app = builder.Build();


app.Run();
