using Microsoft.AspNetCore.Mvc;
using Task_Management.Data;
using Task_Management.Models;
using System.Collections.Generic;
using System.Linq;

namespace Task_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks() => _context.Tasks.ToList();

        [HttpPost]
        public IActionResult AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
                _context.SaveChanges();
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem updatedTask)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Deadline = updatedTask.Deadline;
            task.IsCompleted = updatedTask.IsCompleted;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
