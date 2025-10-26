using GildedRoseKata;

namespace GildedRoseTests.Builders;

internal class ItemBuilder
{
    private string _name = "Default Item";
    private int _sellIn = 0;
    private int _quality = 0;

    public ItemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ItemBuilder WithSellIn(int sellIn)
    {
        _sellIn = sellIn;
        return this;
    }

    public ItemBuilder WithQuality(int quality)
    {
        _quality = quality;
        return this;
    }

    public ItemBuilder AsConjured(string itemName = "Conjured Mana Cake")
    {
        _name = itemName;
        return this;
    }

    public ItemBuilder AsAgedBrie()
    {
        _name = "Aged Brie";
        return this;
    }

    public ItemBuilder AsSulfuras()
    {
        _name = "Sulfuras, Hand of Ragnaros";
        _quality = 80;
        return this;
    }

    public ItemBuilder AsBackstagePass()
    {
        _name = "Backstage passes to a TAFKAL80ETC concert";
        return this;
    }

    public Item Build()
    {
        return new Item
        {
            Name = _name,
            SellIn = _sellIn,
            Quality = _quality
        };
    }

    public static implicit operator Item(ItemBuilder builder) => builder.Build();
}
