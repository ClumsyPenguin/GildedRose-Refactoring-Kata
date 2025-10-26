using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRoseKata.GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("fixme", Items[0].Name);
    }
}