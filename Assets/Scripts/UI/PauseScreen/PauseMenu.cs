using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
