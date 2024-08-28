using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSISINFO3.Contexto;
using ProyectoSISINFO3.Entidades;

namespace ProyectoSISINFO3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroRegistroClasessController : ControllerBase
    {
        private readonly ApplicationDBContext contexto;

        public RegistroRegistroClasessController(ApplicationDBContext context_)
        {
            contexto = context_;
        }
        [HttpGet]
        public async Task<ActionResult<List<RegistroClases>>> Get()
        { 
            var lista = await contexto.RegistroClases.ToListAsync();
            return lista;
        }
        [HttpGet("activos")]
        public async Task<ActionResult<List<RegistroClases>>> ListarActivos()
        {
            return await contexto.RegistroClases.Where(x => x.Estado == "Activo").ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RegistroClases>> ObtnerRegistroClases(int id)
        {
            RegistroClases RegistroClasesBuscada = await contexto.RegistroClases.FirstOrDefaultAsync(x => x.Id == id);
            if (RegistroClasesBuscada != null)
            {
                return RegistroClasesBuscada;
            }
            else { return NotFound(); }
        }

        /*[HttpGet("{nombre}")]
        public async Task<ActionResult<List<RegistroClases>>> BuscarNombre(string nombre)
        {
            var resultadosRegistroClasess = await contexto.RegistroClases.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
            if (resultadosRegistroClasess.Count != 0)
            {
                return resultadosRegistroClasess;
            }
            else { return NotFound(); }
        }*/

        [HttpPost]
        public async Task<ActionResult> Agregar(RegistroClases RegistroClases)
        {
            /*RegistroClases verificarRegistroClases = await contexto.RegistroClases.FirstOrDefaultAsync(x => x.Nombre == RegistroClases.Nombre);*/
           /* if (verificarRegistroClases == null)
            {*/
                contexto.RegistroClases.Add(RegistroClases);
                await contexto.SaveChangesAsync();
                return Ok();/*
            }
            else { return BadRequest("Ya existe este Nombre"); }*/
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Editar(RegistroClases RegistroClases, int id)
        {
            RegistroClases existe = await contexto.RegistroClases.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                existe.ClaseId = RegistroClases.ClaseId;
                existe.EmbarazadaId = RegistroClases.EmbarazadaId;
                existe.Fecha = RegistroClases.Fecha;
                existe.Estado = RegistroClases.Estado;
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("No existe la RegistroClases a editar"); }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            RegistroClases existe = await contexto.RegistroClases.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                contexto.Remove(existe);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("La RegistroClases a eliminar no existe"); }
        }
    }
}
