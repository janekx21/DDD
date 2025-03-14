using static SlotMaschine.Money;

namespace SlotMaschine;

public sealed class SlotMaschine : Entity
{
    public Money MoneyInTransaction { get; private set; } = None;
    public Money MoneyInside { get; private set; } = None;


    public void InsertCoin(Money coin)
    {
        HashSet<Money> coins = [Cent, TenCent, FiftyCent];
        if (! coins.Contains(coin)) throw new InvalidOperationException();
        
        MoneyInTransaction += coin;
    }

    public void ReturnMoney()
    {
        MoneyInTransaction = None;
    }

    public void PullLeaver()
    {
        MoneyInside += MoneyInTransaction;
        MoneyInTransaction = Money.None;
    }
}