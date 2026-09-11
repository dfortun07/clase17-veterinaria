using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clase17david.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una mascota.")]
        [Display(Name = "Mascota")]
        public int MascotaId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un veterinario.")]
        [Display(Name = "Veterinario")]
        public int VeterinarioId { get; set; }

        [Required(ErrorMessage = "La fecha y hora son obligatorias.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El motivo de la cita es obligatorio.")]
        [StringLength(250)]
        [Display(Name = "Motivo")]
        public string Motivo { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado de Cita")]
        public string EstadoCita { get; set; } = "Pendiente";

        [StringLength(500)]
        [Display(Name = "Diagnostico")]
        public string? Diagnostico { get; set; }

        [ForeignKey("MascotaId")]
        public Mascota? Mascota { get; set; }

        [ForeignKey("VeterinarioId")]
        public Veterinario? Veterinario { get; set; }
    }
}
