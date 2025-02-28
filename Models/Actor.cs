namespace FilmSitesi.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public int MovieId { get; set; }

        public string FullName { get; set; }

        public List<MovieActor> MovieActors { get; set; }



    }
}
