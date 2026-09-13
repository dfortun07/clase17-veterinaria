# Sistema de Gestion de Citas - Veterinaria Arca de Noe

Aplicacion web para la administracion de propietarios, mascotas, veterinarios y agendamiento de citas medicas.

## Tecnologias

* ASP.NET Core (.NET 10.0) - Razor Pages
* Entity Framework Core (SQLite)
* Bootstrap 5
* Validaciones mediante DataAnnotations y Tokens Anti-Forgery

## Modulos

1. **Propietarios:** Registro de clientes (Nombre, Apellidos, Telefono, Email, Estado).
2. **Mascotas:** Registro de pacientes vinculados a su propietario (Nombre, Especie, Raza, Fecha de Nacimiento, Estado).
3. **Veterinarios:** Directorio veterinario (Nombre, Apellidos, Especialidad, Telefono, Estado).
4. **Citas Medicas:** Programacion de citas (Mascota, Veterinario, Fecha y Hora, Motivo, Estado, Diagnostico).

## Ejecucion

1. Abrir la solucion en Visual Studio o ejecutar por consola:
   ```bash
   dotnet run --project clase17david/clase17david.csproj
   ```
2. La base de datos SQLite se crea automaticamente al iniciar.
