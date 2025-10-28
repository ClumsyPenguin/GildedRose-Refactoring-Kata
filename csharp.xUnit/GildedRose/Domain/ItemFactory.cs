using GildedRoseKata.Domain.Items;
using GildedRoseKata.Domain.Items.Abstractions;

namespace GildedRoseKata.Domain;

public static class ItemFactory
{
    public static IInventoryItem CreateFrom(Item item) => item.Name switch
    {
        _ when item.Name.Contains("Sulfuras") => new Sulfuras(item),
        "Aged Brie" => new AgedBrie(item),
        _ when item.Name.StartsWith("Backstage passes") => new BackstagePass(item),
        _ when item.Name.StartsWith("Conjured") => new ConjuredItem(item),
        _ => new NormalItem(item)
    };
}
