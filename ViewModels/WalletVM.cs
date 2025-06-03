namespace Buoi28.ViewModels;
using Buoi28.Models;
public class WalletVM
{
    public Wallet wallet { get; } = new();
    public decimal Balance => wallet.Balance;
    public List<Transaction> History => wallet.History;
    public void Deposit(decimal amount)
    {
        wallet.Deposit(amount);
    }
    public void Withdraw(decimal amount)
    {
        wallet.Withdraw(amount);
    }
}