using UnityEngine;

public class KeysOnLevelCounter
{
    private int keysCollected;


    private int keysOnThisLevel;

    public int CollectedKeys => keysCollected;
    public int NeededKeys => keysOnThisLevel;

    public KeysOnLevelCounter(int keysOnLevel)
    {
        this.keysOnThisLevel = keysOnLevel;
        this.keysCollected = 0;
    }



    public void KeyCollected()
    {
        keysCollected++;
    }



    public bool AllKeysIsCollected => keysCollected == keysOnThisLevel;
}
