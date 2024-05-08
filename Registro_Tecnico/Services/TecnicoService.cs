using Microsoft.EntityFrameworkCore;
using Registro_Tecnico.DAL;
using Registro_Tecnico.Models;
using System.Linq.Expressions;

namespace Registro_Tecnico.Services;

public class TecnicoService
{
	private readonly Contexto _contexto;

    public TecnicoService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Crear(Tecnicos tecnico) {
        if (!await Existe(tecnico.TecnicoId))
            return await Insertar(tecnico);
        else
            return await Modificar(tecnico);
    }

	private async Task<bool> Existe(int tecnicoId) {
		return await _contexto.Tecnicos.AnyAsync(t => t.TecnicoId ==  tecnicoId);
	}

	private async Task<bool> Insertar(Tecnicos tecnico) {
		_contexto.Tecnicos.Add(tecnico);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Tecnicos tecnico) {
		_contexto.Update(tecnico);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(tecnico).State = EntityState.Detached;
		return modificado;
	}

	public async Task<bool> Eliminar(Tecnicos tecnico) {
		return await _contexto.Tecnicos
			.AsNoTracking()
			.Where(t => t.TecnicoId == tecnico.TecnicoId)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<Tecnicos?> BuscarNombre(string nombre) {
		return await _contexto.Tecnicos
			.AsNoTracking()
			.FirstOrDefaultAsync(t => t.Nombres == nombre);
	}

	public async Task<Tecnicos?> BuscarId(int id) {
		return await _contexto.Tecnicos
			.AsNoTracking()
			.FirstOrDefaultAsync(t => t.TecnicoId == id);
	}

	public async Task<List<Tecnicos>> ListarTecnico(Expression<Func<Tecnicos, bool>> criterio) {
		return await _contexto.Tecnicos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
