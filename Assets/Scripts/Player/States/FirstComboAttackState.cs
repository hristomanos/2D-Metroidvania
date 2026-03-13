using UnityEngine;

namespace Player.States
{
    public class FirstComboAttackState : AttackSuperstate
    {
        public FirstComboAttackState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName) : base(player, stateMachine, animationController, animationName)
        {
            
        }
    }
}