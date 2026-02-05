using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private static readonly int XVelocity = Animator.StringToHash("xVelocity");
        private static readonly int YVelocity = Animator.StringToHash("yVelocity");
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
    
        private Animator playerAnimator;
        private Rigidbody2D rb;
        private GroundChecker groundChecker;

        void Awake()
        {
            playerAnimator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            groundChecker = GetComponent<GroundChecker>();
        }

        private void FixedUpdate()
        {
            playerAnimator.SetFloat(XVelocity, Mathf.Abs(rb.linearVelocity.x));
            playerAnimator.SetFloat(YVelocity, rb.linearVelocity.y);
            playerAnimator.SetBool(IsJumping, groundChecker.IsOnGround is false);
        }
    }
}
