using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Domain.Items;

public sealed class BackstagePass : IInventoryItem
{
    private const int TenDaysThreshold = 10;
    private const int FiveDaysThreshold = 5;

    private readonly Item _item;

    public string Name => _item.Name;
    public SellIn SellIn => SellIn.From(_item.SellIn);
    public Quality Quality => Quality.From(_item.Quality);

    public BackstagePass(Item item)
    {
        _item = item;
    }

    public void NextDay()
    {
        var sellIn = SellIn.Decrement();
        
        if (sellIn.Value < 0)
        {
            _item.SellIn = sellIn.Value;
            _item.Quality = 0;
            return;
        }
        
        var increaseValue = CalculateQualityIncrease(sellIn);
        var quality = Quality.Increase(increaseValue);
        
        _item.SellIn = sellIn.Value;
        _item.Quality = quality.Value;
    }

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
