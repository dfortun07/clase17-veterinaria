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
    public class MascotasModel : PageModel
    {
        private readonly VeterinariaDbContext _context;

        public MascotasModel(VeterinariaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mascota Mascota { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public List<Propietario> ListaPropietarios { get; set; } = new();
        public List<Mascota> ListaMascotas { get; set; } = new();

        public async Task OnGetAsync()
        {
            await CargarDatosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Mascota.PropietarioId <= 0)
            {
                ModelState.AddModelError("Mascota.PropietarioId", "Debe seleccionar un propietario.");
            }

            if (!ModelState.IsValid)
            {
                await CargarDatosAsync();
                return Page();
            }

            _context.Mascotas.Add(Mascota);
            await _context.SaveChangesAsync();

            Mensaje = $"Mascota '{Mascota.Nombre}' ({Mascota.Especie}) registrada exitosamente.";

            Mascota = new Mascota();
            ModelState.Clear();

            await CargarDatosAsync();
            return Page();
        }

        private async Task CargarDatosAsync()
        {
            ListaPropietarios = await _context.Propietarios
                .Where(p => p.Estado == "Activo")
                .OrderBy(p => p.Nombre)
                .ToListAsync();

            ListaMascotas = await _context.Mascotas
                .Include(m => m.Propietario)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
        }
    }
}
