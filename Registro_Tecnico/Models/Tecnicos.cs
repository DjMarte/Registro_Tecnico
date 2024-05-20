using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Tecnico.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten caracteres especiales")]
    [Required(ErrorMessage = "Nombre obligatorio")]
    public string? Nombres { get; set; }

    [Range(0.01, float.MaxValue, ErrorMessage ="Ingrese un valor mayor a 0")] 
    [Required(ErrorMessage = "Sueldo obligtorio")]
    public decimal SueldoHora { get; set; }

    [ForeignKey("TipoId")]
    public int TipoId { get; set; }
}
