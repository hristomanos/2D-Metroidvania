using UnityEngine;

namespace Player
{
    public class PlayerState
    {
        protected readonly Animator animationController;
        protected readonly string animationName;
        protected PlayerCharacter player;
        protected readonly PlayerStateMachine stateMachine;

        protected float startTime;
        protected bool isExitingState;
        protected bool isAnimationFinished;

        public PlayerState(PlayerCharacter player, PlayerStateMachine stateMachine, Animator animationController, string animationName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.animationController = animationController;
            this.animationName = animationName;
        }

        public virtual void Enter()
        {
            startTime = Time.time;
            isExitingState = false;
            isAnimationFinished = false;
            animationController.SetBool(animationName, true);
        }

        public virtual void Exit()
        {
            isExitingState = true;
            
            if (isAnimationFinished is false) 
                isAnimationFinished = true;
            
            animationController.SetBool(animationName, false);
        }

        public virtual void LogicUpdate()
        {
            TransitionChecks();
        }

        public virtual void PhysicsUpdate()
        {
            
        }

        public virtual void TransitionChecks()
        {
            
        }

        public virtual void AnimationTrigger()
        {
            isAnimationFinished = true;
        }
    }
}