using System.Numerics;

namespace Hometask.DepositoBank.Core.Deposits.Models;

public class Range<T>(T start, T end) where T : INumber<T>
{
    public T Start { get; init; } = start;
    public T End { get; init; } = end;

    public bool Contains(T value) => Start <= value && End < value;
}
