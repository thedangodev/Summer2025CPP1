using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrounded;

    public bool IsGrounded => isGrounded;

    private LayerMask groundLayer;
    private Collider2D col;
    private Rigidbody2D rb;
    private float groundCheckRadius;
    
    private Vector2 groundCheckPos => new Vector2(col.bounds.min.x + col.bounds.extents.x, col.bounds.min.y);

    public GroundCheck(Collider2D collider, LayerMask layerMask, float checkRadius)
    {
        col = collider;
        groundLayer = layerMask;
        groundCheckRadius = checkRadius;
        rb = col.GetComponent<Rigidbody2D>();
    }

    public void CheckIsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);
    }
}