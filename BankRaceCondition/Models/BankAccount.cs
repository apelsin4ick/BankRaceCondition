using System.Threading;

namespace BankRaceCondition.Models;

public sealed class BankAccount
{
    private decimal _balance;
    private readonly object _sync = new();

    public decimal Balance
    {
        get
        {
            lock (_sync)
            {
                return _balance;
            }
        }
    }

    public void DepositUnsafe(decimal amount)
    {
        // TODO 1
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Сумма должна быть больше нуля.");
        }

        // TODO 2
        decimal temp = _balance;

        // TODO 3
        Thread.SpinWait(1000);

        // TODO 4
        _balance = temp + amount;
    }

    // бещопасная 
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Сумма должна быть больше нуля.");
        }

        lock (_sync)
        {
            _balance += amount;
        }
    }
}