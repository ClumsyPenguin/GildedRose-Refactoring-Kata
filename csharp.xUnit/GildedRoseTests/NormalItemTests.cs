using FluentAssertions;
using GildedRoseTests.Builders;
using Xunit;

namespace GildedRoseTests;

public class NormalItemTests
{
    [Fact]
    public void Normal_Item_Should_Degrade_By_One_Before_Sell_Date()
    {
        var item = new ItemBuilder()
            .WithName("+5 Dexterity Vest")
            .WithSellIn(5)
            .WithQuality(10)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(9);
        item.SellIn.Should().Be(4);
    }

    [Fact]
    public void Normal_Item_Should_Degrade_Twice_As_Fast_After_Sell_Date()
    {
        var item = new ItemBuilder()
            .WithName("Elixir of the Mongoose")
            .WithSellIn(0)
            .WithQuality(10)
            .Build();
        
        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();

        item.Quality.Should().Be(8);
        item.SellIn.Should().Be(-1);
    }

    [Fact]
    public void Normal_Item_Quality_Should_Never_Be_Negative()
    {
        var item = new ItemBuilder()
            .WithName("+5 Dexterity Vest")
            .WithSellIn(5)
            .WithQuality(0)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(0);
    }

    [Fact]
    public void Normal_Item_Quality_Degrades_To_Zero_Not_Below()
    {
        var item = new ItemBuilder()
            .WithName("Elixir of the Mongoose")
            .WithSellIn(-1)
            .WithQuality(1)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(0);
    }
}
