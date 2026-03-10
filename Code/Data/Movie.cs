namespace Abc.Data
{
    public class Movie
    {
        //Todo: ADD baseclass NamedEntity and make changes in tests and database?
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
