using FluentAssertions;
using GildedRoseTests.Builders;
using Xunit;

namespace GildedRoseTests;

public class BackstagePassTests
{
    private const string BackStagePassName = "Backstage passes to a TAFKAL80ETC concert";
    
    [Fact]
    public void Backstage_Pass_Increases_By_One_When_More_Than_Ten_Days()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(15)
            .WithQuality(20)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(21);
        item.SellIn.Should().Be(14);
    }

    [Fact]
    public void Backstage_Pass_Increases_By_Two_When_Ten_Days_Or_Less()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(10)
            .WithQuality(20)
            .Build();
        
        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();

        item.Quality.Should().Be(22);
        item.SellIn.Should().Be(9);
    }

    [Fact]
    public void Backstage_Pass_Increases_By_Three_When_Five_Days_Or_Less()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(5)
            .WithQuality(20)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(23);
        item.SellIn.Should().Be(4);
    }

    [Fact]
    public void Backstage_Pass_Quality_Drops_To_Zero_After_Concert()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(0)
            .WithQuality(20)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(0);
        item.SellIn.Should().Be(-1);
    }

    [Fact]
    public void Backstage_Pass_Quality_Never_Exceeds_Fifty()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(5)
            .WithQuality(49)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(50);
    }

    [Fact]
    public void Backstage_Pass_Quality_Stays_At_Fifty()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(10)
            .WithQuality(50)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(50);
    }

    [Fact]
    public void Backstage_Pass_At_Six_Days_Increases_By_Two()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(6)
            .WithQuality(20)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(22);
    }

    [Fact]
    public void Backstage_Pass_At_Eleven_Days_Increases_By_One()
    {
        var item = new ItemBuilder()
            .WithName(BackStagePassName)
            .WithSellIn(11)
            .WithQuality(20)
            .Build();

        var app = new GildedRoseKata.GildedRose([item]);
        app.UpdateQuality();
        
        item.Quality.Should().Be(21);
    }
}
