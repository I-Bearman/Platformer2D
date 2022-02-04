using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;

    [Header ("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform firePoint;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprtRend;
    private BoxCollider2D collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprtRend = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }

        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
        }
    }

    private void Jump()
    {
        if(isGrounded)
        {
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        if (direction < 0 && sprtRend.flipX == false)
        {
            sprtRend.flipX = true;
            firePoint.localPosition = new Vector2(firePoint.localPosition.x *-1, firePoint.localPosition.y);
            collider.offset = new Vector2(collider.offset.x * -1, collider.offset.y);
        }
        if (direction >= 0 && sprtRend.flipX == true)
        {
            sprtRend.flipX = false;
            firePoint.localPosition = new Vector2(firePoint.localPosition.x * -1, firePoint.localPosition.y);
            collider.offset = new Vector2(collider.offset.x * -1, collider.offset.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);
    }

    public void DisActivateAnimParameter(string nameParam)
    {
        anim.SetBool(nameParam, false);
    }
}