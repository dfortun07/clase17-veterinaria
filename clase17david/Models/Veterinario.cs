using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace clase17david.Models
{
    public class Veterinario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(100)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(100)]
        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; } = "Medicina General";

        [Phone]
        [StringLength(20)]
        [Display(Name = "Telefono")]
        public string? Telefono { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Activo";

        [Display(Name = "Veterinario")]
        public string NombreCompleto => $"{Nombre} {Apellidos}".Trim();

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
