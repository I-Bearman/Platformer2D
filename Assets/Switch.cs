using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject door;
    private Animation anim;
    private bool isTrigging;

    void Start()
    {
        isTrigging = false;
        anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            canvas.SetActive(true);
            isTrigging = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            canvas.SetActive(false);
            isTrigging = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigging)
        {
            anim.Play();
            Destroy(door);
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
