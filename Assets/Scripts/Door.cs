using UnityEngine;

public class Door : InteractableObject
{
    protected override void AfterSoundPlayed()
    {
        base.AfterSoundPlayed();
        if (levelData != null)
        {
            if (levelData.AllKeysIsCollected)
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.NextLevel();
                }
            }
            else
            {
                Debug.Log("Не все сундуки собраны");
            }
        }
    }
}
