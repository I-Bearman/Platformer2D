using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthImage;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject attackArea;
    private float currentHealth;
    private Animator anim;
    public static int enemyKilled;

    private void Awake()
    {
        enemyKilled = 0;
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthImage.fillAmount = currentHealth/maxHealth;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Death");
            if(gameObject.layer == 8) //Hero
            {
                GetComponent<PlayerInput>().enabled = false;
            }
            if (gameObject.layer == 13) //Enemy
            {
                GetComponent<EnemyMoving>().enabled = false;
                if (attackArea)
                {
                    attackArea.SetActive(false);
                }
                gameObject.layer = 12; //NPC
                GetComponent<Rigidbody2D>().bodyType = 0;
                enemyKilled++;
            }
        }
    }

    public void ActivateDeathPanel()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }
}