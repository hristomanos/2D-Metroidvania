using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; }
    
    private GroundChecker groundChecker;
    private Rigidbody2D   rb;
    
    private PlayerInput playerInput;

    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerInput = GetComponent<PlayerInput>();
    }
    
    void Start()
    {
        groundChecker = GetComponent<GroundChecker>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (playerAttack.IsAttacking && groundChecker.IsOnGround)
        {
            CurrentState = PlayerState.Attacking;
            rb.linearVelocity = Vector2.zero;
            return;
        }
        
        if (groundChecker.IsOnGround is false) 
            CurrentState = rb.linearVelocityY > 0 ? PlayerState.Jumping : PlayerState.Falling;
        
        CurrentState = Mathf.Abs(rb.linearVelocityX) > 0.1f ? PlayerState.Running : PlayerState.Idle;
    }
}
