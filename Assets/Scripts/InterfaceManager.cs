using System;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private Animator interactWindowAnimator;
    [SerializeField] private Text interactText;
    [SerializeField] private Text keysCounterText;
    [SerializeField] private Image interactableObjectImage;

    [SerializeField] private LevelData levelData;

    [SerializeField] private GameObject deathScreen;


    public static Action onInteractButtonClick;

    private IInputReader inputReader;

    

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            inputReader = GameManager.Instance.GetInputReader();
        }
        else
        {
            Debug.LogError("No GameManager on this scene!!!");
        }
        ShowCollectedKeys();
    }

    public void Interact()
    {
        onInteractButtonClick?.Invoke();
    }

    public void ShowInteractableObjectText(string objectName, string interactionText, Sprite objectSprite)
    {
        if (IsMobile())
        {
            interactText.text = $"{interactionText} {objectName}";
        }
        else
        {
            interactText.text = $"{objectName} - {interactionText} [{inputReader.GetInteractKeyName()}]";
            
        }
        interactableObjectImage.sprite = objectSprite;
        interactWindowAnimator.SetBool("isVisible", true);
    }
    public void HideInteractableObjectText()
    {
        interactWindowAnimator.SetBool("isVisible", false);
    }

    public void ShowCollectedKeys()
    {
        if (levelData  != null)
        {
            keysCounterText.text = levelData.CollectedKeys.ToString() + "/" + levelData.NeededKeys.ToString();
            if (levelData.AllKeysIsCollected)
            {
                keysCounterText.color = Color.green;
            }
            else
            {
                keysCounterText.color = Color.white;
            }
        }
        else
        {
            Debug.LogError("LevelData is not defined");
        }
    }

    

    private bool IsMobile()
    {
        return (GameManager.Instance.GetInputType() == InputType.Mobile);
    }

    public void ShowDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Death screen is not defined");
        }
    }
    
}
