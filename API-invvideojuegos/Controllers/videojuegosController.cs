using API_invvideojuegos;
using API_invvideojuegos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.CodeAnalysis;
using API_invvideojuegos.Services;


namespace API_invvideojuegos.Controllers
{
    [ApiController]

    [Route("api/juegos")]
    public class videojuegosController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IService service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ILogger<videojuegosController> logger;
        private readonly IWebHostEnvironment env;
        private readonly string nuevosRegistros = "nuevosRegistros.txt";
        private readonly string registrosConsultados = "registrosConsultados.txt";

        public videojuegosController(ApplicationDbContext context, IService service,
            ServiceTransient serviceTransient, ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton, ILogger<videojuegosController> logger,
            IWebHostEnvironment env)
        {
            this.dbContext = context;
            this.service = service;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.logger = logger;
            this.env = env;
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
        public async Task<ActionResult> Post([FromBody] videojuegos videojuegos)
        {
            //Ejemplo para validar desde el controlador con la BD con ayuda del dbContext

            var existeAlumnoMismoNombre = await dbContext.Videojuegos.AnyAsync(x => x.Name == videojuegos.Name);

            if (existeAlumnoMismoNombre)
            {
                return BadRequest("Ya existe un autor con el nombre");
            }


            dbContext.Add(videojuegos);
            await dbContext.SaveChangesAsync();

            //   var ruta = $@"{env.ContentRootPath}\wwwroot\{nuevosRegistros}";
            //  using (StreamWriter writer = new StreamWriter(ruta, append: true)) { writer.WriteLine(alumno.Id + " " + alumno.Nombre); }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(videojuegos videojuegos, int id)
        {
            if (videojuegos.Id != id)
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
