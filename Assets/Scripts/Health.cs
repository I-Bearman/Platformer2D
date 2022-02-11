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
        if (currentHealth < 0)
        {
            anim.SetTrigger("Death");
            GetComponent<EnemyMoving>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            //Destroy(GetComponent<Rigidbody2D>());
           /* DamageDeallerNoBullet dDNB = GetComponent<DamageDeallerNoBullet>();
            Destroy(dDNB);*/
        }
    }

    public void ActivateDeathPanel()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }
}