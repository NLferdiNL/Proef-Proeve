using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

   

    public void Start()
    {
        if (!pauseMenuCanvas)
        {
            Debug.Log("PauseMenuCanvas: " + pauseMenuCanvas);
        }
    }

    public void Pause()
    {
        
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}