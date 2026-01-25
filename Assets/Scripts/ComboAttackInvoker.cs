using UnityEngine;

public class ComboAttackInvoker : MonoBehaviour
{
    private readonly string[] attackAnimationStrings = { "Attack1", "Attack2", "Attack3", "Attack4"};

    private const float ComboResetDelay = 0.5f;
    private float lastPressTime;

    private Animator animator;
    private int numberOfButtonPresses;
    
    public int NumberOfButtonPresses => numberOfButtonPresses;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Time.time - lastPressTime > ComboResetDelay)
            ResetNumberOfButtonPresses();
    }

    public void HandleCombo()
    {
        lastPressTime = Time.time;
        numberOfButtonPresses++;
        numberOfButtonPresses = Mathf.Clamp(numberOfButtonPresses, 0, attackAnimationStrings.Length);

        if(numberOfButtonPresses == 1)
            animator.SetTrigger(attackAnimationStrings[0]);
    }

    public void ComboAttack2Transition()
    {
        if(numberOfButtonPresses >= 2)
            animator.SetTrigger(attackAnimationStrings[1]);
    }

    public void ComboAttack3Transition()
    {
        if(numberOfButtonPresses >= 3)
            animator.SetTrigger(attackAnimationStrings[2]);
    }

    public void ComboAttack4Transition()
    {
        if(numberOfButtonPresses >= 4)
            animator.SetTrigger(attackAnimationStrings[3]);
    }

    public void ResetCombo()
    {
        ResetNumberOfButtonPresses();
    }

    private void ResetNumberOfButtonPresses()
    {
        numberOfButtonPresses = 0;
    }
}
