using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    [SerializeField] private Collider2D heroCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == heroCollider)
        {
            collision.GetComponent<Health>().ActivateDeathPanel();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
