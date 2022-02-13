using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private BoxCollider2D attackTriggerCollider;
    [SerializeField] private Transform attackArea;

    private Rigidbody2D rigitBody;
    private Animator anim;
    private SpriteRenderer sp;
    private Attack attack;

    private const int idleState = 0;
    private const int walkState = 1;
    private const int revertState = 2;

    private int currentState;
    private float currentTimeToRevert;

    private void Awake()
    {
        currentState = walkState;
        currentTimeToRevert = 0;
        rigitBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        attack = GetComponent<Attack>();
    }

    private void Update()
    {
        if(currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = revertState;
        }
        switch(currentState)
        {
            case idleState:
                rigitBody.velocity = Vector2.zero;
                currentTimeToRevert += Time.deltaTime;
                break;
            case walkState:
                rigitBody.velocity = Vector2.left * speed;
                break;
            case revertState:
                sp.flipX = !sp.flipX;
                speed *= -1;
                attackArea.localPosition = new Vector2(attackArea.localPosition.x * -1, attackArea.localPosition.y);
                attackTriggerCollider.offset = new Vector2(attackTriggerCollider.offset.x * -1, attackTriggerCollider.offset.y);
                currentState = walkState;
                break;
        }
        anim.SetFloat("Speed", rigitBody.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyStopper"))
        {
            currentState = idleState;
        }

        if(collision.gameObject.layer == 8)
        {
            currentState = idleState;
            attack.Hit();
        }
    }
}
