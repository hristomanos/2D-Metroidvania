using UnityEngine;

public class PlayerMovementAnimationStateMachine : StateMachineBehaviour
{
    private static readonly int Blink = Animator.StringToHash("Blink");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerAttack = animator.GetComponent<PlayerAttack>();

        if (playerAttack != null)
        {
            playerAttack.StopAttacking();
        }
        
        var invoker = animator.GetComponent<ComboAttackInvoker>();
        if(invoker != null)
        {
            invoker.ResetCombo();
        }
    }

    private float timer = 10f;
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var stateController = animator.GetComponent<PlayerStateController>();

        if (stateController.CurrentState != PlayerState.Idle) 
            return;
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 10f;
            animator.SetTrigger(Blink);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
