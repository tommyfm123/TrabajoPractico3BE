using Microsoft.AspNetCore.Mvc;
using ArticulosAPI.Modelos.DTOS;
using ArticulosAPI.Repositorio; // Agrega la referencia al repositorio

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloRepositorio _articuloRepositorio; // Agrega una instancia del repositorio

        public ArticulosController(ArticuloRepositorio articuloRepositorio) // Cambia el constructor para recibir el repositorio
        {
            _articuloRepositorio = articuloRepositorio;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDto>>>GetArticulos() // Cambia el tipo de retorno a ArticuloDto
        {
            var articulos = await _articuloRepositorio.GetArticulos();
            return articulos;
        }

    // GET: api/Articulos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ArticuloDto>> GetArticulo(int id) // Cambia el tipo de retorno a ArticuloDto
    {
        var articulo = await _articuloRepositorio.GetArticuloById(id);

        if (articulo == null)
        {
            return NotFound();
        }

        return articulo;
    }

    // PUT: api/Articulos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArticulo(int id, ArticuloDto articulo) // Cambia el parámetro y tipo de retorno a ArticuloDto
    {
        var updatedArticulo = await _articuloRepositorio.CrearOActualizar(articulo, id);

        return NoContent();
    }

    // POST: api/Articulos
    [HttpPost]
    public async Task<ActionResult<ArticuloDto>> PostArticulo(ArticuloDto articulo) // Cambia el tipo de retorno a ArticuloDto
    {
        var createdArticulo = await _articuloRepositorio.CrearOActualizar(articulo);

        return CreatedAtAction("GetArticulo", new { id = createdArticulo.Id}, createdArticulo);
    }

    // DELETE: api/Articulos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticulo(int id)
    {
        var result = await _articuloRepositorio.DeleteArticulos(id);
        if (result)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
}