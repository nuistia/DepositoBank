using Hometask.DepositoBank.Core.Deposits.Models;
using System.Numerics;

namespace Hometask.DepositoBank.Core.Deposits.DepositsCalculations;

public interface IDepositCalculator<T> where T : INumber<T>
{
    T Deposit(T money, Bonuses bonus = Bonuses.No);
}
