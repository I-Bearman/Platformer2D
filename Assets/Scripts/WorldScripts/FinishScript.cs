using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private Collider2D hero;
    [SerializeField] private GameObject winPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == hero)
        {
            Rigidbody2D heroRig = hero.gameObject.GetComponent<Rigidbody2D>();
            heroRig.bodyType = (RigidbodyType2D)2;
            winPanel.SetActive(true);
        }
    }
}
