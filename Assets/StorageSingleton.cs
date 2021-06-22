using UnityEngine;

public class StorageSingleton : MonoBehaviour
{
    private IStorage _storage;
    // Start is called before the first frame update

    void Start()
    {
        // Uncomment if you want the mock storage implementation
        // _storage = new MockStorage();

        // Storage based on PlayerPrefs
        _storage = new PlayerPrefsStorage();
    }

    public T Load<T>(string key)
    {
        return _storage.Load<T>(key);
    }

    public void Save<T>(string key, T value)
    {
        _storage.Save<T>(key, value);
    }
}