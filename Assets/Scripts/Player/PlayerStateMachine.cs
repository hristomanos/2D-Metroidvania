using UnityEngine;

namespace Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        PlayerState currentState;

        public void Initialize(PlayerState state)
        {
            currentState = state;
            currentState.Enter();
        }
        
        public void ChangeState(PlayerState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        private void Update()
        {
            currentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            currentState.PhysicsUpdate();
        }
    }
}