using Microsoft.AspNetCore.Mvc;
using Todo.DTO;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAll()
        {
            var todos = await _todoService.GetAllTodos();

            return Ok(todos);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> AddTodo(CreateTodoDTO todoDTO)
        {
            var todo = await _todoService.AddTodo(todoDTO);

            return Ok(todo);
        }
        
        [HttpPut]
        public async Task<ActionResult<TodoItem>> CheckTodo(CheckTodoDTO todoDTO)
        {
            try
            {
                var todo = await _todoService.CheckTodo(todoDTO);
                return Ok(todo);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<TodoItem>> DeleteTodo(int id)
        {
            try
            {
                var todo = await _todoService.DeleteTodo(id);
                return Ok(todo);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}