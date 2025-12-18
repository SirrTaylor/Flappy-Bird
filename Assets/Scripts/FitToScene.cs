using UnityEngine;

public class FitToCameraWidth : MonoBehaviour
{
    void Start()
    {
        // 1. Get a reference to the main camera
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found! Cannot resize object.");
            return;
        }

        // 2. Calculate the camera's width in world units
        // cameraHeight = mainCamera.orthographicSize * 2
        // cameraWidth = cameraHeight * mainCamera.aspect
        float cameraWidth = mainCamera.orthographicSize * 2f * mainCamera.aspect;

        // 3. Get the width of the ground sprite
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null || sr.sprite == null)
        {
            Debug.LogError("SpriteRenderer or Sprite missing on the Ground. Cannot determine original width.");
            return;
        }

        // Get the original width of the sprite in world units (if scale is 1, 1, 1)
        float spriteOriginalWidth = sr.sprite.bounds.size.x;

        // 4. Calculate the necessary scale factor
        // The scale factor is how much we need to multiply the current scale by 
        // to make its final width equal to the camera's width.
        float scaleFactor = cameraWidth / spriteOriginalWidth;

        // 5. Apply the new scale to the X-axis
        Vector3 newScale = transform.localScale;
        newScale.x = scaleFactor;
        
        transform.localScale = newScale;

        // 6. Ensure the ground is centered horizontally (at X=0) for proper coverage
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    }
}