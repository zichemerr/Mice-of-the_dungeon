static class ID<T>
{
    static string cache;
    
    public static string Get()
    {
        if (cache == null)
            cache = typeof(T).FullName;
        return cache;
    }
    
    public static string Get<T>()
    {
        return ID<T>.Get();
    }
}