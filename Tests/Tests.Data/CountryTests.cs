using Abc.Data;
using Abc.Tests.Aids;

namespace Abc.Tests.Data
{
    [TestClass]
    public sealed class CountryTests : BaseTests<Country>
    {
        [TestMethod] public void IdTest() => IsProperty<Guid>(nameof(Country.Id));
        [TestMethod] public void NameTest() => IsProperty<string>(nameof(Country.Name));
        [TestMethod] public void CodeTest() => IsProperty<string>(nameof(Country.Code));
        [TestMethod] public void NumericCodeTest() => IsProperty<string>(nameof(Country.NumericCode));
        [TestMethod] public void OfficialNameTest() => IsProperty<string>(nameof(Country.OfficialName));
        [TestMethod] public void NativeNameTest() => IsProperty<string>(nameof(Country.NativeName));
        [TestMethod] public void IsIsoCountryTest() => IsProperty<bool>(nameof(Country.IsIsoCountry));
        [TestMethod] public void IsoCodeTest() => IsProperty<string>(nameof(Country.IsoCode));
    }
}
