using Microsoft.EntityFrameworkCore;
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
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory());
    builder.AddJsonFile("appsettings.json");
    return builder.Build();
}

IServiceProvider GetServiceProvider(IConfiguration config)
{
    var connectionString = config.GetConnectionString("DefaultConnection");
    IServiceCollection services = new ServiceCollection()
   .AddTransient<INoteRepository, NoteRepository>()
   .AddTransient<IUserRepository, UserRepository>()
   .AddTransient<IUserService, UserService>()
   .AddTransient<INoteService, NoteService>()
   .AddTransient<NoteControllers>()
   .AddTransient<UsersController>()
   .AddDbContext<NotesDbContext>(options => options.UseSqlite(connectionString));
    services.AddControllers();
    return services.BuildServiceProvider();
}