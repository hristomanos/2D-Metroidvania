using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float movementSpeed;
    
    private static readonly int AttackUp = Animator.StringToHash("AttackUp");
    private static readonly int AttackDown = Animator.StringToHash("AttackDown");
    
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    private PlayerJump playerJump;
    private GroundChecker groundChecker;
    
    private PlayerInput playerInput;
    private Vector2     movementInput;
    private InputAction moveAction;
    private InputAction attackAction;
    
    private Rigidbody2D rb;
    
    private ComboAttackInvoker comboAttackInvoker;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        playerJump = GetComponent<PlayerJump>();
        comboAttackInvoker = GetComponent<ComboAttackInvoker>();
        
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
    }

    private void Start()
    {
        attackAction.performed += OnAttackButtonPressed;
    }

    private void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        FlipSprite();
        
        if (comboAttackInvoker.IsComboAttacking)
            StopHorizontalMovement();
        else
            MoveHorizontally();
    }
    
    private void MoveHorizontally()
    {
        rb.linearVelocity = new Vector2(movementInput.x * movementSpeed, Mathf.Max(rb.linearVelocity.y, -playerJump.MaxFallSpeed));
    }

    private void StopHorizontalMovement()
    {
        rb.linearVelocity = Vector2.zero;
    }
    
    private void FlipSprite()
    {
        if(spriteRenderer.flipX && movementInput.x > 0f || spriteRenderer.flipX is false && movementInput.x < 0f)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    private void OnAttackButtonPressed(InputAction.CallbackContext context)
    {
        if(movementInput.y > 0.5f)
        {
            animator.SetTrigger(AttackUp);
        }
        else if(movementInput.y < -0.5f)
        {
            animator.SetTrigger(AttackDown);
        }
        else
        {
            comboAttackInvoker.HandleCombo();
        }
    }
}
