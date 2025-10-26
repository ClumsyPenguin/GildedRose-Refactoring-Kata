using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Policies;

public sealed class SulfurasPolicy : IItemPolicy
{
    public bool Matches(string name) => name.Contains("Sulfuras");
    public (SellIn, Quality) NextDay(SellIn sellIn, Quality quality)
    {
        return (sellIn, quality);
    }
}