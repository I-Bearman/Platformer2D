using UnityEngine;

public class ActivateExplosion : MonoBehaviour
{
    [SerializeField] private Collider2D hero;
    [SerializeField] private GameObject spark;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == hero)
        {
            GameObject SparkClone = Instantiate(spark);
            SparkClone.GetComponent<Rigidbody2D>().velocity = new Vector2(1,0);
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
