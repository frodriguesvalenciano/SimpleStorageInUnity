using System.Linq;
using UnityEngine;

public class StorageSingleton : MonoBehaviour, IStorage
{
    private IStorage _storage;

    private void OnEnable()
    {
        // Comment/Uncomment the one you want. Only one is allowed at a time.
        //_storage = new MockStorage();
        _storage = new PlayerPrefsStorage();

        InitialiseFromCache();
    }

    private static void InitialiseFromCache()
    {
        foreach (var cacheable in FindObjectsOfType<MonoBehaviour>().OfType<ICacheable>())
        {
            cacheable.LoadFromCache();
        }
    }

    public T Load<T>(string key)
    {
        return _storage.Load<T>(key);
    }

    public void Save<T>(string key, T value)
    {
        _storage.Save<T>(key, value);
    }

    // Save everything to cache when the storage is disabled (e.g. we quit the game)
    private void OnDisable()
    {
        SaveAllToCache();
    }

    private void OnApplicationQuit()
    {
        SaveAllToCache();
    }

    private void SaveAllToCache()
    {
        foreach (var cacheable in FindObjectsOfType<MonoBehaviour>().OfType<ICacheable>())
        {
            cacheable.SaveToCache();
        }
    }
}