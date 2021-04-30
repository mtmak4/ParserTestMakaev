using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParserTestMakaev.BL;
using ParserTestMakaev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserTestMakaev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApplicationDbContext db;
        public UsersController(ApplicationDbContext context)
        {
            db = context;
           
        }

        [HttpGet("EditUser/{id}/{param}/{newValue}")]
        public async Task<ActionResult<IEnumerable<User>>> EditUser(int id, string param,string newValue)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            switch (param)
            {
                case "Name":
                    {
                        user.Name = newValue;
                        break;
                    }
                case "Surname":
                    {
                        user.Surname = newValue;
                        break;
                    }
                case "DateCreation":
                    {
                        user.DateCreation = Convert.ToDateTime(newValue);
                        break;
                    }
                case "DateLastChange":
                    {
                        user.DateLastChange = Convert.ToDateTime(newValue);
                        break;
                    }
                default:
                    {
                        return NotFound();
                    }
            }
            await db.SaveChangesAsync();
            return await db.Users.ToListAsync();
        }

        [HttpGet("setTask/{userId}/{taskId}")]
        public async Task<ActionResult<IEnumerable<User>>> SetTask(int userId, int taskId)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == userId);
            BL.Task task = db.Tasks.FirstOrDefault(x => x.Id == taskId);
            if (user == null || task == null)
            {
                return NotFound();
            }
            task.Executor = user;
            await db.SaveChangesAsync();
            return await db.Users.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }
       
     
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
