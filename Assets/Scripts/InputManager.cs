using System.Collections.Generic;
using UnityEngine;

public interface IInputManager
{
    InputType GetInputType();
    void SetInputReaderType(InputType type);
    IInputReader GetInputReader();

    void InitializeInputReaders();


}

public class InputManager : MonoBehaviour, IInputManager
{
    [SerializeField] private InputType inputType;
    private Dictionary<InputType, IInputReader> inputRealizations = new Dictionary<InputType, IInputReader>();

    public InputType GetInputType() { return inputType; }

    public void SetInputReaderType(InputType type)
    {
        inputType = type;
    }

    public IInputReader GetInputReader()
    {
        // Если словарь пуст, инициализируем
        if (inputRealizations == null || inputRealizations.Count == 0)
        {
            Debug.LogWarning("InputRealizations not initialized, initializing now...");
            InitializeInputReaders();
        }

        if (inputRealizations.ContainsKey(inputType))
        {
            return inputRealizations[inputType];
        }
        else
        {
            Debug.LogWarning($"No Input Realization for {inputType}, using Desktop as fallback");
            return new DesktopInputReader();
        }
    }

    public void InitializeInputReaders()
    {
        inputRealizations.Clear();

        inputRealizations[InputType.Desktop] = new DesktopInputReader();

        MobileControllerElements mobileElements = null;

        if (MobileControllerElements.Instance != null)
        {
            mobileElements = MobileControllerElements.Instance;
        }
        else
        {
            mobileElements = FindAnyObjectByType<MobileControllerElements>();
        }

        if (mobileElements != null && mobileElements.Joystick != null)
        {
            inputRealizations[InputType.Mobile] = new MobileInputReader(mobileElements.Joystick);
            Debug.Log("Mobile input reader initialized successfully");
        }
        else
        {
            Debug.Log("Mobile controller elements not found, mobile input will use desktop fallback");
            inputRealizations[InputType.Mobile] = new DesktopInputReader();
        }
    }
}
