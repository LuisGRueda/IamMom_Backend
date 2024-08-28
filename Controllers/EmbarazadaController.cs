using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSISINFO3.Contexto;
using ProyectoSISINFO3.Entidades;

namespace ProyectoSISINFO3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbarazadaController : ControllerBase
    {
        private readonly ApplicationDBContext contexto;

        public EmbarazadaController(ApplicationDBContext context_)
        {
            contexto = context_;
        }
        [HttpGet]
        public async Task<ActionResult<List<Embarazada>>> Listar()
        {
            var lista = await contexto.Embarazada.ToListAsync();
            return lista;
        }
        [HttpGet("activos")]
        public async Task<ActionResult<List<Embarazada>>> ListarActivos()
        {
            return await contexto.Embarazada.Where(x => x.Estado == "Activo").ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Embarazada>> ObtnerEmbarazada(int id)
        {
            Embarazada EmbarazadaBuscada = await contexto.Embarazada.FirstOrDefaultAsync(x => x.Id == id);
            if (EmbarazadaBuscada != null)
            {
                return EmbarazadaBuscada;
            }
            else { return NotFound(); }
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Embarazada>>> BuscarNombre(string nombre)
        {
            var resultadosEmbarazadas = await contexto.Embarazada.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
            if (resultadosEmbarazadas.Count != 0)
            {
                return resultadosEmbarazadas;
            }
            else { return NotFound(); }
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(Embarazada Embarazada)
        {
            Embarazada verificarEmbarazada = await contexto.Embarazada.FirstOrDefaultAsync(x => x.Ci == Embarazada.Ci);
            if (verificarEmbarazada == null)
            {
                contexto.Embarazada.Add(Embarazada);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("Ya existe este Ci"); }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Editar(Embarazada Embarazada, int id)
        {
            Embarazada existe = await contexto.Embarazada.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                existe.Nombre = Embarazada.Nombre;
                existe.Apellidos = Embarazada.Apellidos;
                existe.Ci = Embarazada.Ci;
                existe.NroSeguro = Embarazada.NroSeguro;
                existe.Direccion = Embarazada.Direccion;
                existe.Edad = Embarazada.Edad;
                existe.SemanaGestacion = Embarazada.SemanaGestacion;
                existe.NroHijos = Embarazada.NroHijos;
                existe.Telefono = Embarazada.Telefono;
                existe.Registro = Embarazada.Registro;
                existe.MatronaId = Embarazada.MatronaId;
                existe.Estado = Embarazada.Estado;
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("No existe la Embarazada a editar"); }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            Embarazada existe = await contexto.Embarazada.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                contexto.Remove(existe);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("La Embarazada a eliminar no existe"); }
        }
    }
}
