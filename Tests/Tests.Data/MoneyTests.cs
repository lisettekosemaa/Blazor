using Abc.Data;
using Abc.Tests.Aids;

namespace Abc.Tests.Data
{
    [TestClass]
    public sealed class MoneyTests : BaseTests<Money>
    {
        [TestMethod] public void IdTest() => IsProperty<Guid>(nameof(Money.Id));
        [TestMethod] public void AmountTest() => IsProperty<decimal>(nameof(Money.Amount));
        [TestMethod] public void CurrencyIdTest() => IsProperty<Guid?>(nameof(Money.CurrencyId));
    }
}
