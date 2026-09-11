using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clase17david.Pages
{
    [IgnoreAntiforgeryToken]
    public class EstudiantesModel : PageModel
    {
        [BindProperty]
        public string Nombres { get; set; } = "";

        [BindProperty]
        public string Apellidos { get; set; } = "";

        [BindProperty]
        public string Carrera { get; set; } = "";

        // Propiedad que guarda el texto que se imprimirá abajo
        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Concatenación idéntica a la de tu docente
            Mensaje = $"Estudiante registrado: {Nombres} {Apellidos} - {Carrera}";
        }
    }
}