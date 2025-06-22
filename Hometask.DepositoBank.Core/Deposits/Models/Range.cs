using System.Numerics;

namespace Hometask.DepositoBank.Core.Deposits.Models;

public class Range<T> where T : INumber<T>
{
    public T Start { get; init; }
    public T End { get; init; }

    public Range(T start, T end)
    {
        Start = start;
        End = end;
    }

    public bool Has(T value) => Start <= value && End <= value;
}
