using Hometask.DepositoBank.Core.Deposits.Models;
using Hometask.DepositoBank.Core.Deposits.Models.DepositPercentages;

namespace Hometask.DepositoBank.Core.Deposits.DepositsCalculations;

public class DepositCalculatorDouble : IDepositCalculator<double>
{
    private const double PERCENT_COEFF = 0.01;

    public double Deposit(double money, Bonuses bonus = Bonuses.No)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(money);

        var rates = DepositPercentageDouble.Rates;
        double result = 0;

        var rateMatch = rates.Single(r => r.Key.Contains(money));

        result = money + (money * ((int)rateMatch.Value * PERCENT_COEFF)) + (int)bonus;

        return result;
    }
}
