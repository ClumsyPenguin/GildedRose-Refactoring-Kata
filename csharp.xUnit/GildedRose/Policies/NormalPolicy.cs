using GildedRoseKata.Abstractions;
namespace GildedRoseKata.Policies;

public sealed class NormalPolicy : IItemPolicy
{
    private const int NormalDegradationRate = 1;
    private const int ExpiredDegradationRate = 2;
    
    public bool Matches(string name) => true;
    
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
