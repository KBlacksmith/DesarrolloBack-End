using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Peliculas.Entidades;

namespace WebAPI_Peliculas.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PeliculasController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        [HttpGet("listado")]
        [HttpGet("/listado")]
        public async Task<ActionResult<List<Pelicula>>> Get()
        {
            return await dbContext.Peliculas.Include(x => x.Cast).ToListAsync();
        }
        [HttpGet("primero")]
        public async Task<ActionResult<Pelicula>> PrimerPelicula([FromHeader] int valor, [FromQuery] string pelicula)
        {
            return await dbContext.Peliculas.FirstOrDefaultAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pelicula>> GetByID(int id)
        {
            var pelicula = await dbContext.Peliculas.FirstOrDefaultAsync(x => x.Id == id);
            if (pelicula == null)
            {
                return NotFound("No se encontró el alumno con id "+id.ToString());
            }
            return pelicula;
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Pelicula>> GetPorTitulo([FromRoute] string nombre)
        {
            var pelicula = await dbContext.Peliculas.FirstOrDefaultAsync(x => x.Titulo.Contains(nombre));
            if(pelicula == null)
            {
                return NotFound("No se encontró una película con título \"" + nombre + "\"");
            }
            return pelicula;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pelicula pelicula)
        {
            dbContext.Add(pelicula);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]//api/peliculas/1
        public async Task<ActionResult> Put(Pelicula pelicula, int id)
        {
            if(pelicula.Id != id)
            {
                return BadRequest("El id de la película no coincide con el establecido en la url");
            }
            dbContext.Update(pelicula);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Peliculas.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound("La película con id " + id.ToString() + " no fue encontrada");
            }
            dbContext.Remove(new Pelicula()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
