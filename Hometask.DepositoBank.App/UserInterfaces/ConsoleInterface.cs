using Hometask.DepositoBank.App.Properties;
using Hometask.DepositoBank.Core.Deposits.DepositsCalculations;
using Hometask.DepositoBank.Core.Deposits.Models;

namespace Hometask.DepositoBank.App.UserInterfaces;

public class ConsoleInterface : IUserInterface
{
    private readonly DepositCalculatorDouble depositCalculator = new();

    public void Start()
    {
        Console.WriteLine(Messages.Greeting);
        Console.WriteLine(Messages.Rates);

        double balance = GetBalanceInput();
        if (balance <= 0)
        {
            return;
        }

        // Задание 1 (без бонусов)
        Console.Write(Messages.DepositedBalance);
        Console.WriteLine($" {depositCalculator.Deposit(balance)}");

        // Задание 2 (с бонусами)
        Console.Write(Messages.DepositedBalanceWithBonus);
        Console.WriteLine($" {depositCalculator.Deposit(balance, Bonuses.Motivation)}");
    }

    private double GetBalanceInput()
    {
        double result = 0;
        int attempts = 3;

        Console.WriteLine(Messages.EnterBalance);
        while (attempts-- > 0)
        {
            if (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                if (attempts is 0)
                {
                    Console.WriteLine(Messages.NoAttemps);
                    return result;
                }

                Console.WriteLine(Messages.WrongInput);
                continue;
            }

            break;
        }

        return result;
    }
}
