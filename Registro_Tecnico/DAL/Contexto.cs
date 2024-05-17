using Microsoft.EntityFrameworkCore;
using Registro_Tecnico.Models;

namespace Registro_Tecnico.DAL;

public class Contexto : DbContext
{
	public Contexto(DbContextOptions<Contexto> options) : base(options) {

	}

	public DbSet<Tecnicos> Tecnicos { get; set; }
	public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
}
