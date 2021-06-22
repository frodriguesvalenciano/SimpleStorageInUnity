using UnityEngine;

class PlayerPrefsStorage : IStorage
{
    public T Load<T>(string key)
    {
        Debug.Log("Loading " + key);
        var value=  PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : string.Empty;
        return JsonUtility.FromJson<T>(value);
    }

    public void Save<T>(string key, T value)
    {
        Debug.Log("Saving " + key);
        var json = JsonUtility.ToJson(value);
        PlayerPrefs.SetString(key, json);
    }
}