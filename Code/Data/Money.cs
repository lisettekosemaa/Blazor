using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abc.Data.Common;

namespace Abc.Data
{
    public sealed class Money : BaseEntity
    {
        [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")] 
        public decimal Amount { get; set; }
        public Guid? CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
