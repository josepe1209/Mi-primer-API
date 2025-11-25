using System.ComponentModel.DataAnnotations;

namespace Mi_primer_API.DAL.Models
{
    public class Category: AuditBase
    {
        [Required] //Dataanotacion para hacer el campo obligatorio
        [Display(Name = "Nombre de la categoria")] //Dataanotacion para cambiar el nombre del campo en las vistas
        public String Name { get; set; }

    }
}
