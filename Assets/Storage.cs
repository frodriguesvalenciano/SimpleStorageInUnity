public class Storage : IStorage
{
    private IStorage _storage = null;

    public Storage(IStorage storage)
    {
        _storage = storage;
    }

    public T Load<T>(string key)
    {
        return _storage.Load<T>(key);
    }

    public void Save<T>(string key, T value)
    {
        _storage.Save(key, value);
    }
    }