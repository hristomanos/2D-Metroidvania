using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class GroundedSuperState : PlayerState
    {
        protected Vector2     movementInput;
        protected InputAction moveAction;
        protected InputAction jumpAction;
        protected bool isOnGround;
        
        protected GroundedSuperState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController,
            string animationName) : base(player, stateMachine, animationController, animationName)
        {
            moveAction = player.MoveAction;
            jumpAction = player.JumpAction;
            isOnGround = player.GroundChecker.IsOnGround;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            movementInput = moveAction.ReadValue<Vector2>();
            isOnGround = player.GroundChecker.IsOnGround;
        }
    }
}