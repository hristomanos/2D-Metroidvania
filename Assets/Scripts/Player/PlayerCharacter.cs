using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed;
        
        [Header("Jump")]
        [SerializeField] private int baseGravity;
        [SerializeField] private int maxFallSpeed;
        [SerializeField] private int fallSpeedModifier;
        [SerializeField] private float jumpForce;
        
        private PlayerInput playerInput;
        private InputAction moveAction;
        private InputAction jumpAction;
        
        private SpriteRenderer spriteRenderer;
        private GroundChecker groundChecker;
        
        private Rigidbody2D rb;
        private Animator animator;
        
        private PlayerStateMachine stateMachine;
        private JumpState jumpState;
        private IdleState idleState;
        private MoveState moveState;
        
        private PlayerMovementController playerMovementController;
        private PlayerJump playerJump;
        
        public int MaxFallSpeed => maxFallSpeed;
        
        public Rigidbody2D Rb => rb;
        
        public InputAction MoveAction => moveAction;
        public InputAction JumpAction => jumpAction;
        
        public IdleState IdleState => idleState;
        public MoveState MoveState => moveState;
        public JumpState JumpState => jumpState;
        
        public GroundChecker GroundChecker => groundChecker;
        
        public PlayerJump PlayerJump => playerJump;
        public PlayerMovementController PlayerMovementController => playerMovementController;
        
        private static readonly int VelocityY = Animator.StringToHash("VelocityY");

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            playerInput = GetComponent<PlayerInput>();
            groundChecker = GetComponent<GroundChecker>();
            animator = GetComponent<Animator>();
            stateMachine = GetComponent<PlayerStateMachine>();
            
            moveAction = playerInput.actions[PlayerInputStrings.Move];
            jumpAction = playerInput.actions[PlayerInputStrings.Jump];
            
            playerJump = new PlayerJump(rb, baseGravity, fallSpeedModifier, jumpForce);
            playerMovementController = new PlayerMovementController(this, spriteRenderer, movementSpeed);
            
            idleState = new IdleState(this, stateMachine, animator, PlayerAnimationStrings.Idle);
            moveState = new MoveState(this, stateMachine, animator, PlayerAnimationStrings.Move);
            jumpState = new JumpState(this, stateMachine, animator, PlayerAnimationStrings.Jump);
            
            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            animator.SetFloat(VelocityY, rb.linearVelocity.y);
        }
    }
}
