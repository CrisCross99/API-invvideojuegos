using API_invvideojuegos;
using API_invvideojuegos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
namespace API_invvideojuegos.Controllers
{
    [ApiController]
    [Route("juegos")]

    public class JuegosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public JuegosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Juegos>>> Get()
        {

            return await dbContext.Juego.ToListAsync();

        }


        [HttpPost]
        public async Task<ActionResult> Post(Juegos Juego)
        {
            dbContext.Add(Juego);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Juegos Juego, int id)
        {
            if (Juego.Id == id)
            {
                return BadRequest("el id del juego");
            }
            dbContext.Update(Juego);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var empDelete = await dbContext.Juego.FindAsync(id);
            dbContext.Juego.Remove(empDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
