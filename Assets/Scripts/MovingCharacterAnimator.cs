using UnityEngine;

public class MovingCharacterAnimator : MonoBehaviour
{
    protected CharacterMovement movement;
    protected Animator animator;

    private void Start()
    {
        InitializeComponent();
    }

    protected virtual void InitializeComponent()
    {
        movement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        Animate();
    }



    protected virtual void Animate()
    {
        if (animator == null || movement == null)
        {
            Debug.Log($"Missing components");
            return;
        }
        Vector2 movementDirection = movement.GetMovingDirection();
        bool isWalking = movementDirection.x != 0;
        animator.SetBool("isWalking", isWalking);
        
    }
}
