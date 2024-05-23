using Microsoft.EntityFrameworkCore;
using Registro_Tecnico.DAL;
using Registro_Tecnico.Models;
using System.Linq.Expressions;

namespace Registro_Tecnico.Services;

public class TipoTecnicoService
{
	private readonly Contexto _contexto;

    public TipoTecnicoService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Guardar(TiposTecnicos tipoTecnico) {
        if (!await Existe(tipoTecnico.TipoId))
            return await Insertar(tipoTecnico);
        else
            return await Modificar(tipoTecnico);
    }

	private async Task<bool> Existe(int tipoId) {
		return await _contexto.TiposTecnicos
			.AnyAsync(tp => tp.TipoId ==  tipoId);
	}

	public async Task<bool> ExisteDescripcion(int tipoId, string descripcion) {
		return await _contexto.TiposTecnicos
			.AnyAsync(tp => tp.TipoId != tipoId 
			&& tp.Descripcion.ToLower().Equals(descripcion.ToLower()));
	}

	private async Task<bool> Insertar(TiposTecnicos tipoTecnico) {
		_contexto.TiposTecnicos.Add(tipoTecnico);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(TiposTecnicos tipoTecnico) {
		_contexto.Update(tipoTecnico);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(tipoTecnico).State = EntityState.Detached;
		return modificado;
	}

	public async Task<bool> Eliminar(TiposTecnicos tipoTecnico) {
		return await _contexto.TiposTecnicos
			.AsNoTracking()
			.Where(tp => tp.TipoId == tipoTecnico.TipoId)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<TiposTecnicos?> BuscarId(int id) {
		return await _contexto.TiposTecnicos
			.AsNoTracking()
			.FirstOrDefaultAsync(tp => tp.TipoId == id);
	}

	public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio) {
		return await _contexto.TiposTecnicos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
