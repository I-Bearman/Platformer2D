using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthImage;
    [SerializeField] private GameObject deathPanel;
    private float currentHealth;
    private Animator anim;

    private void Awake()
    {
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
            if(gameObject.layer == 8)
            {
                GetComponent<PlayerInput>().enabled = false;
            }
            GetComponent<EnemyMoving>().enabled = false;
            gameObject.layer = 12;
            GetComponent<Rigidbody2D>().bodyType = 0;
        }
    }

    public void ActivateDeathPanel()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }
}