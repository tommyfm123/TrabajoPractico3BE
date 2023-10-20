using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using ArticulosAPI.Modelos.DTOS;

namespace ArticulosAPI.Repositorio
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ArticuloRepositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /* Méthod para crear o actualizar artículo (post y put) */

        public async Task<ArticuloDto> CrearOActualizar(ArticuloDto articulodto, int id = 0)
        {
            var articulo = _mapper.Map<ArticuloDto, Articulo>(articulodto);
            if (id == 0)
            {
                await _context.Articulos.AddAsync(articulo);
            }
            else
            {
                articulo.Id = id;
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<Articulo, ArticuloDto>(articulo);
        }

        /* method para borrar artículos */

        public async Task<bool> DeleteArticulos(int id)
        {
            try
            {
                var articulos = await _context.Articulos.FindAsync(id);
                if (articulos != null)
                {
                    _context.Articulos.Remove(articulos);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /* method para obtener artículos */

        public async Task<List<ArticuloDto>> GetArticulos()
        {
            List<Articulo> articulos = await _context.Articulos.ToListAsync();
            return _mapper.Map<List<Articulo>, List<ArticuloDto>>(articulos);
        }

        public async Task<ArticuloDto> GetArticuloById(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            return _mapper.Map<Articulo, ArticuloDto>(articulo);
        }
    }
}


