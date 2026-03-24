using UnityEngine;

public class ClimbingCharacterAnimator : MovingCharacterAnimator
{
    private CollisionManager collisionManager;


    protected override void InitializeComponent()
    {
        base.InitializeComponent();
        collisionManager = GetComponent<CollisionManager>();
    }

    protected override void Animate()
    {
        base.Animate();
        if (collisionManager != null && animator != null && movement != null)
        {
            Vector2 movementDirection = movement.GetMovingDirection();
            bool onLedder = collisionManager.LaddersTouching != 0;
            bool isClimbing = movementDirection.y != 0;
            animator.SetBool("onLedder", onLedder);
            animator.SetBool("isClimbing", isClimbing);
        }

    }
}
