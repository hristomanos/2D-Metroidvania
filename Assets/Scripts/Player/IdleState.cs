using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class IdleState : GroundedSuperState
    {
        public IdleState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName) : base(player, stateMachine, animationController, animationName)
        {
            jumpAction.performed += OnJumpButtonPressed;
        }

        public override void TransitionChecks()
        {
            base.TransitionChecks();

            if (movementInput.x != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }
        
        private void OnJumpButtonPressed(InputAction.CallbackContext context)
        {
            Debug.Log("OnJumpButtonPressed");
            stateMachine.ChangeState(player.JumpState);
        }
    }
}