namespace Buoi28.Models;
public class Wallet
{
    public decimal Balance { get; set; }
    public List<Transaction> History { get; } = new();

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            History.Add(
                new Transaction
                {
                    Type = "Deposit",
                    Amount = amount,
                    Time = DateTime.Now,
                }
            );
        }
    }
    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            History.Add(
                new Transaction
                {
                    Type = "Withdraw",
                    Amount = amount,
                    Time = DateTime.Now,
                }
            );
        }
    }
}
