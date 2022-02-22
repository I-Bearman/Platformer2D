using UnityEngine;

public class EnemyStarter : MonoBehaviour
{

    [SerializeField] EnemyMoving enemyMoving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            enemyMoving.enabled = true;
            Destroy(gameObject);
        }
    }
}
