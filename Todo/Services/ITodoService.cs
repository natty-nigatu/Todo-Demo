using Todo.DTO;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoService
    {
        Task<TodoItem> AddTodo(CreateTodoDTO todoDTO);
        Task<TodoItem> CheckTodo(CheckTodoDTO checkDTO);
        Task<TodoItem> DeleteTodo(int id);
        Task<List<TodoItem>> GetAllTodos();
    }
}
