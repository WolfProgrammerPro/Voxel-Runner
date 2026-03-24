using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ILevelManager
{
    bool CanPlayOnItLevel(int level);
    int LoadingLevel { get; }
    int CurrentLevel { get; }
    void SetLoadingLevel(int level);
    void PlayOnLevel(int level);
    void ToMenu();
    void PlayOnLoadingLevel();
    void NextLevel();

    void PlayCurrentLevel();

}





public class LevelManager : MonoBehaviour, ILevelManager
{
    [SerializeField] private int currentLevel;
    [SerializeField] private int maximalLevel;


    private int loadingLevel;

    private const int MENU_LEVEL = 0;
    private const int MINIMAL_LEVEL = 0;

    public int LoadingLevel => loadingLevel;
    public int CurrentLevel => currentLevel;


    public bool CanPlayOnItLevel(int level) => level <= maximalLevel;

    public void PlayOnLevel(int level)
    {
        if (CanPlayOnItLevel(level))
        {
            currentLevel = level;
            PlayCurrentLevel();
        }
    }

    public void SetLoadingLevel(int level)
    {
        int clampedLevel = Math.Clamp(level, MENU_LEVEL + 1, SceneManager.sceneCountInBuildSettings-1);
        
        if (level <= maximalLevel && level == clampedLevel)
        {
            loadingLevel = level;
        }
    }

    public void ToMenu()
    {
        currentLevel = MENU_LEVEL;
        loadingLevel = MINIMAL_LEVEL;
        PlayCurrentLevel();
    }

    public void PlayOnLoadingLevel()
    {
        if (loadingLevel > MINIMAL_LEVEL && loadingLevel < SceneManager.sceneCountInBuildSettings)
        {
            PlayOnLevel(loadingLevel);
            loadingLevel = MINIMAL_LEVEL;
        }
    }



    public void NextLevel()
    {
        if (currentLevel < SceneManager.sceneCountInBuildSettings && currentLevel >= MINIMAL_LEVEL)
        {
            currentLevel++;
            PlayCurrentLevel();

        }
        else
        {
            Debug.Log("Next level is not defined on BuildSettings");
            ToMenu();
        }
    }

    public void PlayCurrentLevel()
    {
        if (currentLevel >= SceneManager.sceneCountInBuildSettings)
        {
            currentLevel = MENU_LEVEL;
        }
        if (currentLevel >= MINIMAL_LEVEL)
        {
            maximalLevel = Mathf.Clamp(maximalLevel, maximalLevel, currentLevel);
            maximalLevel = Mathf.Max(maximalLevel, MENU_LEVEL + 1, maximalLevel);
        }
        else
        {
            throw new IndexOutOfRangeException(nameof(currentLevel));
        }
        SceneManager.LoadScene(currentLevel);
    }




}