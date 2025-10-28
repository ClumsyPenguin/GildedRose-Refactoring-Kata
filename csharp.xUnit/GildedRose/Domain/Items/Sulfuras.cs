using GildedRoseKata.Domain.Items.Abstractions;

namespace GildedRoseKata.Domain.Items;

public sealed class Sulfuras : IInventoryItem
{
    private readonly Item _item;

    public string Name => _item.Name;
    public SellIn SellIn { get; }
    public Quality Quality { get; }

    public Sulfuras(Item item)
    {
        _item = item;
        SellIn = SellIn.From(item.SellIn);
        Quality = Quality.From(item.Quality);
    }

    public void NextDay()
    {
        // Legendary item: never changes
    }
}
