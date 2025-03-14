using System.Xml.Xsl;

namespace SlotMaschine;

public class Money : ValueObject<Money>
{
    public static readonly Money None = new Money(0, 0, 0);
    public static readonly Money Cent = new Money(1, 0, 0);
    public static readonly Money TenCent = new Money(0, 1, 0);
    public static readonly Money FiftyCent = new Money(0, 0, 1);
    public int OneCentCount {get; }
    public int TenCentCount {get; }
    public int FiftyCentCount {get; }
    
    public decimal Amount => OneCentCount * 0.01m + TenCentCount * 0.1m  + FiftyCentCount * 0.5m;

    /// <inheritdoc />
    public Money(int oneCentCount, int tenCentCount, int fiftyCentCount)
    {
        if (oneCentCount < 0) throw new InvalidOperationException(nameof(oneCentCount));
        if (tenCentCount < 0) throw new InvalidOperationException(nameof(tenCentCount));
        if (fiftyCentCount < 0) throw new InvalidOperationException(nameof(fiftyCentCount));
        
        OneCentCount = oneCentCount;
        TenCentCount = tenCentCount;
        FiftyCentCount = fiftyCentCount;
    }
    
    public static Money operator +(Money left, Money right) => new(left.OneCentCount + right.OneCentCount, left.TenCentCount + right.TenCentCount, left.FiftyCentCount + right.FiftyCentCount);
    public static Money operator -(Money left, Money right) => new(left.OneCentCount - right.OneCentCount, left.TenCentCount - right.TenCentCount, left.FiftyCentCount - right.FiftyCentCount);

    /// <inheritdoc />
    protected override bool EqualsCore(Money other)
    {
        return TenCentCount == other.TenCentCount && FiftyCentCount == other.FiftyCentCount && OneCentCount == other.OneCentCount;
    }

    /// <inheritdoc />
    protected override int GetHashCodeCore()
    {
        return HashCode.Combine(OneCentCount, FiftyCentCount, OneCentCount);
    }
}