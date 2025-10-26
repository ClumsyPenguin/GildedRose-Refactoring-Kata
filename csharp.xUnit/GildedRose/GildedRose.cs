using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly Inventory _inventory;

    public GildedRose(IList<Item> items)
    {
        _items = items;
        _inventory = new Inventory();
    }

    public void UpdateQuality()
    {
        _inventory.TickAll(_items);
    }
}