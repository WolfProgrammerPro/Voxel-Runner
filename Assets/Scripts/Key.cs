using UnityEngine;

public class Key : InteractableObject
{
    protected override void AfterSoundPlayed()
    {
        base.AfterSoundPlayed();
        if (levelData != null)
        {
            if (interfaceManager != null)
            {
                levelData.ChestCollected();
                interfaceManager.ShowCollectedKeys();
                Destroy(gameObject);
            }
            
        }
    }
}
