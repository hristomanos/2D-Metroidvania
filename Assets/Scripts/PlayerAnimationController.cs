using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerMovementController playerMovementController;
    private Animator playerAnimator;
    private Rigidbody2D rb;

    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMovementController = GetComponent<PlayerMovementController>();
    }

    private void FixedUpdate()
    {
        playerAnimator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        playerAnimator.SetFloat("yVelocity", rb.linearVelocity.y);
        playerAnimator.SetBool("isJumping", !playerMovementController.IsOnGround);
    }
}
