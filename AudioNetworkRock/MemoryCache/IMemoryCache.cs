namespace AudioNetworkRock.MemoryCache
{
    public interface IMemoryCache
    {
        bool Contains(string key);
        object Get(string key);
        void Add(string key, object value);
    }
}
