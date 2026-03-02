using System.ComponentModel.DataAnnotations;

namespace Abc.Data;

public class Currency
{
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; }  // nt "Euro", "US Dollar"

    [Required]
    [StringLength(3)]
    public string Code { get; set; }  // nt "EUR", "USD"
}