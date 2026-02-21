using UnityEngine;

namespace Player
{
    public class PlayerMovementController
    {
        private float movementSpeed;
        private float maxFallSpeed;
        
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rb;

        public PlayerMovementController(PlayerCharacter player, SpriteRenderer spriteRenderer, float movementSpeed)
        {
            rb = player.Rb;
            maxFallSpeed = player.MaxFallSpeed;
            
            this.spriteRenderer = spriteRenderer;
            this.movementSpeed = movementSpeed;
        }
    
        public void MoveCharacter(Vector2 movementInput)
        {
            rb.linearVelocity = new Vector2(movementInput.x * movementSpeed, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
        }
    
        public void FlipSprite(Vector2 movementInput)
        {
            if(spriteRenderer.flipX && movementInput.x > 0f || spriteRenderer.flipX is false && movementInput.x < 0f)
            {
                
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
        
        public void StopCharacter()
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
