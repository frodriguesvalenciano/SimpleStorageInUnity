using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    private void Awake()
    {
        LoadFromCache();
    }

    [ContextMenu("Save To Cache")]
    private void SaveToCache()
    {
        GetComponent<StorageSingleton>().Save<CharacterData>("Character", new CharacterData {xCoord = x, yCoord = y});
    }

    [ContextMenu("Load From Cache")]
    private void LoadFromCache()
    {
        // Load Cache
        var cache = GetComponent<StorageSingleton>().Load<CharacterData>("Character");
        x = cache.xCoord;
        y = cache.yCoord;
    }
}

[Serializable]
internal class CharacterData
{
    public int xCoord;
    public int yCoord;
}
