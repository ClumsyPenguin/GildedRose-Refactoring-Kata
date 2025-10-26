using Xunit;
using FluentAssertions;
using GildedRoseKata;
using GildedRoseTests.Builders;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void Conjured_Item_Should_Degrade_Twice_As_Fast_Before_Sell_Date()
    {
        var item = new ItemBuilder()
            .AsConjured()
            .WithSellIn(5)
            .WithQuality(10)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(8);
        item.SellIn.Should().Be(4);
    }

    [Fact]
    public void Conjured_Item_Should_Degrade_Twice_As_Fast_After_Sell_Date()
    {
        var item = new ItemBuilder()
            .AsConjured()
            .WithSellIn(0)
            .WithQuality(10)
            .Build();
        
        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();

        item.Quality.Should().Be(6);
        item.SellIn.Should().Be(-1);
    }

    [Fact]
    public void Conjured_Item_Quality_Should_Never_Be_Negative()
    {
        var item = new ItemBuilder()
            .AsConjured()
            .WithSellIn(5)
            .WithQuality(1)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(0);
    }
}