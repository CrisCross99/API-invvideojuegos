using API_invvideojuegos.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_invvideojuegos.Entidades
{
    public class videojuegos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Juegos> Juegos { get; set; }
    }

    public class Juegos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "rellenar este apartado")]
        public string desarrolladora { get; set; }
        [Required(ErrorMessage = "rellenar este apartado")]
        public int precio { get; set; }
        [Required(ErrorMessage = "rellenar este apartado")]
        public string genero { get; set; }
        [Required(ErrorMessage = "rellenar este apartado")]
        public int clasificacion { get; set; }
        
        [NotMapped]
        public int Menor { get; set; }

        [NotMapped]
        public int Mayor { get; set; }
    }

}




