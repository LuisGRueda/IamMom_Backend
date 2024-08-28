using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSISINFO3.Contexto;
using ProyectoSISINFO3.Entidades;

namespace ProyectoSISINFO3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly ApplicationDBContext contexto;

        public ClaseController(ApplicationDBContext context_)
        {
            contexto = context_;
        }
        [HttpGet]
        public async Task<ActionResult<List<Clase>>> Get()
        {
            var lista = await contexto.Clase.ToListAsync();
            return lista;
        }
        [HttpGet("activos")]
        public async Task<ActionResult<List<Clase>>> ListarActivos()
        {
            return await contexto.Clase.Where(x => x.Estado == "Activo").ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Clase>> ObtnerClase(int id)
        {
            Clase ClaseBuscada = await contexto.Clase.FirstOrDefaultAsync(x => x.Id == id);
            if (ClaseBuscada != null)
            {
                return ClaseBuscada;
            }
            else { return NotFound(); }
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Clase>>> BuscarNombre(string nombre)
        {
            var resultadosClases = await contexto.Clase.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
            if (resultadosClases.Count != 0)
            {
                return resultadosClases;
            }
            else { return NotFound(); }
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(Clase Clase)
        {
            Clase verificarClase = await contexto.Clase.FirstOrDefaultAsync(x => x.Nombre == Clase.Nombre);
            if (verificarClase == null)
            {
                contexto.Clase.Add(Clase);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("Ya existe este Nombre"); }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Editar(Clase Clase, int id)
        {
            Clase existe = await contexto.Clase.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                existe.Nombre = Clase.Nombre;
                existe.Descripcion= Clase.Descripcion;
                existe.FechaHora = Clase.FechaHora;
                existe.MatronaId = Clase.MatronaId;
                existe.CentroId = Clase.CentroId;
                existe.Estado = Clase.Estado;
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("No existe la Clase a editar"); }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            Clase existe = await contexto.Clase.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                contexto.Remove(existe);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("La Clase a eliminar no existe"); }
        }
    }
}
