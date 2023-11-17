﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMaster.API.Data;
using TaskMaster.Shared.Entities;

namespace TaskMaster.API.Controllers
{
    [ApiController]
    [Route("api/Users")]
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

        [HttpGet("{UserId:int}")]
        public async Task<ActionResult> Get(int UserId)
        {
            await _context.Users.FirstOrDefaultAsync(x => x.UserId == UserId);
            return Ok();
        }

        /*
        [HttpPost]
        public async Task<ActionResult> Post(User User)
        {
            _context.Add(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }
        
        /*
        [HttpPut]
        public async Task<ActionResult> Put(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }*/

        [HttpDelete]
        public async Task<ActionResult> Delete(int UserId)
        {
            var FilaAfectada = await _context.Users
                .Where(x => x.UserId == UserId)
                .ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {


                return NotFound();//404
            }

            return NoContent();//204
        }
    }
}
