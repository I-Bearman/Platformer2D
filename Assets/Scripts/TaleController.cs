using UnityEngine;
using UnityEngine.UI;

public class TaleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] panel;

    private Animator playerAnim;
    private PlayerInput playerInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartLog();
    }
    private void StartLog()
    {
        playerAnim = player.GetComponent<Animator>();
        playerInput = player.GetComponent<PlayerInput>();
        playerAnim.SetFloat("Speed",0);
        playerInput.enabled = false;
        panel[0].SetActive(true);
    }
    public void NextLog()
    {

    }

    public void FinishLog()
    {
        panel[0].SetActive(false);
        playerInput.enabled = true;
        Destroy(gameObject);
    }
}
