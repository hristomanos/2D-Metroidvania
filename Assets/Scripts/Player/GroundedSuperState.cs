using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class GroundedSuperState : PlayerState
    {
        protected Vector2     movementInput;
        protected InputAction moveAction;
        protected bool isOnGround;

        public GroundedSuperState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController,
            string animationName) : base(player, stateMachine, animationController, animationName)
        {
            moveAction = player.MoveAction;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            movementInput = moveAction.ReadValue<Vector2>();
            isOnGround = player.GroundChecker.IsOnGround;
        }
    }
}