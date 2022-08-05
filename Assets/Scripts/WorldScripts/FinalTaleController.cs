using UnityEngine;
using UnityEngine.Playables;

public class FinalTaleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private EnemyMoving enemyMoving;

    private PlayableDirector playableDirector;
    private Animator playerAnim;
    private PlayerInput playerInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playableDirector = GetComponent<PlayableDirector>();
            playableDirector.Play();
            StartLog();
            playableDirector.stopped += FinishLog;
        }
    }
    private void StartLog()
    {
        playerAnim = player.GetComponent<Animator>();
        playerInput = player.GetComponent<PlayerInput>();
        playerAnim.SetFloat("Speed",0);
        playerInput.enabled = false;
    }

    public void FinishLog(PlayableDirector obj)
    {
        playerInput.enabled = true;
        enemyMoving.enabled = true;
        Destroy(gameObject);
    }
}