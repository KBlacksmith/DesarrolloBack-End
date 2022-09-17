namespace WebAPI_Peliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public List<Actor> Cast { get; set; }
    }
}
