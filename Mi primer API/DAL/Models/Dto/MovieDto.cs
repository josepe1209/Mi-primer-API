using System.ComponentModel.DataAnnotations;

namespace Mi_primer_API.DAL.Models.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "EL nombre de la pelicula es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La duracion de la pelicula es obligatorio")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "La clasificacion de la pelicula es obligatorio")]
        [MaxLength(10, ErrorMessage = "El numero maximo de caracteres es de 10.")]
        public string Clasification { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
