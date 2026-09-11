using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace clase17david.Models
{
    public class Propietario
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

        [Phone]
        [StringLength(20)]
        [Display(Name = "Telefono")]
        public string? Telefono { get; set; }

        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Activo";

        [Display(Name = "Propietario")]
        public string NombreCompleto => $"{Nombre} {Apellidos}".Trim();

        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
