using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Contactos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El valor de {0} es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El valor de {0} es requerido")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "El valor de {0} es requerido")]
        [StringLength(100)]
        public string Telefono { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha De Creacion")]
        public DateTime? FechaCreacion { get; set; }

        [Required]
        public int categoriaId { get; set; }
        public Categorias categorias { get; set; }
    }
}
