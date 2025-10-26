using System;
using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Domain.Items;

public sealed class ConjuredItem : IInventoryItem
{
    private const int NormalDegradationRate = 2;
    private const int ExpiredDegradationRate = 4; 

    private readonly Item _item;

    public string Name => _item.Name;
    public SellIn SellIn => SellIn.From(_item.SellIn);
    public Quality Quality => Quality.From(_item.Quality);

    public ConjuredItem(Item item)
    {
        _item = item;
    }

    public void NextDay()
    {
        _item.SellIn--;
        
        var degradationRate = HasExpired() 
            ? ExpiredDegradationRate 
            : NormalDegradationRate;
        
        _item.Quality = Math.Max(0, _item.Quality - degradationRate);
    }

    private bool HasExpired() => _item.SellIn < 0;
}
