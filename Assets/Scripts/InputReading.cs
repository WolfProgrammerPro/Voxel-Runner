using UnityEngine;

public enum KeyCodeType
{
    Interact,
    RemoveBlockRight,
    RemoveBlockLeft,
    Escape,
    Enter,
    Space
}

public enum InputType
{
    Desktop,
    Mobile
}



public interface IInputReader
{
    public float ReadXAxis();
    public float ReadYAxis();

    public string GetInteractKeyName();

    public bool isPressing(KeyCodeType keyCodeType);
}

public class DesktopInputReader : IInputReader
{
    public float ReadXAxis()
    {
        return Input.GetAxis("Horizontal");
    }
    public float ReadYAxis()
    {
        return Input.GetAxis("Vertical");
    }
    public string GetInteractKeyName()
    {
        return "F";
    }

    public bool isPressing(KeyCodeType keyCodeType)
    {
        switch (keyCodeType)
        {
            case KeyCodeType.Interact: return Input.GetKeyDown(KeyCode.F);
            case KeyCodeType.RemoveBlockRight: return Input.GetKeyDown(KeyCode.X);
            case KeyCodeType.RemoveBlockLeft: return Input.GetKeyDown(KeyCode.Z);
            case KeyCodeType.Escape: return Input.GetKeyDown(KeyCode.Escape);
            case KeyCodeType.Enter: return (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return));
            case KeyCodeType.Space: return Input.GetKeyDown(KeyCode.Space);
            default: return false;
        }
    }
}

public class MobileInputReader : IInputReader
{

    private FixedJoystick joystick;

    public MobileInputReader(FixedJoystick _joystick)
    {
        joystick = _joystick;
    }

    


    public float ReadXAxis()
    {
        return joystick.Horizontal;
    }
    public float ReadYAxis()
    {
        return joystick.Vertical;
    }
    public string GetInteractKeyName()
    {
        return "F";
    }

    public bool isPressing(KeyCodeType keyCodeType)
    {
        return false;
    }
}

