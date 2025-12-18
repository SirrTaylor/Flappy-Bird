using UnityEngine;

public class FlappyBirdControllerLegacy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D component missing.");
        }
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // --- Horizontal Movement Input (Left/Right Arrow Keys or A/D Keys) ---
        // 'Horizontal' maps to the default Unity input settings for these keys
        float moveX = Input.GetAxis("Horizontal"); 

        // Apply horizontal velocity, keeping the current vertical (gravity/jump) velocity
        _rb.velocity = new Vector2(moveX * moveSpeed, _rb.velocity.y);
    }
    
    public void Jump()
    {
       
        if (_rb is null) return;
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f); 
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}