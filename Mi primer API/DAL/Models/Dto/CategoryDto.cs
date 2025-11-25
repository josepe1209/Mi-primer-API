using System.ComponentModel.DataAnnotations;

namespace Mi_primer_API.DAL.Models.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "EL nombre de la categoria es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; } 

    }
}
