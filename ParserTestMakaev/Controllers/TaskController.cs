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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> Get(int id)
        {
            Task user = await db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

    }
}
