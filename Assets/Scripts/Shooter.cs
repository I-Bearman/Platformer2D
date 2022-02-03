﻿using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot(float direction)
    {
        anim.SetBool("Attack", true);
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (firePoint.localPosition.x >= 0)
        {
            currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
        }
        else
        {
            currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
        }
    }
}
