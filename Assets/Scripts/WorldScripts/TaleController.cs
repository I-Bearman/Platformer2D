﻿using UnityEngine;

public class TaleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] panel;

    private Animator playerAnim;
    private PlayerInput playerInput;
    private int i, lenghtOfDialog;

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
        playerInput.enabled = true;
        Destroy(gameObject);
    }
}