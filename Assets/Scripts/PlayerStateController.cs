using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; }
    
    private GroundChecker  groundChecker;
    private Rigidbody2D rb;
    
    void Start()
    {
        groundChecker = GetComponent<GroundChecker>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (groundChecker.IsOnGround is false)
        {
            CurrentState = rb.linearVelocityY > 0 ? PlayerState.Jumping : PlayerState.Falling;
        }
        else if (Mathf.Abs(rb.linearVelocityX) > 0.1f)
        {
            CurrentState = PlayerState.Running;
        }
        else
        {
            CurrentState = PlayerState.Idle;
        }
    }
}
