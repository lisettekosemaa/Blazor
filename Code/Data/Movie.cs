using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.Data
{
    public class Movie
    {
        //Todo: ADD baseclass NamedEntity and make changes in tests and database?
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
