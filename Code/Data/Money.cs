using Abc.Data.Common;

namespace Abc.Data
{
    public sealed class Money : BaseEntity
    {
        public decimal Amount { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
