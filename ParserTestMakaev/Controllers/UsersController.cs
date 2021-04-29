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

        [HttpGet("editname/{id}/{param}/{newValue}")]
        public async Task<ActionResult<IEnumerable<User>>> EditName(int id, string param,string newValue)
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



        [HttpGet("editUser/{id}/{param}/{newValue}")]
        public async Task<ActionResult<IEnumerable<User>>> EditUser(int id, string param, object newValue)
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
                        user["Name"] = newValue;
                        break;
                    }
                case "Surname":
                    {
                        user["Surname"] = newValue;
                        break;
                    }
                case "DateCreation":
                    {
                        user["DateCreation"] = (DateTime) newValue;
                        break;
                    }
                case "DateLastChange":
                    {
                        user["DateLastChange"] = (DateTime) newValue;
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

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
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
