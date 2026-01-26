using UnityEngine;

public class GroundCheckDebugRenderer : MonoBehaviour
{
    private float groundCheckCircleRadius;

    public void Initialize(float circleRadius)
    {
        groundCheckCircleRadius = circleRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.4f, groundCheckCircleRadius);
    }
}
