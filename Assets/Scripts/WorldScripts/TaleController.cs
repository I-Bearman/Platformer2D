using UnityEngine;
using Cinemachine;

public class TaleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] panel;
    [SerializeField] private CinemachineVirtualCamera taleCamera;

    private Animator playerAnim;
    private PlayerInput playerInput;
    private int i, lenghtOfDialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            StartLog();
        }
    }
    private void StartLog()
    {
        playerAnim = player.GetComponent<Animator>();
        playerInput = player.GetComponent<PlayerInput>();
        playerAnim.SetFloat("Speed",0);
        playerInput.enabled = false;

        if(taleCamera)
        {
            taleCamera.Priority = 20;
        }
        i = 0;
        panel[i].SetActive(true);
        lenghtOfDialog = panel.Length;
    }
    public void NextLog()
    {
        if (i<lenghtOfDialog)
        {
            panel[i].SetActive(false);
            panel[++i].SetActive(true);
        }
    }

    public void FinishLog()
    {
        panel[i].SetActive(false);
        if (taleCamera)
        {
            taleCamera.Priority = 0;
        }
        playerInput.enabled = true;
        Destroy(gameObject);
    }
}