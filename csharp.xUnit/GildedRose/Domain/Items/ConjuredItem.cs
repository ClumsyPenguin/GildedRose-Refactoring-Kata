using GildedRoseKata.Domain.Items.Abstractions;

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
        var sellIn = SellIn.Decrement();
        
        var degradationRate = sellIn.Value < 0 
            ? ExpiredDegradationRate 
            : NormalDegradationRate;
        
        var quality = Quality.Decrease(degradationRate);
        
        _item.SellIn = sellIn.Value;
        _item.Quality = quality.Value;
    }
}
