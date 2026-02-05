using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerJump : MonoBehaviour
    {
        [Header("Gravity modifier")]
        [SerializeField] private int baseGravity;
        [SerializeField] private int maxFallSpeed;
        [SerializeField] private int fallSpeedModifier;
    
        [SerializeField] private float jumpForce;
    
        private PlayerInput playerInput;
        private InputAction jumpAction;
    
        private Rigidbody2D rb;
        private GroundChecker groundChecker;

        public int MaxFallSpeed => maxFallSpeed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            groundChecker = GetComponent<GroundChecker>();
            playerInput = GetComponent<PlayerInput>();
        
            jumpAction = playerInput.actions["Jump"];
        }

        void Start()
        {
            jumpAction.performed += OnJumpButtonPressed;
            jumpAction.canceled += OnJumpButtonReleased;
        }

        private void FixedUpdate()
        {
            if(groundChecker.IsOnGround)
            {
                ResetGravityModifier();   
            }
        }

        private void OnJumpButtonPressed(InputAction.CallbackContext context)
        {
            if(groundChecker.IsOnGround is false)
                return;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);        
        }

        private void OnJumpButtonReleased(InputAction.CallbackContext context)
        {
            if(groundChecker.IsOnGround)
                return;

            ApplyGravityModifier();
        }
    
        private void ApplyGravityModifier()
        {
            rb.gravityScale = fallSpeedModifier;
        }

        private void ResetGravityModifier()
        {
            rb.gravityScale = baseGravity;
        }
    }
}
