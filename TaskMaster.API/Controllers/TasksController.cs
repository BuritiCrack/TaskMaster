using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMaster.API.Data;

namespace TaskMaster.API.Controllers
{

    [ApiController]
    [Route("api/TaskMaster")]
    public class TasksController: ControllerBase
    {
        private readonly DataContext _Context;

        public TasksController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _Context.Tasks.ToListAsync());
        }

        //Buscar por parametro
        [HttpGet("{Taskid:int}")]
        public async Task<ActionResult> Get(int TaskId)
        {
            await _Context.Tasks.FirstOrDefaultAsync(x => x.TaskId == TaskId);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Task task)
        {
            _Context.Add(task);
            await _Context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Task task)
        {
            _Context.Update(task);
            await _Context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int TaskId)
        {
            var FilaAfectada = await _Context.Tasks
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


