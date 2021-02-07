using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject Pause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            Pause.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
