using UnityEngine;

namespace Player.States
{
    public class AttackDownState : AttackSuperstate
    {
        public AttackDownState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName) : base(player, stateMachine, animationController, animationName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}