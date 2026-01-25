using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float movementSpeed;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    private PlayerJump playerJump;
    private PlayerInput playerInput;
    private Vector2     movementInput;
    private InputAction moveAction;
    
    private PlayerStateController playerStateController;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        playerJump = GetComponent<PlayerJump>();
        playerStateController = GetComponent<PlayerStateController>();
        
        moveAction = playerInput.actions[PlayerInputStrings.Move];
    }

    private void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        FlipSprite();
        
        if(playerStateController.CurrentState == PlayerState.Attacking)
            return;
        
        MoveHorizontally();
    }
    
    private void MoveHorizontally()
    {
        rb.linearVelocity = new Vector2(movementInput.x * movementSpeed, Mathf.Max(rb.linearVelocity.y, -playerJump.MaxFallSpeed));
    }
    
    private void FlipSprite()
    {
        if(spriteRenderer.flipX && movementInput.x > 0f || spriteRenderer.flipX is false && movementInput.x < 0f)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
