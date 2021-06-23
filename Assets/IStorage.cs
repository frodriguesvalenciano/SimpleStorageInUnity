public interface IStorage
{
    public T Load<T>(string key);
    public void Save<T>(string key, T value);
}