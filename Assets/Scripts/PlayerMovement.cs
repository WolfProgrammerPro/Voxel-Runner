using System.Net.Security;
using System.Runtime.Remoting.Messaging;
using Unity.VisualScripting;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private float starterZPosition;

    protected float movingX{ get; private set; }
    protected float movingY { get; private set; }

    protected Rigidbody objectRigidbody;


    [SerializeField] protected Transform rotatingBody;

    protected virtual void GetMoving() { }

    protected void SetMovingXY(float x, float y)
    {
        movingX = x;
        movingY = y;
    }

    public Vector2 GetMovingDirection() {  return new Vector2(movingX, movingY); }

    protected void Move()
    {
        Vector3 movement = (transform.forward * movingX + transform.up * movingY) * speed;
        Vector3 newVelocity = movement;



        if (objectRigidbody.useGravity)
        {
            newVelocity.y = objectRigidbody.linearVelocity.y;
        }

        newVelocity.z += starterZPosition - transform.position.z;

        objectRigidbody.linearVelocity = newVelocity;


    }

    protected virtual void RotateBody()
    {
        if (rotatingBody != null)
        {
            float currentXRotation = rotatingBody.localEulerAngles.x;
            if (movingX < 0)
            {
                rotatingBody.localRotation = Quaternion.Euler(currentXRotation, 180, 0);
            }
            else
            {
                rotatingBody.localRotation = Quaternion.Euler(currentXRotation, 0, 0);
            }
        }
        else
        {
            Debug.LogError("No rotationBody Transform");
        }
    }

    

    protected virtual void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        starterZPosition = transform.position.z;
    }

    protected virtual void SetRigidbodySettings()
    {
        
    }

    protected void Update()
    {
        GetMoving();
    }
    protected void FixedUpdate()
    {
        SetRigidbodySettings();
        Move();
        RotateBody();
    }
}





public class PlayerMovement : CharacterMovement
{
    private IInputReader inputReader;
    private CollisionManager collisionManager;

    protected override void Start()
    {
        base.Start();
        if (GameManager.Instance != null)
        {
            inputReader = GameManager.Instance.GetInputReader();
        }
        collisionManager = GetComponent<CollisionManager>();
    }

    

    protected override void GetMoving()
    {
        if (collisionManager != null)
        {
            float x = inputReader.ReadXAxis();
            float y = 0;
            if (collisionManager.LaddersTouching != 0)
            {
                y = inputReader.ReadYAxis();
            }
            SetMovingXY(x, y);
        }
        else
        {
            Debug.LogError("No collision manager on this object");
        }
    }

    protected override void SetRigidbodySettings()
    {
        if (collisionManager != null)
        {
            objectRigidbody.useGravity = collisionManager.LaddersTouching == 0;
        }
        else
        {
            Debug.LogError("No collision manager on this object");
        }
    }

    protected override void RotateBody()
    {
        base.RotateBody();
        if (rotatingBody != null)
        {
            float currentXRotation = rotatingBody.localEulerAngles.x;
            if (collisionManager.LaddersTouching > 0)
            {

                rotatingBody.localRotation = Quaternion.Euler(currentXRotation, -90, 0);
            }
        }
    }
    


}
