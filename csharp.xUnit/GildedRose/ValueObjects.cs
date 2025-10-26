using System;
using Vogen;

namespace GildedRoseKata;

[ValueObject<int>(conversions: Conversions.None)]
public readonly partial struct SellIn
{
    public SellIn Decrement() => From(Value - 1);
}

[ValueObject<int>(conversions: Conversions.None)]
public readonly partial struct Quality
{
    private static Validation Validate(int value)
    {
        return value < 0 
            ? Validation.Invalid("Quality cannot be negative") 
            : Validation.Ok;
    }
    
    public Quality Increase(int n = 1) => From(Math.Min(50, Value + n));
    public Quality Decrease(int n = 1) => From(Math.Max(0, Value - n));
}