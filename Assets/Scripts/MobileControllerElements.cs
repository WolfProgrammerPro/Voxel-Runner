using UnityEngine;

public class MobileControllerElements : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    public FixedJoystick Joystick => joystick;

    public static MobileControllerElements Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            UpdateVisibility();
            GameManager.Instance.ReinitializeMobileInput();
        }
    }

    public void UpdateVisibility()
    {
        if (GameManager.Instance != null && GameManager.Instance.GetInputType() != InputType.Mobile)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}