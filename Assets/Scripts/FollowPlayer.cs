using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // --- Public Variables (Tunable in the Inspector) ---
    
    // We keep this public so you can still assign it manually if you want, 
    // but the Start() method will attempt to find it if it's null.
    public Transform target;

    [Tooltip("The tag of the GameObject the camera should follow.")]
    public string playerTag = "Player"; // Default tag used by Unity

    [Header("Follow Settings")]
    [Tooltip("How quickly the camera moves to the target position.")]
    public float smoothSpeed = 0.125f;
    [Tooltip("The camera's offset from the target's position.")]
    public Vector3 offset;

    void Start()
    {
        // 1. Check if the target is already set (e.g., manually in the Inspector)
        if (target != null)
        {
            return; // Target already assigned, nothing to do.
        }

        // 2. Find the player GameObject using the specified tag
        GameObject playerObject = GameObject.FindWithTag(playerTag);

        if (playerObject != null)
        {
            // 3. Assign the Transform component of the found object to the target
            target = playerObject.transform;
            Debug.Log($"CameraFollow: Found and tracking object with tag '{playerTag}'.");
        }
        else
        {
            // 4. Log an error if the player couldn't be found
            Debug.LogError($"CameraFollow: Target object with tag '{playerTag}' not found in the scene! Camera will not follow.");
        }
    }

    void LateUpdate()
    {
        if (target == null)
        {
            // Stop executing if the target hasn't been found
            return;
        }

        // Calculate the desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera's position towards the desired position
        // Vector3.Lerp interpolates between the current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the smoothed position
        transform.position = smoothedPosition;
    }
}