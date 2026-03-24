using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private const float STOPPED_GAME_TIMESPEED = 0f;
    private const float BASIC_GAME_TIMESPEED = 1f;

    public void UnfreezeGame()
    {
        Time.timeScale = BASIC_GAME_TIMESPEED;
    }

    public void FreezeGame()
    {
        Time.timeScale = STOPPED_GAME_TIMESPEED;
    }
}
