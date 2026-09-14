using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clase17david.Models
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EstudianteId { get; set; }

        [Required]
        public int MateriaId { get; set; }

        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        [ForeignKey("EstudianteId")]
        public Estudiante? Estudiante { get; set; }

        [ForeignKey("MateriaId")]
        public Materia? Materia { get; set; }
    }
}
