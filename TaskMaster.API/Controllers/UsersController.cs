using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMaster.API.Data;
using TaskMaster.Shared.Entities;

namespace TaskMaster.API.Controllers
{
    [ApiController]
    [Route("/api/Users")]
    public class UsersController: ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

       

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Users.ToListAsync());


        }

       
        [HttpGet("{userid:int}")]
        public async Task<ActionResult> Get(int userid)
        {

            //200 Ok

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userid);

            if (user == null)
            {


                return NotFound();
            }

            return Ok(user);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(User User)
        {
            _context.Add(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(User User)
        {
            _context.Update(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int userid)
        {


            var FilaAfectada = await _context.Users
                .Where(x => x.UserId == userid)//5
                .ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {


                return NotFound();//404
            }

            return NoContent();//204


        }

    }
}
