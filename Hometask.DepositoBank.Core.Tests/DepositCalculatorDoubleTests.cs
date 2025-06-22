using Hometask.DepositoBank.Core.Deposits.DepositsCalculations;
using Hometask.DepositoBank.Core.Deposits.Models;

namespace Hometask.DepositoBank.Core.Tests;

[TestFixture]
public class DepositCalculatorDoubleTests
{
    [Test]
    [TestCase(0, 0)]
    [TestCase(1.0, 1.05)]
    [TestCase(99.0, 103.95)]
    [TestCase(100.0, 107)]
    [TestCase(199.0, 212.93)]
    [TestCase(200.0, 220)]
    [TestCase(58.0, 60.9)]
    [TestCase(158.0, 169.06)]
    [TestCase(258.0, 283.8)]
    public void Deposit_ValidDoubleValueNoBonus_ReturnsValidDepositWithNoBonus(double money, double deposit)
    {
        var calculator = new DepositCalculatorDouble();

        var result = calculator.Deposit(money);

        Assert.That(deposit, Is.EqualTo(result));
    }

    [Test]
    [TestCase(0, 15)]
    [TestCase(1.0, 16.05)]
    [TestCase(99.0, 118.95)]
    [TestCase(100.0, 122)]
    [TestCase(199.0, 227.93)]
    [TestCase(200.0, 235)]
    [TestCase(58.0, 75.9)]
    [TestCase(158.0, 184.06)]
    [TestCase(258.0, 298.8)]
    public void Deposit_ValidDoubleValieWithStandartBonus_ReturnsValidDepositWithBonus(double money, double deposit)
    {
        var calculator = new DepositCalculatorDouble();

        var result = calculator.Deposit(money, Bonuses.Motivation);

        Assert.That(deposit, Is.EqualTo(result));
    }

    [Test]
    [TestCase(-0.01)]
    [TestCase(-1)]
    public void Deposit_InvalidDoubleValue_ThrowsArgumentOutOfRangeException(double money)
    {
        var calculator = new DepositCalculatorDouble();

        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Deposit(money));
    }
}
