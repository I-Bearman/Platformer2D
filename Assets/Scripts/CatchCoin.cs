using UnityEngine;
using UnityEngine.UI;

public class CatchCoin : MonoBehaviour
{
    private static int coinsAreCatched;
    [SerializeField] private Text bonusText;

    private void Awake()
    {
        coinsAreCatched = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Bonus layer is collissing only with Hero layer
        coinsAreCatched++;
        bonusText.text = coinsAreCatched.ToString();
        Destroy(gameObject);
    }
}
