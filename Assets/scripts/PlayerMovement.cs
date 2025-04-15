using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    public void OnRightButtonDown()
    {
        movement = Vector2.right;
    }

    public void OnLeftButtonDown()
    {
        movement = Vector2.left;
    }

    public void OnButtonUp()
    {
        movement = Vector2.zero;
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (audioSource != null)
            audioSource.Play();

        if (animator != null)
            animator.SetTrigger("jump");
    }
}
