namespace SlotMaschine;

public abstract class ValueObject<T> where T : ValueObject<T>
{
    public override bool Equals(object? obj)
    {
        if (obj is not T other) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualsCore(other);
    }

    protected abstract bool EqualsCore(T other);

    public override int GetHashCode() => GetHashCodeCore();
    protected abstract int GetHashCodeCore();

    public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        
        return left.Equals(right);
    }

    public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
    {
        return !(left == right);
    }
}