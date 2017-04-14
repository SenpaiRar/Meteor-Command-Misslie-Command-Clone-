using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour {

    public Canvas thisCanvas;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        thisCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
