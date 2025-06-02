using System;

public static class E
{
    public static string Id(Type getType)
    {
        return getType.FullName;
    }
    
    public static string Id<T>()
    {
        return ID<T>.Get();
    }
}