using System.ComponentModel.DataAnnotations;

namespace Mi_primer_API.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [Display(Name = "Nombre de la pelicula")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Duracion de la pelicula")]
        public int Duration { get; set; }

        [Display(Name = "Descripcion de la pelicula")]
        public string? Descrition { get; set; }

        [Required]
        [Display(Name = "Clasificacion de la pelicula")]
        public string Clasification { get; set; }

    }
}
