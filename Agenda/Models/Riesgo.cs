using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Riesgo
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Contactos> ContactosR { get; set; }
    }
}
