using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_list_api.Data;
using todo_list_api.Models.DTOs.Todo;
using todo_list_api.Models.Entities;

namespace todo_list_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : Controller
    {
        private readonly TodoDBContext dbContext;
        public TodosController(TodoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await dbContext.todos.ToListAsync();

            return Ok(todos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetTodoById")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            var todo = await dbContext.todos.FirstOrDefaultAsync(u => u.id== id);

            if(todo != null){
                return Ok(todo);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoRequest addTodoRequest)
        {

            var todo = new Todo()
            {
                id = new Guid(),
                title = addTodoRequest.title,
                content = addTodoRequest.content,
                completed = addTodoRequest.completed,
                createdBy = addTodoRequest.createdBy,
                createdAt = addTodoRequest.createdAt,
            };

            await dbContext.todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoById), new { id = todo.id }, todo);
        }

        [HttpPut]
        [Route("Update/{id:guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, UpdateTodoRequest updateTodoRequest)
        {
            var existingTodo = await dbContext.todos.FindAsync(id);

            if (existingTodo != null)
            {
                existingTodo.completed = true;

                await dbContext.SaveChangesAsync();

                return Ok(existingTodo);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var existingTodo = dbContext.todos.Find(id);

            if (existingTodo != null)
            {
                dbContext.todos.Remove(existingTodo);
                await dbContext.SaveChangesAsync();

                return Ok(existingTodo);
            }

            return NotFound();
        }

    }
}
