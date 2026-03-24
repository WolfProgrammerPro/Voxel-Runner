using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField] private GameObject escapeMenu;
    [SerializeField] private TimeManager timeManager;

    private IInputReader inputReader;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            inputReader = GameManager.Instance.GetInputReader();
        }
    }

    private void Update()
    {
        if (inputReader != null)
        {
            if (inputReader.isPressing(KeyCodeType.Escape))
            {
                OpenEscapeMenu();
            }
            if (inputReader.isPressing(KeyCodeType.Enter))
            {
                ToMenu();
            }
        }
    }

    public void OpenEscapeMenu()
    {
        escapeMenu.SetActive(!escapeMenu.activeInHierarchy);
        if (escapeMenu.activeInHierarchy)
        {
            FreezeGame();
        }
        else
        {
            UnfreezeGame();
        }
    }

    public void ToMenu()
    {
        if (GameManager.Instance != null)
        {
            UnfreezeGame();
            GameManager.Instance.ToMenu();
        }
    }

    public void Replay()
    {
        if (GameManager.Instance != null)
        {
            timeManager.UnfreezeGame();
            GameManager.Instance.ReplayLevel();
        }
    }

    private void FreezeGame()
    {
        if (timeManager != null)
        {
            timeManager.FreezeGame();
        }
        else
        {
            Debug.Log("No TimeManager choosed");
        }
    }

    private void UnfreezeGame()
    {
        if (timeManager != null)
        {
            timeManager.UnfreezeGame();
        }
        else
        {
            Debug.Log("No TimeManager choosed");
        }
    }
}
