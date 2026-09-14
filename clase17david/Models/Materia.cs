using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace clase17david.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Codigo { get; set; }

        public int Creditos { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}
