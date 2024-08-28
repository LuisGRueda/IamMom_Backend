using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSISINFO3.Contexto;
using ProyectoSISINFO3.Entidades;

namespace ProyectoSISINFO3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroController : ControllerBase
    {
        private readonly ApplicationDBContext contexto;

        public CentroController(ApplicationDBContext context_)
        {
            contexto = context_;
        }

        [HttpGet]
        public async Task<ActionResult<List<Centro>>> Get()
        {
            var lista = await contexto.Centro.ToListAsync();
            return lista;
        }

        [HttpGet("activos")]
        public async Task<ActionResult<List<Centro>>> ListarActivos()
        {
            return await contexto.Centro.Where(x => x.Estado == "Activo").ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Centro>> ObtnerCentro(int id)
        {
            Centro CentroBuscada = await contexto.Centro.FirstOrDefaultAsync(x => x.Id == id);
            if (CentroBuscada != null)
            {
                return CentroBuscada;
            }
            else { return NotFound(); }
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Centro>>> BuscarNombre(string nombre)
        {
            var resultadosCentros = await contexto.Centro.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
            if (resultadosCentros.Count != 0)
            {
                return resultadosCentros;
            }
            else { return NotFound(); }
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(Centro Centro)
        {
            Centro verificarCentro = await contexto.Centro.FirstOrDefaultAsync(x => x.Nombre == Centro.Nombre);
            if (verificarCentro == null)
            {
                contexto.Centro.Add(Centro);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("Ya existe este Nombre"); }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Editar(Centro Centro, int id)
        {
            Centro existe = await contexto.Centro.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                existe.Nombre = Centro.Nombre;
                existe.Direccion = Centro.Direccion;
                existe.Telefono = Centro.Telefono;
                existe.Tipo = Centro.Tipo;
                existe.Estado = Centro.Estado;
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("No existe la Centro a editar"); }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            Centro existe = await contexto.Centro.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                contexto.Remove(existe);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("La Centro a eliminar no existe"); }
        }
    }
}
