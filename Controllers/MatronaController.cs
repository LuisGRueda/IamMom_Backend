using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSISINFO3.Contexto;
using ProyectoSISINFO3.Entidades;

namespace ProyectoSISINFO3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatronaController : ControllerBase
    {
        private readonly ApplicationDBContext contexto;

        public MatronaController(ApplicationDBContext context_)
        {
            contexto = context_;
        }
        [HttpGet]
        public async Task<ActionResult<List<Matrona>>> Listar()
        {
            var lista = await contexto.Matrona.ToListAsync();
            return lista;
        }
        [HttpGet("activos")]
        public async Task<ActionResult<List<Matrona>>> ListarActivos()
        {
            return await contexto.Matrona.Where(x => x.Estado == "Activo").ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Matrona>> ObtnerMatrona(int id)
        {
            Matrona MatronaBuscada = await contexto.Matrona.FirstOrDefaultAsync(x => x.Id == id);
            if (MatronaBuscada != null)
            {
                return MatronaBuscada;
            }
            else { return NotFound(); }
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Matrona>>> BuscarNombre(string nombre)
        {
            var resultadosMatronas = await contexto.Matrona.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
            if (resultadosMatronas.Count != 0)
            {
                return resultadosMatronas;
            }
            else { return NotFound(); }
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(Matrona Matrona)
        {
            Matrona verificarMatrona = await contexto.Matrona.FirstOrDefaultAsync(x => x.Ci == Matrona.Ci);
            if (verificarMatrona == null)
            {
                contexto.Matrona.Add(Matrona);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("Ya existe este Ci"); }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Editar(Matrona Matrona, int id)
        {
            Matrona existe = await contexto.Matrona.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                existe.Nombre = Matrona.Nombre;
                existe.Apellidos = Matrona.Apellidos;
                existe.Ci = Matrona.Ci;
                existe.Usuario = Matrona.Usuario;
                existe.Contrasenia = Matrona.Contrasenia;
                existe.Rol = Matrona.Rol;
                existe.Correo = Matrona.Correo;
                existe.Telefono = Matrona.Telefono;
                existe.Horario = Matrona.Horario;
                existe.Estado = Matrona.Estado;
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("No existe la Matrona a editar"); }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            Matrona existe = await contexto.Matrona.FirstOrDefaultAsync(x => x.Id == id);
            if (existe != null)
            {
                contexto.Remove(existe);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("La Matrona a eliminar no existe"); }
        }
    }
}
