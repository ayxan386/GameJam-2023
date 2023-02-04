using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject game;
    private bool GamePaused = false;

    public void Update()
    {
        if (Input.GetButtonDown("Pause") && !GamePaused)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pause.SetActive(true);
            GamePaused = true;
        }
        else if (Input.GetButtonDown("Pause") && GamePaused)
        {
            UnPauseGame();
        }
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause.SetActive(false);
        GamePaused = false;
    }
}