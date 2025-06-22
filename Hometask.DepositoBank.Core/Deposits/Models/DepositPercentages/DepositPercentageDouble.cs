namespace Hometask.DepositoBank.Core.Deposits.Models.DepositPercentages;

public static class DepositPercentageDouble 
{
    public static Dictionary<Range<double>, Percent> Rates => new()
    {
        {new Range<double>(0.01, 100), Percent.RateS},
        {new Range<double>(100, 200), Percent.RateM},
        {new Range<double>(200, double.MaxValue), Percent.RateL}
    };
}
