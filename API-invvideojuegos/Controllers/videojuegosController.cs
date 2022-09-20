using API_invvideojuegos;
using API_invvideojuegos.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API_invvideojuegos.Controllers
{
    [ApiController]
    [Route("/videojuegos")]
    public class videojuegosController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<videojuegos>> Get()
        {
            return new List<videojuegos>()
          {
              new videojuegos(){ Id = 1, Name = "halo"  },
              new videojuegos(){ Id = 1, Name = "minecraft"}
          };

        }
    }
}
