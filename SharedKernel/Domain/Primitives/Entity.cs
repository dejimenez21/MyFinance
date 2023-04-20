﻿namespace SharedKernel.Domain.Primitives;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public override bool Equals(object? obj)
    {
        if(obj == null) return false;
        if(this.GetType() != obj.GetType()) return false;
        
        var other = obj as Entity;
        return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity a, Entity b)
    {
        return a is not null && b is not null && a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }
}
