using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        // Get Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump when Space or Mouse Click
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Jump pressed!");   // Check if input is detected
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Restart scene when colliding
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}