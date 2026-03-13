using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class AttackSuperstate : PlayerState
    {
        protected InputAction attackAction;
        
        public AttackSuperstate(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName) : base(player, stateMachine, animationController, animationName)
        {
            attackAction = player.AttackAction;
        }
    }
}