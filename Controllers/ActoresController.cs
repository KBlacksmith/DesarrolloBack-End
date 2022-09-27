using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Peliculas.Entidades;

namespace WebAPI_Peliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ActoresController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Actor>>> GetAll()
        {
            return await dbContext.Actores.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> GetById(int id)
        {
            var actor =  await dbContext.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if(actor == null)
            {
                return NotFound("No se encontró el actor con id " + id.ToString());
            }
            return actor;
        }
        [HttpGet("primero")]
        public async Task<ActionResult<Actor>> GetPrimero()
        {
            return await dbContext.Actores.FirstOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Actor actor)
        {
            var existePelicula = await dbContext.Peliculas.AnyAsync(x => x.Id == actor.PeliculaId);
            if (!existePelicula)
            {
                return BadRequest("No existe la película con el id: "+actor.PeliculaId.ToString());
            }
            dbContext.Add(actor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Actor actor, int id)
        {
            var existe = await dbContext.Peliculas.AnyAsync(x => x.Id == actor.PeliculaId);
            if (!existe)
            {
                return NotFound("La película especificada no existe");
            }
            if(actor.Id != id)
            {
                return BadRequest("El id del actor no coincide con el establecido en la url");
            }
            dbContext.Update(actor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Actores.AnyAsync(x =>x.Id == id);
            if (!existe)
            {
                return NotFound("El actor con el id especificado no fue encontrado");
            }
            dbContext.Remove(new Actor { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
