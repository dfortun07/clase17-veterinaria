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
    public class VeterinariosModel : PageModel
    {
        private readonly VeterinariaDbContext _context;

        public VeterinariosModel(VeterinariaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Veterinario Veterinario { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public List<Veterinario> ListaVeterinarios { get; set; } = new();

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

            _context.Veterinarios.Add(Veterinario);
            await _context.SaveChangesAsync();

            Mensaje = $"Veterinario(a) registrado(a): {Veterinario.NombreCompleto}";

            Veterinario = new Veterinario();
            ModelState.Clear();

            await CargarDatosAsync();
            return Page();
        }

        private async Task CargarDatosAsync()
        {
            ListaVeterinarios = await _context.Veterinarios
                .OrderByDescending(v => v.Id)
                .ToListAsync();
        }
    }
}
