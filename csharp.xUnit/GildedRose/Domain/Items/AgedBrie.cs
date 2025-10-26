using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Domain.Items;

public sealed class AgedBrie : IInventoryItem
{
    private const int NormalIncreaseRate = 1;
    private const int ExpiredIncreaseRate = 2;

    private readonly Item _item;

    public string Name => _item.Name;
    public SellIn SellIn => SellIn.From(_item.SellIn);
    public Quality Quality => Quality.From(_item.Quality);

    public AgedBrie(Item item)
    {
        _item = item;
    }

    public void NextDay()
    {
        var sellIn = SellIn.Decrement();
        
        var increaseValue = sellIn.Value < 0 
            ? ExpiredIncreaseRate 
            : NormalIncreaseRate;
        
        var quality = Quality.Increase(increaseValue);
        
        _item.SellIn = sellIn.Value;
        _item.Quality = quality.Value;
    }
}
