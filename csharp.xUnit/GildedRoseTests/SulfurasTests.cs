using FluentAssertions;
using GildedRoseTests.Builders;
using Xunit;

namespace GildedRoseTests;

public class SulfurasTests
{
    
    [Fact]
    public void Sulfuras_Quality_Should_Never_Change()
    {
        var item = new ItemBuilder()
            .WithName("Hand of Ragnaros")
            .AsSulfuras()
            .WithSellIn(5)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(80);
    }

    [Fact]
    public void Sulfuras_SellIn_Should_Never_Change()
    {
        var item = new ItemBuilder()
            .WithName("Hand of Ragnaros")
            .AsSulfuras()
            .WithSellIn(5)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.SellIn.Should().Be(5);
    }

    [Fact]
    public void Sulfuras_Never_Changes_Even_After_Sell_Date()
    {
        var item = new ItemBuilder()
            .WithName("Hand of Ragnaros")
            .AsSulfuras()
            .WithSellIn(-1)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(80);
        item.SellIn.Should().Be(-1);
    }

    [Fact]
    public void Sulfuras_Never_Changes_Over_Multiple_Days()
    {
        var item = new ItemBuilder()
            .WithName("Hand of Ragnaros")
            .AsSulfuras()
            .WithSellIn(0)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        
        for (var i = 0; i < 10; i++)
        {
            app.UpdateQuality();
        }
        
        item.Quality.Should().Be(80);
        item.SellIn.Should().Be(0);
    }
}
