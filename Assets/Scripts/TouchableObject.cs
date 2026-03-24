using UnityEngine;

public enum TouchableObjectType
{
    None,
    Ladder,
    Brick
}


public class TouchableObject : MonoBehaviour
{
    [SerializeField] private TouchableObjectType objectType;
    public TouchableObjectType ObjectType => objectType;
}
