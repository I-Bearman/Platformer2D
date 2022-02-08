using UnityEngine;

public class DamageDeallerNoBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    private Animator anim;

    private void Awake()
    {
        if (gameObject.layer != 8)
        {
            anim = GetComponent<Animator>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Damageable"))
        {
            if (gameObject.layer != 8)
            {
                anim.SetTrigger("Attack");
            }
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
