using Microsoft.AspNetCore.Mvc;
using TodoWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ITodoRepository _todoRepository;

        public TodoController(ITodoRepository repository)
        {
            _todoRepository = repository;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> Get()
        {
            return Ok(await _todoRepository.GetAllAsync());
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var todo= await _todoRepository.GetTodo(id);
            if (todo == null)
                return NotFound(id);

            return Ok(todo);
        }

        // POST api/<TodoController>
        [HttpPost]
        public async Task<Todo?> Post([FromBody] Todo value)
        {
            return await _todoRepository.CreateAsync(value);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public async Task<bool?> Delete(int id)
        {
            return await _todoRepository.DeleteAsync(id);
        }
    }
}
