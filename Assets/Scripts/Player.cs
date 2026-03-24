using UnityEngine;

public class Player : MonoBehaviour
{
    private TimeManager timeManager;
    private InterfaceManager interfaceManager;
    public void Kill()
    {
        print("death");
        if (interfaceManager != null && timeManager != null)
        {
            interfaceManager.ShowDeathScreen();
            timeManager.FreezeGame();
        }
    }
    public void SetInterfaceManager(InterfaceManager _interfaceManager)
    {
        interfaceManager = _interfaceManager;
    }

    public void SetTimeManager(TimeManager _timeManager)
    {
        timeManager = _timeManager;
    }
}
