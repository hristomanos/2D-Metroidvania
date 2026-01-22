using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private static readonly int AttackUp = Animator.StringToHash("AttackUp");
    private static readonly int AttackDown = Animator.StringToHash("AttackDown");

    [Header("Attributes")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    [Header("Ground check")]
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] float groundCheckCircleRadius;

    [Header("Gravity modifier")]
    [SerializeField] private int baseGravity;
    [SerializeField] private int maxFallSpeed;
    [SerializeField] private int fallSpeedModifier;

    [SerializeField] ComboAttackInvoker comboAttackInvoker;

    private PlayerInput playerInput;
    private InputAction jumpAction;
    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction attackUpAction;

    private Rigidbody2D rb;

    private bool isOnGround;
    private Vector2 movementInput;

    public bool IsOnGround => isOnGround;

    SpriteRenderer spriteRenderer;

    Animator animator;

    GroundCheckDebugRenderer groundCheckGizmoRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        groundCheckGizmoRenderer = GetComponent<GroundCheckDebugRenderer>();
        groundCheckGizmoRenderer.Initialize(groundCheckCircleRadius);
        
        jumpAction = playerInput.actions["Jump"];
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
    }

    void Start()
    {
        jumpAction.performed += OnJumpButtonPressed;
        jumpAction.canceled += OnJumpButtonReleased;
        attackAction.performed += OnAttackButtonPressed;
    }

    private void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        FlipSprite();

        GroundCheck();
        
        if (comboAttackInvoker.IsComboAttacking)
            StopHorizontalMovement();
        else
            MoveHorizontally();

        if(isOnGround)
        {
            ResetGravityModifier();   
        }
    }

    private void OnJumpButtonPressed(InputAction.CallbackContext context)
    {
        if(isOnGround is false)
            return;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);        
    }

    private void OnJumpButtonReleased(InputAction.CallbackContext context)
    {
        if(isOnGround)
            return;

        ApplyGravityModifier();
    }

    private void MoveHorizontally()
    {
        rb.linearVelocity = new Vector2(movementInput.x * movementSpeed, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
    }

    private void StopHorizontalMovement()
    {
        rb.linearVelocity = Vector2.zero;
    }

    private void ApplyGravityModifier()
    {
        rb.gravityScale = fallSpeedModifier;
    }

    private void ResetGravityModifier()
    {
        rb.gravityScale = baseGravity;
    }

    private void GroundCheck()
    {
        var circleOffset = 0.4f;

        var circlePosition = transform.position + Vector3.down * circleOffset;

        isOnGround = Physics2D.OverlapCircle(circlePosition, groundCheckCircleRadius, groundLayerMask);
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
        if (isOnGround is false)
            return;
        
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
