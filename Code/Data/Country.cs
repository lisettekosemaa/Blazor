using Abc.Aids;
using Abc.Data.Common;

namespace Abc.Data;

public sealed class Country : NamedEntity
{ 
    [Random(3, 5, "0123456789")] public string NumericCode { get; set; } = "";
    [Random(4, 16)] public string OfficialName { get; set; } = "";
    [Random(4, 16)] public string NativeName { get; set; } = "";
    bool IsIsoCountry { get; set; }
    bool IsLoyaltyProgram { get; set; }
    [Random(4, 5, "EUKLCHSP")] public string IsoCode { get; set; } = "";
    public IEnumerable<CountryCurrency> Currencies { get; set; } = [];
}