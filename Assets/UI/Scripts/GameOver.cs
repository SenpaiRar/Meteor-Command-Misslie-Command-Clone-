using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    public Canvas GameOverCanvas;

    void Awake()
    {
        GameOverCanvas.enabled = false;
        CityManager.GameOverEvent += GameOverActive;
    }

    
	
	void Update () {
	
	}

    public void PlayAgain()
    {
        SceneManager.UnloadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("TestScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void GameOverActive()
    {
        GameOverCanvas.enabled = true;
    }
}
