using Lab1.Domain.Core;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Storage;
>>>>>>> d61e295 (Tests.)

public class WalletRepository
{
    protected Wallet[] wallets = new Wallet[50];
    protected int _count = 0;

    public int GetCount()
    {
        return _count;
    }

    public bool AddWallet(Wallet wallet, User user)
    {
        if (_count == 50 || wallets.Contains(wallet))
        {
            return false;
        }
        user.Wallet = wallet;
        wallets[_count] = wallet;

        _count++;
        return true;
    }
    public bool IncreaseBalance(Wallet wallet, decimal balance)
    {
        if (balance <= 0)
        {
            return false;
        }
        wallet.Balance += balance;
        return true;
    }
}