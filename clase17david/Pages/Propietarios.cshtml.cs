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
    public class PropietariosModel : PageModel
    {
        private readonly VeterinariaDbContext _context;

        public PropietariosModel(VeterinariaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propietario Propietario { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public List<Propietario> ListaPropietarios { get; set; } = new();

        public async Task OnGetAsync()
        {
            await CargarDatosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarDatosAsync();
                return Page();
            }

            _context.Propietarios.Add(Propietario);
            await _context.SaveChangesAsync();

            Mensaje = $"Propietario registrado exitosamente: {Propietario.NombreCompleto}";

            Propietario = new Propietario();
            ModelState.Clear();

            await CargarDatosAsync();
            return Page();
        }

        private async Task CargarDatosAsync()
        {
            ListaPropietarios = await _context.Propietarios
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }
    }
}
