using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Abstractions;
using GildedRoseKata.Policies;

namespace GildedRoseKata;

public sealed class Inventory
{
    private readonly List<IItemPolicy> _policies;

    public Inventory(IEnumerable<IItemPolicy>? policies = null)
    {
        _policies = (policies ?? DefaultPolicies()).ToList();
    }

    public void TickAll(IList<Item> items)
    {
        foreach (var item in items)
        {
            var policy = _policies.First(p => p.Matches(item.Name));
            var (newSellIn, newQuality) = policy.NextDay(
                SellIn.From(item.SellIn), 
                Quality.From(item.Quality));
            
            item.SellIn = newSellIn.Value;
            item.Quality = newQuality.Value;
        }
    }

    private static IEnumerable<IItemPolicy> DefaultPolicies() =>
    [
        new SulfurasPolicy(), 
        new BackstagePassPolicy(),
        new AgedBriePolicy(), 
        new ConjuredPolicy(), 
        new NormalPolicy()
    ];
}
