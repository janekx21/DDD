using Xunit;
using static SlotMaschine.Money;

namespace SlotMaschine;

public class Tests
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(new Money(5, 7, 9), 
            new Money(1, 2, 3) + new Money(4, 5, 6));
    }
    
    [Fact]
    public void Test2()
    {
        Action action = () => new Money(-1,-2,-3);
        Assert.Throws<InvalidOperationException>(action);
    }
    
    [Fact]
    public void Test3()
    {
        var money = new Money(10, 10, 10);
        Assert.Equal(6.1m, money.Amount);
    }
    [Fact]
    public void Test4()
    {
        Action action = () => { _ = new Money(1, 0, 0) - new Money(0, 1, 0); };
        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void Test5()
    {
        var maschine = new SlotMaschine();
        maschine.InsertCoin(TenCent);
        maschine.ReturnMoney();
        Assert.Equal(0m, maschine.MoneyInTransaction.Amount);
    }
}