using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Policies;
public sealed class ConjuredPolicy : IItemPolicy
{
    private const int NormalDegradationRate = 2; // Twice as fast as normal items
    private const int ExpiredDegradationRate = 4; // Twice as fast as expired normal items
    
    public bool Matches(string name) => name.StartsWith("Conjured");
    
    public (SellIn, Quality) NextDay(SellIn sellIn, Quality quality)
    {
        var newSellInDate = sellIn.Decrement();
        
        var degradationRate = HasExpired(newSellInDate) 
            ? ExpiredDegradationRate 
            : NormalDegradationRate;
        
        return (newSellInDate, quality.Decrease(degradationRate));
    }

    private static bool HasExpired(SellIn sellIn) => sellIn.Value < 0;
}