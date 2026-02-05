using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        [Header("Ground check")]
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] float groundCheckCircleRadius;
    
        private GroundCheckDebugRenderer groundCheckGizmoRenderer;
        private bool isOnGround;
    
        public bool IsOnGround => isOnGround;

        private void Awake()
        {
            groundCheckGizmoRenderer = GetComponent<GroundCheckDebugRenderer>();
            groundCheckGizmoRenderer.Initialize(groundCheckCircleRadius);
        }
    
        private void FixedUpdate()
        {
            GroundCheck();
        }
    
        private void GroundCheck()
        {
            var circleOffset = 0.4f;

            var circlePosition = transform.position + Vector3.down * circleOffset;

            isOnGround = Physics2D.OverlapCircle(circlePosition, groundCheckCircleRadius, groundLayerMask);
        }
    }
}
