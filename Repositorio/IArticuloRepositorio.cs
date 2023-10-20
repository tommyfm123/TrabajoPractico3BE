using System;
using ArticulosAPI.Modelos.DTOS;
using ArticulosAPI.Modelos;
namespace ArticulosAPI.Repositorio
{
	public interface IArticuloRepositorio
	{
        Task<List<ArticuloDto>> GetArticulos();
        Task<ArticuloDto> GetArticuloById(int id);
        Task<ArticuloDto> CrearOActualizar(ArticuloDto Articulo, int id = 0);
        Task<bool> DeleteArticulos(int id);

    }
}

