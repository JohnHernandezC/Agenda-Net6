using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Categorias
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El valor de {0} es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Fecha De Creacion")]
        public DateTime? FechaCreacion { get; set; }
    }
}
