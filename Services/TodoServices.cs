using TodoAPI.Interface;
using TodoAPI.Models;
using Microsoft.Extensions.Logging; // Make sure you have this using statement
using AutoMapper;
using TodoAPI.AppDataContext;
using Microsoft.EntityFrameworkCore; // Make sure you have this using statement

namespace TodoAPI.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoServices> _logger;
        private readonly IMapper _mapper;

        public TodoServices(TodoDbContext context, ILogger<TodoServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateTodoAsync(CreateTodoRequest request)
        {
            try
            {
                var todo = _mapper.Map<Todo>(request);
                todo.CreatedAt = DateTime.UtcNow;
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Todo item.");
                throw new Exception("An error occurred while creating the Todo item.");
            }
        }

        public async Task DeleteTodoAsync(Guid id)
        {
            // Implementation...
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                // Handle not found, perhaps throw an exception or return a not found result.
                return; // Or throw new Exception("Todo not found");
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var todo = await _context.Todos.ToListAsync();
            if (todo == null)
            {
                throw new Exception(" No Todo items found");
            }
            return todo;

        }

        public async Task<Todo> GetByIdAsync(Guid id)
        {
            // Implementation...
            return await _context.Todos.FindAsync(id);
        }

        public async Task UpdateTodoAsync(Guid id, UpdateTodoRequest request)
        {
            // Implementation...
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return; // Or throw new Exception("Todo not found");
            }

            _mapper.Map(request, todo); // Update the existing todo object with values from the request
            await _context.SaveChangesAsync();

        }
    }
}