using UnityEngine;

public class EventableTouchableObjectObserver : MonoBehaviour
{
    [SerializeField] private EventableTouchableObject touchableObject;
    [SerializeField] private TouchObjectListener[] listeners;

    private void OnEnable()
    {
        touchableObject.OnObjectEnter += OnEnter;
        touchableObject.OnObjectExit += OnExit;
    }

    private void OnDisable()
    {
        touchableObject.OnObjectEnter -= OnEnter;
        touchableObject.OnObjectExit -= OnExit;
    }

    public void OnEnter(GameObject toucher)
    {
        foreach (TouchObjectListener listener in listeners)
        {
            listener.OnEnter(toucher);
        }
    }
    public void OnExit(GameObject toucher)
    {
        foreach (TouchObjectListener listener in listeners)
        {
            listener.OnExit(toucher);
        }
    }
}
