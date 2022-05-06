using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebApi.Models;

namespace TodoWebApi
{
	public interface ITodoRepository
    {
        Task<Todo?> CreateAsync(Todo t);
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo?> GetTodo(int id);
        Task<Todo?> UpdateAsync(Todo t);
        Task<bool?> DeleteAsync(int id);
    }


    public class TodoRepository: ITodoRepository
    {
        public static List<Todo> Todos=new List<Todo>();
        private TodoDbContext _db;

        public TodoRepository(TodoDbContext db)
        {
            _db=db;

            _db.Database.EnsureCreated();
        }
        public async Task<Todo?> CreateAsync(Todo todo)
        {
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
            return todo;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Todo>))]
        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _db.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodo(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            return todo;
        }

        public async Task<Todo?> UpdateAsync(Todo todo)
        {
            var exist = await _db.Todos.FindAsync(todo.ID);
            if (exist != null)
            {
                _db.Update(exist);
                await _db.SaveChangesAsync();
            }

            return exist;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo != null)
            {
                _db.Todos.Remove(todo);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

}
