using Abc.Data.Common;

namespace Abc.Data;

public sealed class Country : NamedEntity
{
    public string NumericCode { get; set; } = "";
    public string OfficialName { get; set; } = "";
    public string NativeName { get; set; } = "";
    public bool IsIsoCountry { get; set; }
    public string IsoCode { get; set; } = "";
}