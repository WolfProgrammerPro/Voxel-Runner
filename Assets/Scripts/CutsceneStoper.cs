using UnityEngine;

public class CutsceneStoper : MonoBehaviour
{
    [SerializeField] private CutscenePlayer cutscenePlayer;
    [SerializeField] private GameStarter gameStarter;

    IInputReader inputReader;


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
            if (inputReader.isPressing(KeyCodeType.Space))
            {
                StopCutscene();
            }    
        }
    }

    public void StopCutscene()
    {
        if (cutscenePlayer != null && gameStarter != null)
        {
            cutscenePlayer.StopPlayCutscene();
            gameStarter.StartGameplay();
            Destroy(gameObject);
        }
    }
}
