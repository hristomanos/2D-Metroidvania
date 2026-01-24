using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float movementSpeed;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    private PlayerJump playerJump;
    private GroundChecker groundChecker;
    
    private PlayerInput playerInput;
    private Vector2     movementInput;
    private InputAction moveAction;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        playerJump = GetComponent<PlayerJump>();
        
        moveAction = playerInput.actions[PlayerInputStrings.Move];
    }

    private void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        FlipSprite();
        
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
