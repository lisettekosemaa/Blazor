using System.ComponentModel.DataAnnotations;

namespace Abc.Data;

public class Country
{
    public int Id { get; set; }

    [Required]
    [StringLength(60)]
    public string Name { get; set; }

    [StringLength(3)]
    public string IsoCode { get; set; }  // nt "USA", "EST"
}