using UnityEngine;

public class LevelData : MonoBehaviour
{
    private KeysOnLevelCounter keysOnLevelCounter;


    private void Start()
    {
        keysOnLevelCounter = new KeysOnLevelCounter(GameObject.FindGameObjectsWithTag("Key").Length);
    }

    public void ChestCollected()
    {
        keysOnLevelCounter.KeyCollected();
        
    }

    public int CollectedKeys => keysOnLevelCounter.CollectedKeys;
    public int NeededKeys => keysOnLevelCounter.NeededKeys;
    public bool AllKeysIsCollected => keysOnLevelCounter.AllKeysIsCollected;
}
