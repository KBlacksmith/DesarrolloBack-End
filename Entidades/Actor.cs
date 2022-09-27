namespace WebAPI_Peliculas.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PeliculaId { get; set; }
        public List<Pelicula> Peliculas { get; set; }
    }
}
