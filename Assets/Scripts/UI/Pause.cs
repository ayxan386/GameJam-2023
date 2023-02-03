using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject game;
    private bool GamePaused = false;
   

    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.Escape) && !GamePaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            pause.SetActive(true);
            GamePaused = true;
            Debug.Log("Game");
        }
    }

    public void UnPauseGame()
    {
        if(Input.GetKey(KeyCode.Escape) && !GamePaused)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            pause.SetActive(false);
            GamePaused = false; 
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
