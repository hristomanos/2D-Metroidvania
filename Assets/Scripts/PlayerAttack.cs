using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private static readonly int AttackUp = Animator.StringToHash("AttackUp");
    private static readonly int AttackDown = Animator.StringToHash("AttackDown");
    
    private PlayerInput playerInput;
    private InputAction attackAction;
    private InputAction moveAction;
    private ComboAttackInvoker comboAttackInvoker;
    private Animator animator;
    private GroundChecker  groundChecker;

    private Vector2 moveInput;

    public bool IsAttacking { get; private set; }
    
    public void StopAttacking() => IsAttacking = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        groundChecker = GetComponent<GroundChecker>();
        attackAction = playerInput.actions[PlayerInputStrings.Attack];
        moveAction = playerInput.actions[PlayerInputStrings.Move];
    }

    private void Start()
    {
        attackAction.performed += OnAttackButtonPressed;
        
        comboAttackInvoker = GetComponent<ComboAttackInvoker>();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void OnAttackButtonPressed(InputAction.CallbackContext context)
    {
        if(groundChecker.IsOnGround is false)
            return;
        
        IsAttacking = true;

        if (moveInput.y > 0.1f)
        {
            animator.SetTrigger(AttackUp);
        }
        else if (moveInput.y < -0.1f)
        {
            animator.SetTrigger(AttackDown);
        }
        else
        {
            comboAttackInvoker.HandleCombo();
        }
    }
}
