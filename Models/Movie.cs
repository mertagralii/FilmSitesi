namespace FilmSitesi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? ActorId { get; set; }

       public List<MovieActor>? MovieActors { get; set; }
    }
}
