using Abc.Data;
using Abc.Tests.Aids;

namespace Abc.Tests.Data
{
    [TestClass]
    public sealed class CurrencyTests : BaseTests<Currency>
    {
        [TestMethod] public void IdTest() => IsProperty<Guid>(nameof(Currency.Id));
        [TestMethod] public void NameTest() => IsProperty<string>(nameof(Currency.Name));
        [TestMethod] public void CodeTest() => IsProperty<string>(nameof(Currency.Code));
        [TestMethod] public void NumericCodeTest() => IsProperty<string>(nameof(Currency.NumericCode));
        [TestMethod] public void MinorUnitSymbolTest() => IsProperty<string>(nameof(Currency.MinorUnitSymbol));
        [TestMethod] public void MajorUnitSymbolTest() => IsProperty<string>(nameof(Currency.MajorUnitSymbol));
        [TestMethod] public void RatioOfMinorUnitTest() => IsProperty<double>(nameof(Currency.RatioOfMinorUnit));
        [TestMethod] public void IsIsoCurrencyTest() => IsProperty<bool>(nameof(Currency.IsIsoCurrency));
    }
}
