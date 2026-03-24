using UnityEngine;

public class KillingBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Attack(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision.collider);
    }

    private void Attack(Collider collider)
    {
        GameObject colliderObject = collider.gameObject;
        if (colliderObject != null && colliderObject != gameObject)
        {
            Player player = colliderObject.GetComponent<Player>();
            if (player != null)
            {
                player.Kill();
            }
        }
    }
    
}
