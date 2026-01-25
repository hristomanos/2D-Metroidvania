using System;
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

    private Vector2 moveInput;

    public bool IsAttacking { get; private set; }
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        attackAction = playerInput.actions[PlayerInputStrings.Attack];
        moveAction = playerInput.actions[PlayerInputStrings.Move];
    }
    
    void Start()
    {
        attackAction.performed += OnAttackButtonPressed;
        
        comboAttackInvoker = GetComponent<ComboAttackInvoker>();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (comboAttackInvoker.NumberOfButtonPresses > 0 is false) 
            IsAttacking = false;
    }

    private void OnAttackButtonPressed(InputAction.CallbackContext context)
    {
        IsAttacking = true;
        //animator.SetTrigger(AttackUp);
        
        //animator.SetTrigger(AttackDown);
        
        comboAttackInvoker.HandleCombo();
    }
}
