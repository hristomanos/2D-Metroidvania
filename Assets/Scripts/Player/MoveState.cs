using UnityEngine;

namespace Player
{
    public class MoveState : GroundedSuperState
    {
        PlayerMovementController playerMovementController;
        
        public MoveState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName) : base(player, stateMachine, animationController, animationName)
        {
            playerMovementController = player.PlayerMovementController;
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            movementInput = moveAction.ReadValue<Vector2>();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            playerMovementController.FlipSprite(movementInput);

            playerMovementController.MoveCharacter(movementInput);
        }
        
        
        public override void TransitionChecks()
        {
            base.TransitionChecks();

            if (movementInput == Vector2.zero)
            {
                playerMovementController.StopCharacter();
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}