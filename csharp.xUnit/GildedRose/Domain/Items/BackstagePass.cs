using System;
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
        _item.SellIn--;
        
        if (HasConcertPassed())
        {
            _item.Quality = 0;
            return;
        }
        
        var increaseValue = CalculateQualityIncrease();
        _item.Quality = Math.Min(50, _item.Quality + increaseValue);
    }

    private bool HasConcertPassed() => _item.SellIn < 0;

    private int CalculateQualityIncrease()
    {
        const int baseIncrease = 1;

        return _item.SellIn switch
        {
            < FiveDaysThreshold => baseIncrease + 2,
            < TenDaysThreshold => baseIncrease + 1,   // 10 days or less: +2 total
            _ => baseIncrease                          // More than 10 days: +1
        };
    }
}
