using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);      
    }

    public void resetScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
