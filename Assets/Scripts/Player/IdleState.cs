using UnityEngine;

namespace Player
{
    public class IdleState : GroundedSuperState
    {
        public IdleState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName) : base(player, stateMachine, animationController, animationName)
        {
        }

        public override void TransitionChecks()
        {
            base.TransitionChecks();

            if (movementInput.x != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }
    }
}