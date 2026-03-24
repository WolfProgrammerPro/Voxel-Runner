using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerInteracting : MonoBehaviour
{


    private IInputReader inputReader;
    private InteractableObject interactableObject;

    [SerializeField] private InterfaceManager interfaceManager;

    public InteractableObject CurrentInteractableObject => interactableObject;


    private void OnEnable()
    {
        InterfaceManager.onInteractButtonClick += Interact;

    }

    private void OnDisable()
    {
        InterfaceManager.onInteractButtonClick -= Interact;
    }

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            inputReader = GameManager.Instance.GetInputReader();
        }
    }

    public void SetInteractableObject(InteractableObject interactable)
    {
        interactableObject = interactable;
        ShowInteractableObject();
    }

    public void SetInterfaceManager(InterfaceManager _interfaceManager)
    {
        interfaceManager = _interfaceManager;
    }



    private void ShowInteractableObject()
    {
        if (interfaceManager != null)
        {
            if (interactableObject != null)
            {
                interfaceManager.ShowInteractableObjectText(interactableObject.ObjectName, interactableObject.InteractionText, interactableObject.ObjectSprite);
            }
            else
            {
                interfaceManager.HideInteractableObjectText();
            }    
        }
        else
        {
            Debug.Log("No InterfaceManager choosed");
        }

    }

    private void Interact()
    {
        if (interactableObject != null)
        {
            interactableObject.Interact();
        }
    }

    private void Update()
    {
        if (inputReader.isPressing(KeyCodeType.Interact))
        {
            Interact();
        }
    }

    

}
