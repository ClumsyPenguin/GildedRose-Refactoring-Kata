using FluentAssertions;
using GildedRoseTests.Builders;
using Xunit;

namespace GildedRoseTests;

public class AgedBrieTests
{
    [Fact]
    public void Aged_Brie_Should_Increase_In_Quality_Before_Sell_Date()
    {
        var item = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(5)
            .WithQuality(10)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(11);
        item.SellIn.Should().Be(4);
    }

    [Fact]
    public void Aged_Brie_Should_Increase_Twice_As_Fast_After_Sell_Date()
    {
        var item = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(0)
            .WithQuality(10)
            .Build();
        
        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();

        item.Quality.Should().Be(12);
        item.SellIn.Should().Be(-1);
    }

    [Fact]
    public void Aged_Brie_Quality_Should_Never_Exceed_Fifty()
    {
        var item = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(5)
            .WithQuality(50)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(50);
    }

    [Fact]
    public void Aged_Brie_Quality_Caps_At_Fifty_After_Sell_Date()
    {
        var item = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(-1)
            .WithQuality(49)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(50);
    }

    [Fact]
    public void Aged_Brie_Increases_From_Zero_Quality()
    {
        var item = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(2)
            .WithQuality(0)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(1);
    }
}
