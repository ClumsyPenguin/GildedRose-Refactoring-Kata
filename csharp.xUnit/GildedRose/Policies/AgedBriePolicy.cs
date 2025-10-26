using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Policies;

public sealed class AgedBriePolicy : IItemPolicy
{
    private const int NormalIncreaseRate = 1;
    private const int ExpiredIncreaseRate = 2;
    
    public bool Matches(string name) => name == "Aged Brie";
    
    public (SellIn, Quality) NextDay(SellIn sellIn, Quality quality)
    {
        var newSellInDate = sellIn.Decrement();
        
        var increaseValue = HasExpired(newSellInDate) 
            ? ExpiredIncreaseRate 
            : NormalIncreaseRate;
        
        return (newSellInDate, quality.Increase(increaseValue));
    }

    private static bool HasExpired(SellIn sellIn) => sellIn.Value < 0;
}