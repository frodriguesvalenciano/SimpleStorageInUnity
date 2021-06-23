using UnityEditor;
using UnityEngine;

public class CharacterIOC : MonoBehaviour, ICacheable
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    private IStorage storage;

    [ContextMenu("Save To Cache")]
    public void SaveToCache()
    {
        storage.Save("Character", new CharacterData {xCoord = x, yCoord = y});
    }

    [ContextMenu("Load From Cache")]
    public void LoadFromCache()
    {
        // Load Cache
        var cache = storage.Load<CharacterData>("Character");
        x = cache.xCoord;
        y = cache.yCoord;
    }

    private void Start()
    {
        storage = new Storage(new PlayerPrefsStorage()); 
        //storage = new Storage(new MockStorage()); 
    }
}