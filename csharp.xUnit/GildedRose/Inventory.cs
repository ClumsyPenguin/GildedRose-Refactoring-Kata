using GildedRoseKata.Abstractions;
using GildedRoseKata.Policies;

namespace GildedRoseKata;

using System.Collections.Generic;
using System.Linq;

public sealed class Inventory
{
    private readonly List<IItemPolicy> _policies;

    public Inventory(IEnumerable<IItemPolicy>? policies = null)
    {
        _policies = (policies ?? DefaultPolicies()).ToList();
    }

    public void TickAll(IList<Item> items)
    {
        foreach (var it in items)
        {
            var policy = _policies.First(p => p.Matches(it.Name));
            var (s2, q2) = policy.NextDay(SellIn.From(it.SellIn), Quality.From(it.Quality));
            it.SellIn = s2.Value;
            it.Quality = q2.Value;
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
