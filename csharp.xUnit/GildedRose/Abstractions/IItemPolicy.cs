namespace GildedRoseKata.Abstractions;

public interface IItemPolicy
{
    bool Matches(string name);
    (SellIn sellIn, Quality quality) NextDay(SellIn sellIn, Quality quality);
}
