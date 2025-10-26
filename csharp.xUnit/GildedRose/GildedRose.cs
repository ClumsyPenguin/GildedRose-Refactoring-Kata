using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Domain;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var domainItem = ItemFactory.CreateFrom(item);
            domainItem.NextDay();
        }
    }
}