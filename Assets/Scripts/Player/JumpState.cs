using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class JumpState : GroundedSuperState
    {
        private readonly PlayerJump playerJump;
        
        public JumpState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName) : base(player, stateMachine, animationController, animationName)
        {
            playerJump = player.PlayerJump;
            
            jumpAction.canceled += OnJumpButtonReleased;
        }

        public override void Enter()
        {
            base.Enter();
            
            if(player.GroundChecker.IsOnGround is false)
                return;
            
            Debug.Log("Making Character Jump");
            
            playerJump.MakeCharacterJump();
        }


        public override void TransitionChecks()
        {
            base.TransitionChecks();
            
            if (player.GroundChecker.IsOnGround && player.Rb.linearVelocityY <= 0)
            {
                playerJump.ResetGravityModifier();
                stateMachine.ChangeState(player.IdleState);
                
                Debug.Log("Reset Gravity Modifier");
            }
        }

        private void OnJumpButtonReleased(InputAction.CallbackContext context)
        {
            if(isOnGround)
                return;
            
            playerJump.ApplyGravityModifier();
            
            Debug.Log("Applied Gravity Modifier");
        }
    }
}