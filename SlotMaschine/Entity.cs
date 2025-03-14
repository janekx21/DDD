namespace SlotMaschine;

public abstract class Entity
{
    public long Id { get; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (obj.GetType() != GetType()) return false;
        if (Id == 0 || other.Id == 0) return false;
        return Id == other.Id;
    }

    public static bool operator ==(Entity left, Entity right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        
        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }
}