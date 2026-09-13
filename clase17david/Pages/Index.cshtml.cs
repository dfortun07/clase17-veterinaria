using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clase17david.Data;

namespace clase17david.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VeterinariaDbContext _context;

        public IndexModel(VeterinariaDbContext context)
        {
            _context = context;
        }

        public int TotalPropietarios { get; set; }
        public int TotalMascotas { get; set; }
        public int TotalVeterinarios { get; set; }
        public int TotalCitasPendientes { get; set; }

        public async Task OnGetAsync()
        {
            TotalPropietarios = await _context.Propietarios.CountAsync();
            TotalMascotas = await _context.Mascotas.CountAsync();
            TotalVeterinarios = await _context.Veterinarios.CountAsync();
            TotalCitasPendientes = await _context.Citas.CountAsync(c => c.EstadoCita == "Pendiente");
        }
    }
}

