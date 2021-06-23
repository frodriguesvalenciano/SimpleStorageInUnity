using UnityEngine;

public class Character : MonoBehaviour, ICacheable
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    [ContextMenu("Save To Cache")]
    public void SaveToCache()
    {
        GetComponent<StorageSingleton>().Save("Character", new CharacterData {xCoord = x, yCoord = y});
    }

    [ContextMenu("Load From Cache")]
    public void LoadFromCache()
    {
        // Load Cache
        var cache = GetComponent<StorageSingleton>().Load<CharacterData>("Character");
        x = cache.xCoord;
        y = cache.yCoord;
    }
}