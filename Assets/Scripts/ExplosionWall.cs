using UnityEngine;

public class ExplosionWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Spark(Clone)")
        {
            GetComponent<PointEffector2D>().enabled = true;
            Destroy(collision.gameObject);
        }
    }
}