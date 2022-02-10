using UnityEngine;

public class CitizenMoving : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rB;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
    }
    public void Run()
    {
        rB.velocity = new Vector2(-2, 0);
        anim.SetFloat("Speed", Mathf.Abs(rB.velocity.x));
    }
}