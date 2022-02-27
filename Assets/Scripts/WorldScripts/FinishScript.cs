using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private Collider2D hero;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text bonusTextInGame;
    [SerializeField] private Text bonusTextInWinPanel;
    [SerializeField] private Text enemyKilledText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == hero)
        {
            Rigidbody2D heroRig = hero.gameObject.GetComponent<Rigidbody2D>();
            heroRig.bodyType = (RigidbodyType2D)2;
            enemyKilledText.text = $"You killed {Health.enemyKilled} enemy(ies)";
            bonusTextInWinPanel.text = $"You have collected {bonusTextInGame.text} coin(s)";
            winPanel.SetActive(true);
        }
    }
}
