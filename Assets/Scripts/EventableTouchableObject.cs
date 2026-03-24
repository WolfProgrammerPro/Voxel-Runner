using System;
using UnityEngine;

public class EventableTouchableObject : MonoBehaviour
{
    public Action<GameObject> OnObjectEnter;
    public Action<GameObject> OnObjectExit;

    private void OnCollisionEnter(Collision collision)
    {
        HandleEnter(collision.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        HandleExit(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleEnter(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        HandleExit(other.gameObject);
    }

    private void HandleEnter(GameObject toucher)
    {
        OnObjectEnter?.Invoke(toucher);
    }

    private void HandleExit(GameObject toucher)
    {
        OnObjectExit?.Invoke(toucher);
    }    

}
