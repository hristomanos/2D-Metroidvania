using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float movementSpeed;
        
        private PlayerState playerState;
        private PlayerInput playerInput;
        private GroundChecker groundChecker;
        private InputAction moveAction;
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rb;
        private PlayerJump playerJump;
        private Animator animator;
        
        private PlayerStateMachine stateMachine;
        
        public InputAction MoveAction => moveAction;
        
        public GroundChecker GroundChecker => groundChecker;
        
        private IdleState idleState;
        
        public IdleState IdleState => idleState;
        
        private MoveState moveState;
        
        public MoveState MoveState => moveState;
        
        private PlayerMovementController playerMovementController;
        
        public PlayerMovementController PlayerMovementController => playerMovementController;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            playerJump = GetComponent<PlayerJump>();
            playerInput = GetComponent<PlayerInput>();
            groundChecker = GetComponent<GroundChecker>();
            animator = GetComponent<Animator>();
            stateMachine = GetComponent<PlayerStateMachine>();
            
            moveAction = playerInput.actions[PlayerInputStrings.Move];
            
            playerMovementController = new PlayerMovementController(rb, spriteRenderer, playerJump, movementSpeed);
            idleState = new IdleState(this, stateMachine,animator, PlayerAnimationStrings.Idle);
            moveState = new MoveState(this, stateMachine, animator, PlayerAnimationStrings.Move);
            stateMachine.Initialize(idleState);
        }
        
        void Update()
        {
            
        }
    }
}
