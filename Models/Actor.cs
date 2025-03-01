namespace FilmSitesi.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }

        public string FullName { get; set; }

        public string? ImageURL { get; set; }

        public string? Biography { get; set; }

        public int? Age { get; set; }
        public List<MovieActor> MovieActors { get; set; }



    }
}
