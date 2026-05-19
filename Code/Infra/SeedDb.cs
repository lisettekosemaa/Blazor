using Abc.Aids;
using Abc.Data;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra
{
    public sealed class SeedDb(ApplicationDbContext db, int recCnt = 20)
    {
        public async Task Seed()
        {
            await db.Database.MigrateAsync();

            await seedTable(db.Countries, [
                nameof(Country.Currencies)
                /*,nameof(Country.TimeStamp)*/]);

            await seedTable(db.Currencies
                /*[nameof(Country.TimeStamp)]*/);

            await seedTable(db.Monies, [
                nameof(Money.CurrencyId),
                nameof(Money.Currency)
                /*,nameof(Country.TimeStamp)*/]);

            await seedTable(db.CountryCurrencies, [
                nameof(CountryCurrency.CountryId),
                nameof(CountryCurrency.CurrencyId),
                nameof(CountryCurrency.Currency)
                /*,nameof(Country.TimeStamp)*/]);

            await seedTable(db.Movies, [
                nameof(Movie.Country),
                nameof(Movie.Money)
                /*,nameof(Country.TimeStamp)*/]);
        }

        private async Task seedTable<T>(DbSet<T> set, string[] exclude = null) where T : class
        {
           if (set.Any()) return;
           var items = new List<T>();
           for (var i = 1; i <= recCnt; i++)
           {
               var item = (T)GetRandom.Object(typeof(T), exclude);
               items.Add(item);
           }
           await set.AddRangeAsync(items);
           await db.SaveChangesAsync();
        }
    }
}
