using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D col;
    [SerializeField] private float groundCheckRadius = 0.02f;
    [SerializeField] private Animator animator;

    [SerializeField] private bool isGrounded;
    private Vector2 groundCheckPos => new Vector2(col.bounds.min.x + col.bounds.extents.x, col.bounds.min.y);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxisRaw("Horizontal");

        if (hValue != 0f) { sr.flipX = hValue < 0; }

        rb.linearVelocityX = hValue * 5f;

        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }

        animator.SetFloat("hValue", Mathf.Abs(hValue));
    }
}
