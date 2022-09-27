using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Peliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:50, ErrorMessage = "El campo {0} solo puede tener hasta 50 caracteres")]
        public string Titulo { get; set; }
        public string Director { get; set; }
        //public List<Actor> Cast { get; set; }
        public Actor Cast { get; set; }
        [Range(1900, int.MaxValue, ErrorMessage ="El campo {0} no se encuentra en el rango permitido")]
        [NotMapped]
        public int Year { get; set; }//Año de estreno
    }
}
