using System;
using UnityEngine;

class MockStorage : IStorage
{
    public T Load<T>(string key)
    {
        if (key == "Character")
            return (T) Convert.ChangeType(new CharacterData {xCoord = 100, yCoord = 300}, typeof(T));
        throw new Exception();
    }

    public void Save<T>(string key, T value)
    {
        Debug.Log("Saving " + key);
        var json = JsonUtility.ToJson(value);
        PlayerPrefs.SetString(key, json);
    }
}