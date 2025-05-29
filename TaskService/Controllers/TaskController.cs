using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskService.Models;
using TaskService;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskDbContext _context;

    public TaskController(TaskDbContext context)
    {
        _context = context;
    }

    // GET: api/task
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    // GET: api/task/1
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTask(int id)
    {
        var tasks = await _context.Tasks.FindAsync(id);
        if (tasks == null) return NotFound();
        return tasks;
    }

    // POST: api/task
    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask(TaskItem tasks)
    {
        _context.Tasks.Add(tasks);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask), new { id = tasks.Id }, tasks);
    }

    // PUT: api/task/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem tasks)
    {
        if (id != tasks.Id)
        {
            return BadRequest(new
            {
                message = "ID mismatch between URL and body",
                urlId = id,
                bodyId = tasks.Id
            });
        }

        _context.Entry(tasks).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }


    // DELETE: api/task/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var tasks = await _context.Tasks.FindAsync(id);
        if (tasks == null) return NotFound();

        _context.Tasks.Remove(tasks);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
