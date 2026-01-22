using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxSpeedX;
    [SerializeField] private float parallaxSpeedY;

    private SpriteRenderer spriteRenderer;
    private Transform cameraTranform;
    private float startPositionX;
    private float startPositionY;
    private float spriteSizeX;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraTranform = Camera.main.transform;
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
        spriteSizeX = spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        var relativeDistanceX =  cameraTranform.position.x * parallaxSpeedX;
        var relativeDistanceY =  cameraTranform.position.y * parallaxSpeedY;

        transform.position = new Vector3(startPositionX + relativeDistanceX, startPositionY + relativeDistanceY, transform.position.z);

        var relativeCameraDistance = cameraTranform.transform.position.x * (1f - parallaxSpeedX);
        
        if(relativeCameraDistance > startPositionX + spriteSizeX)
        {
            startPositionX += spriteSizeX;
        }
        else if(relativeCameraDistance < startPositionX - spriteSizeX)
        {
            startPositionX -= spriteSizeX;
        }
    }
}
