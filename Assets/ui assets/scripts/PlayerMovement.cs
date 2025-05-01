using UnityEngine;
using UnityEngine.UI;                // for the fill image
using UnityEngine.SceneManagement;   // for loading scenes


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 7f;

    [Header("VFX")]
    public ParticleSystem MagicFX;    // drag your MagicFX particle system here

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
        // flip & play VFX
        if (MagicFX != null)
        {
            MagicFX.transform.position = transform.position;
            MagicFX.transform.localScale = Vector3.one;    // face right
            MagicFX.Play();
        }
    }

    public void OnLeftButtonDown()
    {
        movement = Vector2.left;
        // flip & play VFX
        if (MagicFX != null)
        {
            MagicFX.transform.position = transform.position;
            MagicFX.transform.localScale = new Vector3(-1, 1, 1);  // face left
            MagicFX.Play();
        }
    }

    public void OnButtonUp()
    {
        movement = Vector2.zero;
    }

    public void Jump()
    {
        // smoother arc
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (audioSource != null)
            audioSource.Play();

        if (animator != null)
            animator.SetTrigger("jump");

        // play jump VFX
        if (MagicFX != null)
        {
            MagicFX.transform.position = transform.position;
            MagicFX.Play();
        }
    }
}
