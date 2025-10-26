using GildedRoseKata.Abstractions;

namespace GildedRoseKata.Domain.Items;

public sealed class Sulfuras : IInventoryItem
{
    private readonly Item _item;

    public string Name => _item.Name;
    public SellIn SellIn => SellIn.From(_item.SellIn);
    public Quality Quality => Quality.From(_item.Quality);

    public Sulfuras(Item item)
    {
        _item = item;
    }

    public void NextDay()
    {
        // Legendary item: never changes
    }
}
