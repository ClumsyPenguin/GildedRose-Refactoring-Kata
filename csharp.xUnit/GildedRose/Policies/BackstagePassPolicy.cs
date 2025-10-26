using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Policies;

public sealed class BackstagePassPolicy : IItemPolicy
{
    private const int TenDaysThreshold = 10;
    private const int FiveDaysThreshold = 5;
    
    public bool Matches(string name) => name.StartsWith("Backstage passes");
    
    public (SellIn, Quality) NextDay(SellIn sellIn, Quality quality)
    {
        var newSellInDate = sellIn.Decrement();
        
        if (HasConcertPassed(newSellInDate)) 
            return (newSellInDate, Quality.From(0));
        
        var increaseValue = CalculateQualityIncrease(newSellInDate);
        
        return (newSellInDate, quality.Increase(increaseValue));
    }

    private static bool HasConcertPassed(SellIn sellIn) => sellIn.Value < 0;

    private static int CalculateQualityIncrease(SellIn sellIn)
    {
        const int baseIncrease = 1;

        return sellIn.Value switch
        {
            < FiveDaysThreshold => baseIncrease + 2,
            < TenDaysThreshold => baseIncrease + 1,
            _ => baseIncrease
        };
    }
}