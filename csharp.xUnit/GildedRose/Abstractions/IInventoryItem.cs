namespace GildedRoseKata.Abstractions;

public interface IInventoryItem
{
    string Name { get; }
    SellIn SellIn { get; }
    Quality Quality { get; }
    void NextDay();
}
