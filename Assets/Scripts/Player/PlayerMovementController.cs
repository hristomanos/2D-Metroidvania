using UnityEngine;

namespace Player
{
    public class PlayerMovementController
    {
        private float movementSpeed;
    
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rb;
        private PlayerJump playerJump;

        public PlayerMovementController(Rigidbody2D rb, SpriteRenderer spriteRenderer, PlayerJump playerJump, float movementSpeed)
        {
            this.rb = rb;
            this.spriteRenderer = spriteRenderer;
            this.playerJump = playerJump;
            this.movementSpeed = movementSpeed;
        }
    
        public void MoveCharacter(Vector2 movementInput)
        {
            rb.linearVelocity = new Vector2(movementInput.x * movementSpeed, Mathf.Max(rb.linearVelocity.y, -playerJump.MaxFallSpeed));
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
