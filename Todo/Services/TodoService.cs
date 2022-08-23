using Microsoft.EntityFrameworkCore;
using Todo.Contexts;
using Todo.DTO;
using Todo.Models;

namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly DataContext _context;

        public TodoService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllTodos()
        {
            var todos = await _context.TodoItems
                .OrderBy(o => o.IsCompleted)
                .ThenByDescending(o => o.Id)
                .ToListAsync();

            return todos;
        }

        public async Task<TodoItem> AddTodo(CreateTodoDTO todoDTO)
        {
            TodoItem todo = new();
            todo.Title = todoDTO.Title;

            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task<TodoItem> CheckTodo(CheckTodoDTO checkDTO)
        {
            var todo = await _context.TodoItems
                .Where(todoItem => todoItem.Id == checkDTO.Id)
                .FirstOrDefaultAsync();

            if (todo == null) throw new KeyNotFoundException("Todo Item Id Not Found");

            todo.IsCompleted = checkDTO.IsCompleted;

            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task<TodoItem> DeleteTodo(int id)
        {
            var todo = await _context.TodoItems
                .Where(todoItem => todoItem.Id == id)
                .FirstOrDefaultAsync();

            if (todo == null) throw new KeyNotFoundException("Todo Item Id Not Found");

            _context.Remove(todo);

            await _context.SaveChangesAsync();

            return todo;
        }
    }
    
}
