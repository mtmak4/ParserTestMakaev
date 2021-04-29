using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParserTestMakaev.BL;
using ParserTestMakaev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ParserTestMakaev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {

        ApplicationDbContext db;
        public TaskController(ApplicationDbContext context)
        {
            db = context;

        }
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Task>>> Get()
        {
            return await db.Tasks.ToListAsync();
        }

        [HttpGet("taskDirector/{directorId}")]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Task>>> taskDirector(int directorId)
        {
            User director = db.Users.FirstOrDefault(x => x.Id == directorId);
            return await db.Tasks.Where(x=>x.Director==director).ToListAsync();
        }

        [HttpGet("taskExecutor/{executorId}")]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Task>>> taskExecutor(int executorId)
        {
            User executor = db.Users.FirstOrDefault(x => x.Id == executorId);
            return await db.Tasks.Where(x => x.Director == executor).ToListAsync();
        }

        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> Get(int id)
        {
            Task task = await db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return NotFound();
            return new ObjectResult(task);
        }
        [HttpGet("changeStatus/{id}/{newStatus}")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> changeStatus(int id,string newStatus)
        {
            Task task = await db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return NotFound();
            if (Enum.Parse(typeof(TaskStatus), newStatus)!=null)
            {
                task.Status = newStatus;
            }
            return new ObjectResult(task);
        }

        [HttpGet("EditTask/{id}/{param}/{newValue}")]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Task>>> EditTask(int id, string param, string newValue)
        {
            Task task = db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            switch (param)
            {
                case "Title":
                    {
                        task.Title = newValue;
                        break;
                    }
                case "Description":
                    {
                        task.Description = newValue;
                        break;
                    }
                case "DateCreation":
                    {
                        task.DateCreation = Convert.ToDateTime(newValue);
                        break;
                    }
                case "DateLastChange":
                    {
                        task.DateLastChange = Convert.ToDateTime(newValue);
                        break;
                    }
                case "Executor":
                    {
                        task.Executor = db.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(newValue)); ;
                        break;
                    }
                default:
                    {
                        return NotFound();
                    }
            }
            await db.SaveChangesAsync();
            return await db.Tasks.ToListAsync();
        }
        [HttpGet("setTask/{userId}/{taskId}")]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Task>>> changeExecutor(int taskId, int userId)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == userId);
            Task task = db.Tasks.FirstOrDefault(x => x.Id == taskId);
            if (user == null || task == null)
            {
                return NotFound();
            }
            task.Executor = user;
            await db.SaveChangesAsync();
            return await db.Tasks.ToListAsync();
        }

    }
}
