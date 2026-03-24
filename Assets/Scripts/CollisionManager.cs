using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private int laddersTouching = 0;
    

    public int LaddersTouching => laddersTouching;


    private void OnCollisionEnter(Collision collision)
    {
        TouchObject(collision.gameObject, true);
    }
    private void OnCollisionExit(Collision collision)
    {
        TouchObject(collision.gameObject, false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        TouchObject(collision.gameObject, true);
    }
    private void OnTriggerExit(Collider collision)
    {
        TouchObject(collision.gameObject, false);
    }



    protected virtual void TouchObject(GameObject collider, bool isEntering)
    {
        TouchableObject touchableObject = collider.GetComponent<TouchableObject>();
        if (touchableObject != null)
        {
            switch (touchableObject.ObjectType)
            {
                case TouchableObjectType.Ladder:
                    if (isEntering)
                    {
                        laddersTouching++;
                    }
                    else
                    {
                        if (laddersTouching > 0)
                        {
                            laddersTouching--;
                        }
                    }
                break;
                
            }
        }
    }
}
