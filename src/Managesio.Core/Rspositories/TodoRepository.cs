using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;

namespace Managesio.Core.Rspositories;

public interface ITodoRepository
{
    public List<Todo> GetTodos();
    public void AddTodo(string title, string note);
}

[RegisterPerRequest]
public class TodoRepository : ITodoRepository
{
    private readonly ApiDbContext _context;
    public TodoRepository(ApiDbContext context)
    {
        _context = context;
    }
    
    public List<Todo> GetTodos()
    {
        var todos = _context.Todos.ToList();
        return todos;
    }

    public void AddTodo(string title, string note)
    {
        var todo = new Todo { Title = title, Note = note };
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }
}