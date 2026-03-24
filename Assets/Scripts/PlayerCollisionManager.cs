using UnityEngine;

public class PlayerCollisionManager : CollisionManager
{
    private PlayerInteracting playerInteracting;

    private void Start()
    {
        playerInteracting = GetComponent<PlayerInteracting>();
    }


    protected override void TouchObject(GameObject collider, bool isEntering)
    {
        base.TouchObject(collider, isEntering);
        InteractableObject interactableObject = collider.GetComponent<InteractableObject>();

        if (playerInteracting != null)
        {
            if (isEntering)
            {
                
                if (interactableObject != null)
                {
                    playerInteracting.SetInteractableObject(interactableObject);
                }
            }
            else
            {
                if (playerInteracting.CurrentInteractableObject == interactableObject)
                {
                    playerInteracting.SetInteractableObject(null);
                }
            }
        }
        else
        {
            Debug.Log("No PlayerInteracting on this object");
        }

    }
}
