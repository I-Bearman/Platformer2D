using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;

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
                currentTimeToRevert += Time.deltaTime;
                break;
            case walkState:
                rigitBody.velocity = Vector2.left * speed;
                break;
            case revertState:
                sp.flipX = !sp.flipX;
                speed *= -1;
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
            attack.Hit();
        }
    }
}
