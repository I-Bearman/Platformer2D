using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] BoxCollider2D attackArea;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Hit()
    {
        anim.SetTrigger("Attack");
    }

    public void ActivateAttackArea()
    {
        attackArea.enabled = true;
    }
    public void DisactivateAttackArea()
    {
        attackArea.enabled = false;
    }
}