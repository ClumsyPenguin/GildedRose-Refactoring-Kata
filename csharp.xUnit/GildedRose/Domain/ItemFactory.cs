using GildedRoseKata.Abstractions;
using GildedRoseKata.Domain.Items;

namespace GildedRoseKata.Domain;

public static class ItemFactory
{
    public static IInventoryItem CreateFrom(Item item)
    {
        if (item.Name.Contains("Sulfuras"))
            return new Sulfuras(item);

        if (item.Name == "Aged Brie")
            return new AgedBrie(item);

        if (item.Name.StartsWith("Backstage passes"))
            return new BackstagePass(item);

        if (item.Name.StartsWith("Conjured"))
            return new ConjuredItem(item);

        return new NormalItem(item);
    }
}
