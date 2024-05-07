using System.ComponentModel.DataAnnotations;

namespace Registro_Tecnico.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "No se permiten caracteres especiales")]
    [Required(ErrorMessage = "Nombre obligatorio")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "Sueldo obligtorio")]
    public decimal SueldoHora { get; set; } 
}
