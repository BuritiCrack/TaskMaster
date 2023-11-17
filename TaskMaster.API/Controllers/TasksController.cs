using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMaster.API.Data;

namespace TaskMaster.API.Controllers
{

    [ApiController]
    [Route("api/Tasks")]
    public class TasksController: ControllerBase
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Tasks.ToListAsync());
        }

        //Buscar por parametro
        [HttpGet("{TaskId:int}")]
        public async Task<ActionResult> Get(int TaskId)
        {
            await _context.Tasks.FirstOrDefaultAsync(x => x.TaskId == TaskId);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Task task)
        {
            _context.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Task task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{TaskId:int}")]
        public async Task<ActionResult> Delete(int TaskId)
        {
            var FilaAfectada = await _context.Tasks
                .Where(x => x.TaskId == TaskId)
                .ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {


                return NotFound();//404
            }

            return NoContent();//204
        }
    }
}


