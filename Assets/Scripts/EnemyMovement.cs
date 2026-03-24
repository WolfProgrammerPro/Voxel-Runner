using UnityEngine;

public class EnemyMovement : CharacterMovement
{
    Transform target;

    protected override void Start()
    {
        base.Start();
    }

    public void SetTargetObject(Transform _target)
    {
        target = _target;
    }


    private readonly float epsilon = 0.1f;

    protected override void GetMoving()
    {
        if (target != null)
        {
            float xMoving = 0;

            if (target.position.x - epsilon> transform.position.x)
            {
                xMoving = 1;
            }
            else
            {
                if (target.position.x + epsilon< transform.position.x)
                {
                    xMoving = -1;
                }
            }
            SetMovingXY(xMoving, 0);
        }
        else
        {
            Debug.LogError($"Target is not defined in {name}");
        }
    }
}
