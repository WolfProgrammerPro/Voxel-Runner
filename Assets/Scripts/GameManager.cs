using System;
using UnityEngine;





public class GameManager : MonoBehaviour
{

    private ILevelManager levelManager;
    private IInputManager inputManager;
    private ISoundsVolumeManager soundsVolumeManager;

    public float SoundsVolume => soundsVolumeManager.SoundsVolume;
    public float MusicVolume => soundsVolumeManager.MusicVolume;




   

    public static GameManager Instance { get; private set; }

    public static Action OnInputTypeChanged;
    public static Action OnLoadingLevelChanged;
    public static Action OnSoundVolumeChange;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Initialize();
    }

    

    public int GetLoadingLevel()
    {
        if (levelManager != null)
        {
            return levelManager.LoadingLevel;
        }
        else
        {
            return 0;
        }
        
    }

    public void ReinitializeMobileInput()
    {
        if (inputManager != null)
        {
            inputManager.InitializeInputReaders();
        }
    }

    public void ReplayLevel()
    {
        levelManager.PlayCurrentLevel();
    }

    public int GetCurrentLevel()
    {
        if (levelManager != null)
        {
            return levelManager.CurrentLevel;
        }
        else
        {
            return 0;
        }
    }


    private void OnEnable()
    {
        
    }

    private void Initialize()
    {
        levelManager = GetComponent<LevelManager>();
        inputManager = GetComponent<InputManager>();
        inputManager.InitializeInputReaders();
        soundsVolumeManager = GetComponent<SoundsVolumeManager>();
    }


    public InputType GetInputType()
    {
        if (inputManager != null)
        {
            return inputManager.GetInputType();
        }
        else
        {
            throw new Exception("InputManager is null");
        }
    }


    


    public void PlayOnLevel(int level)
    {
        levelManager.PlayOnLevel(level);
    }

    public void SetSoundsVolume(float volume)
    {
        if (soundsVolumeManager != null)
        {
            soundsVolumeManager.SetSoundsVolume(volume);
            OnSoundVolumeChange?.Invoke();
        }
        else
        {
            throw new Exception("No SoundVolumeManager on GameManager object");
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (soundsVolumeManager != null)
        {
            soundsVolumeManager.SetMusicVolume(volume);
            OnSoundVolumeChange?.Invoke();
        }
        else
        {
            throw new Exception("No SoundVolumeManager on GameManager object");
        }
    }

    public void SetLoadingLevel(int level)
    {
        levelManager.SetLoadingLevel(level);
        OnLoadingLevelChanged?.Invoke();
    }

    public void ToMenu()
    {
        levelManager.ToMenu();
    }

    public void PlayOnLoadingLevel()
    {
        levelManager.PlayOnLoadingLevel();
    }

    public void NextLevel()
    {
        levelManager.NextLevel();
    }



    public void SetInputReaderType(InputType type)
    {
        inputManager.SetInputReaderType(type);
        OnInputTypeChanged?.Invoke();
    }

    public IInputReader GetInputReader()
    {
        return inputManager.GetInputReader();

    }
}


