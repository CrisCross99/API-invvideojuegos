using API_invvideojuegos;
using API_invvideojuegos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.CodeAnalysis;


namespace API_invvideojuegos.Controllers
{
    [ApiController]

    [Route("api/juegos")]
    public class videojuegosController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public videojuegosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       
        public ApplicationDbContext DbContext { get; }
       
        [HttpGet]
        public async Task<ActionResult<List<videojuegos>>> Get()
        {


            return await dbContext.Videojuegos.Include(x => x.Juegos).ToListAsync();

        }

        [HttpGet("primero")]
        public async Task<ActionResult<videojuegos>> primero1(int id)
        {
            return await dbContext.Videojuegos.FirstOrDefaultAsync(x => x.Id == id);
        }

       

        [HttpPost]
        public async Task<ActionResult> Post(videojuegos videojuegos)
        {
            dbContext.Add(videojuegos);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(videojuegos videojuegos, int id)
        {
            if (videojuegos.Id == id)
            {
                return BadRequest("el id del juego");
            }
            dbContext.Update(videojuegos);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var empDelete = await dbContext.Videojuegos.FindAsync(id);
            dbContext.Videojuegos.Remove(empDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
