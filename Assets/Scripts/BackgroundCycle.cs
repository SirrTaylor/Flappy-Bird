using UnityEngine;

public class BackgroundCycler : MonoBehaviour
{
    // Array to hold the background sprites in the order you want them displayed.
    [Tooltip("Drag the background sprites into this array in the desired order (1, 2, 3, 4).")]
    public Sprite[] backgroundSprites; 

    // Time delay before switching to the next background.
    [Tooltip("Time in seconds to wait before cycling to the next background.")]
    public float cycleInterval = 15f; 

    private SpriteRenderer _spriteRenderer;
    private int _currentIndex = 0;
    private float _timer;

    void Start()
    {
        // 1. Get the SpriteRenderer component that displays the background image.
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component missing on the BackgroundCycler GameObject!");
            enabled = false; // Disable the script if no renderer is found
            return;
        }

        if (backgroundSprites.Length == 0)
        {
            Debug.LogError("Background Sprites array is empty! Please assign sprites in the Inspector.");
            enabled = false;
            return;
        }

        // 2. Set the initial background
        SetBackground(_currentIndex);
    }

    void Update()
    {
        // 1. Check if the timer has exceeded the cycle interval
        if (_timer >= cycleInterval)
        {
            CycleBackground();
            _timer = 0f; // Reset the timer
        }

        // 2. Increment the timer based on real-time
        _timer += Time.deltaTime;
    }

    private void CycleBackground()
    {
        // Increment the index
        _currentIndex++;

        // Use the modulo operator (%) to loop the index back to 0 
        // when it reaches the end of the array (e.g., 4 % 4 = 0)
        _currentIndex = _currentIndex % backgroundSprites.Length;

        // Apply the new background
        SetBackground(_currentIndex);
    }

    private void SetBackground(int index)
    {
        if (index >= 0 && index < backgroundSprites.Length)
        {
            _spriteRenderer.sprite = backgroundSprites[index];
        }
    }
}