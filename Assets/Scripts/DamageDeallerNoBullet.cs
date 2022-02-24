using UnityEngine;

public class DamageDeallerNoBullet : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.CompareTag("Damageable"))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}
