using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Attack attack;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        attack = GetComponent<Attack>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);

        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            attack.Hit();
            
        }

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}