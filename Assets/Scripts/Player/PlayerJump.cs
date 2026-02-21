using UnityEngine;

namespace Player
{
    public class PlayerJump
    {
        private readonly int baseGravity;
        private readonly int fallSpeedModifier;
        private readonly float jumpForce;

        private Rigidbody2D rb;

        public PlayerJump(Rigidbody2D rb, int baseGravity, int fallSpeedModifier,  float jumpForce)
        {
            this.rb = rb;
            this.baseGravity = baseGravity;
            this.fallSpeedModifier = fallSpeedModifier;
            this.jumpForce = jumpForce;
        }

        public void MakeCharacterJump()
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);        
        }
        
        public void ApplyGravityModifier()
        {
            rb.gravityScale = fallSpeedModifier;
        }

        public void ResetGravityModifier()
        {
            rb.gravityScale = baseGravity;
        }
    }
}
