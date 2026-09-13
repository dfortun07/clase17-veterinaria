using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clase17david.Data;
using clase17david.Models;

namespace clase17david.Pages
{
    [ValidateAntiForgeryToken]
    public class CitasModel : PageModel
    {
        private readonly VeterinariaDbContext _context;

        public CitasModel(VeterinariaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita Cita { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public List<Mascota> ListaMascotas { get; set; } = new();
        public List<Veterinario> ListaVeterinarios { get; set; } = new();
        public List<Cita> ListaCitas { get; set; } = new();

        public async Task OnGetAsync()
        {
            await CargarDatosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Cita.MascotaId <= 0)
            {
                ModelState.AddModelError("Cita.MascotaId", "Debe seleccionar una mascota.");
            }

            if (Cita.VeterinarioId <= 0)
            {
                ModelState.AddModelError("Cita.VeterinarioId", "Debe seleccionar un veterinario.");
            }

            if (!ModelState.IsValid)
            {
                await CargarDatosAsync();
                return Page();
            }

            _context.Citas.Add(Cita);
            await _context.SaveChangesAsync();

            Mensaje = "Cita médica agendada correctamente.";

            Cita = new Cita();
            ModelState.Clear();

            await CargarDatosAsync();
            return Page();
        }

        private async Task CargarDatosAsync()
        {
            ListaMascotas = await _context.Mascotas
                .Include(m => m.Propietario)
                .Where(m => m.Estado == "Activo")
                .OrderBy(m => m.Nombre)
                .ToListAsync();

            ListaVeterinarios = await _context.Veterinarios
                .Where(v => v.Estado == "Activo")
                .OrderBy(v => v.Nombre)
                .ToListAsync();

            ListaCitas = await _context.Citas
                .Include(c => c.Mascota)
                    .ThenInclude(m => m!.Propietario)
                .Include(c => c.Veterinario)
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();
        }
    }
}
